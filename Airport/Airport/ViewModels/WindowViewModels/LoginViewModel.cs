using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.Services;
using global::Airport.Command.AddDataCommands.Airport.Commands;
using global::Airport.Services.MongoDBService;
using global::Airport.Services;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Airport.ViewModels.WindowViewModels
{
 

   
        public class LoginViewModel : INotifyPropertyChanged
        {
            private readonly UserService _userService;

        public ICommand LoginCommand { get; }
        public ICommand ForgotPasswordCommand { get; }
        private IWindowService _windowService;

            private string _login;
            private string _password;

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

            public LoginViewModel(IWindowService windowService)
            {
                _userService = new UserService();
                _windowService = windowService;
                LoginCommand = new RelayCommand(ExecuteLogin);
            ForgotPasswordCommand = new RelayCommand(ExecuteForgotPassword);
        }

          
           

           
            private void ExecuteLogin(object parameter)
            {
                if (!string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password))
                {
                    var user = _userService.GetUserByLogin(Login);

                    if (user != null && user.Password == Password)
                    {

                        MessageBox.Show("Вхід успішний!", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);

                        _windowService.OpenWindow("MainMenuView", _windowService); // Метод для открытия главного окна
                    }
                    else
                    {
                        
                        MessageBox.Show("Невірний логін або пароль.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
               
            }
        private void ExecuteForgotPassword(object parameter)
        {
            if (!string.IsNullOrEmpty(Login))
            {
                var user = _userService.GetUserByLogin(Login);

                if (user != null)
                {
                    MessageBox.Show($"Ваш пароль: {user.Password}", "Відновлення пароля", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Користувача з таким логіном не знайдено.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть логін.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    

}
