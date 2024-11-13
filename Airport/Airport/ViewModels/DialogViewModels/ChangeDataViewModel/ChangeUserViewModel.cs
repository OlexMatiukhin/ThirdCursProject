using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Services.MongoDBService;
using Airport.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace Airport.ViewModels.DialogViewModels.ChangeDataViewModel
{
    public class ChangeUserViewModel : INotifyPropertyChanged
    {
        private readonly UserService _userService;
        private readonly IWindowService _windowService;
        private User _user;

        public ICommand ChangeUserCommand { get; }

        public ChangeUserViewModel(IWindowService windowService, User user)
        {
            _userService = new UserService();
            _windowService = windowService;
            _user = user;
            Login = user.Login;
            Password = user.Password;
            AccessRight = user.AccessRight;

         
            ChangeUserCommand = new RelayCommand(ChangeUser);
        }

    
        private string _login;
        private string _password;
        private string _accessRight;

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
            get => _accessRight;
            set
            {
                _accessRight = value;
                OnPropertyChanged(nameof(AccessRight));
            }
        }

  
        public List<string> Roles { get; set; } = new List<string>
        {
            "власник",
            "адміністратор",
            "оператор",
            "гість"
        };

        private void ChangeUser(object parameter)
        {
          
            if (string.IsNullOrWhiteSpace(Login) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(AccessRight))
            {
               
                MessageBox.Show("Будь ласка, заповніть всі поля.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

          
            _user.Login = this.Login;
            _user.Password = this.Password;
            _user.AccessRight = this.AccessRight;
            _userService.UpdateUser(_user);
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
