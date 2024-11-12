﻿using Airport.Command.AddDataCommands;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Collections.Generic;
using Airport.Services.MongoDBService;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddUserViewModel : INotifyPropertyChanged
    {
        private readonly UserService _userService;
        private IWindowService _windowService;

        public ICommand AddUserCommand { get; }

        public ObservableCollection<User> Users { get; set; }

        public List<string> Roles { get; set; } = new List<string>
        {
            "власник",
            "адміністратор",
            "оператор",
            "гість"
        };

        private string _login;
        private string _password;
        private string _selectedRole;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string SelectedRole
        {
            get => _selectedRole;
            set
            {
                _selectedRole = value;
                OnPropertyChanged(nameof(SelectedRole));
            }
        }

        public AddUserViewModel(IWindowService windowService)
        {
            _userService = new UserService();
            this._windowService = windowService;
            AddUserCommand = new RelayCommand(ExecuteAddUser, canExecute => CanExecuteAddUser());

            LoadData();
        }

        private bool CanExecuteAddUser()
        {
            return !string.IsNullOrEmpty(Login) &&
                   !string.IsNullOrEmpty(Password) &&
                   !string.IsNullOrEmpty(SelectedRole);
        }

        private void ExecuteAddUser(object parameter)
        {
            var newUser = new User
            {
                Login = Login,
                Password = Password,
                AccessRight = SelectedRole
            };


            _userService.AddUser(newUser);

      
            MessageBox.Show("Користувач успішно доданий!", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);

       
            Login = string.Empty;
            Password = string.Empty;
            SelectedRole = string.Empty;
        }

        private void LoadData()
        {
            Users = new ObservableCollection<User>(_userService.GetUsers());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
