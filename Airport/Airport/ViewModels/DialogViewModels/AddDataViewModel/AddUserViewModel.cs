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
        private string _accesRight;

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

        public string AccessRight
        {
            get => _accesRight;
            set
            {
                _accesRight = value;
                OnPropertyChanged(nameof(AccessRight));
            }
        }

        public AddUserViewModel(IWindowService windowService)
        {
            _userService = new UserService();
            this._windowService = windowService;
            AddUserCommand = new RelayCommand(ExecuteAddUser);

            LoadData();
        }

        

        private void ExecuteAddUser(object parameter)
        {
            if(ValidateInputs())
            {
                var newUser = new User
                {
                    Login = Login,
                    Password = Password,
                    AccessRight = AccessRight
                };

                _userService.AddUser(newUser);


                MessageBox.Show("Користувач успішно доданий!", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);


                Login = string.Empty;
                Password = string.Empty;
                AccessRight = string.Empty;
                MessageBox.Show("Користувача успішно додано!");
                _windowService.CloseModalWindow();

            }



      
        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(Login))
            {
                MessageBox.Show("Логін не може бути порожнім.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Пароль не може бути порожнім.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrEmpty(AccessRight))
            {
                MessageBox.Show("Оберіть рівень доступу.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

       
            var existingUser = _userService.GetUsers().FirstOrDefault(u => u.Login == Login);
            if (existingUser != null)
            {
                MessageBox.Show("Користувач з таким логіном вже існує.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
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

