using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Services;
using Airport.Services.MongoDBService;
using DnsClient;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Airport.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly UserService _userService;

        public ICommand LoginCommand { get; }
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
        }

       



        private void ExecuteLogin(object parameter)
        {
            if (string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password))
            {
                var user = _userService.GetUserByLogin(Login);

                if (user != null && user.Password == Password)
                {
                    MessageBox.Show("Вхід успішний!", "Успіх", MessageBoxButton.OK, MessageBoxImage.Information);

                    _windowService.OpenWindow("MainWindow");
                }
                else
                {
                    
                    MessageBox.Show("Невірний логін або пароль.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
           
        }

     
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
