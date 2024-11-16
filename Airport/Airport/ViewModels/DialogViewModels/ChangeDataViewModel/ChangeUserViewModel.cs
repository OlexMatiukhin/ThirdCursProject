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

        private bool ValidateInputs()
        {
            bool isValid = true;

          
            if (string.IsNullOrWhiteSpace(Login))
            {
                MessageBox.Show("Поле 'Логін' не може бути порожнім.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Поле 'Пароль' не може бути порожнім.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(AccessRight))
            {
                MessageBox.Show("Поле 'Рівень доступу' не може бути порожнім.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            return isValid;
        }

        private void ChangeUser(object parameter)
        {
            if (ValidateInputs())
            {

                _user.Login = this.Login;
                _user.Password = this.Password;
                _user.AccessRight = this.AccessRight;
                _userService.UpdateUser(_user);
                System.Windows.MessageBox.Show("Об'єкт успішно змінено!");
                _windowService.CloseModalWindow();
            }

          
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
