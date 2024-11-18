using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBService;
using Airport.Services.MongoDBSevice;

namespace Airport.ViewModels.WindowViewModels
{
    public class UserViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<User> _users;
        private string _searchLine;
        private readonly UserService _userService;
        private readonly IWindowService _windowService;
        private User _user;
        public ICommand LogoutCommand { get; }

        public ICommand DeleteUserCommand { get; }




        public ICommand OpenMainWindowCommand { get; }
        public ICommand OpenAddWindowCommand { get; }
        public ICommand OpenEditWindowCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                if (_users != value)
                {
                    _users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
        }

        private string _login;
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


        public string AccessRight
        {
            get => _accessRight;
            set
            {
                _accessRight = value;
                OnPropertyChanged(nameof(AccessRight));
            }
        }

        public string SearchLine
        {
            get => _searchLine;
            set
            {
                _searchLine = value;
                SearchOperation(_searchLine);
                OnPropertyChanged(nameof(SearchLine));
            }
        }

        public UserViewModel(IWindowService windowService, User user)
        {
            _windowService = windowService;
            _userService = new UserService();

            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            OpenAddWindowCommand = new RelayCommand(OnOpenAddWindow);
            OpenEditWindowCommand = new RelayCommand(OnOpenEditWindow);
            this._user = user;
            DeleteUserCommand = new RelayCommand(OnDeleteUser);
            Login = _user.Login;
            AccessRight = _user.AccessRight;
            LogoutCommand = new RelayCommand(OnLogoutCommand);
            LoadUsers();
        }
        private void OnLogoutCommand(object parameter)
        {
            _windowService.OpenWindow("LoginView", _user);
            _windowService.CloseWindow();
        }



        private void OnDeleteUser(object parameter)
        {
            if (_userService.IfUserCanDoCrudUsers(_user))
            {

                var selectedUser = parameter as User;
                if (selectedUser != null && selectedUser.AccessRight != "власник")
                {
                    var result = MessageBox.Show(
                        $"Ви впевнинені що хочете вдиалити користувача з логіном {selectedUser.Login}?",
                        "Подтвердження видалення",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning
                    );

                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {

                            _userService.DeleteUser(selectedUser);
                            Users.Remove(selectedUser);
                            LoadUsers();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Помилка при видаленні користувача: {ex.Message}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

                    }
                }
                else
                {
                    MessageBox.Show($"Помилка при видаленні користувача з {selectedUser.Login}. Неможливо видаляти власника", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
        }

        private void LoadUsers()
        {
            try
            {
                var usersList = _userService.GetUsers();
                Users = new ObservableCollection<User>(usersList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading users: {ex.Message}");
            }
        }

               
        
        private void SearchOperation(string searchLine)
        {
            LoadUsers();
            if (!string.IsNullOrEmpty(searchLine))
            {
                var searchResult = SearchUsers(searchLine);
                Users = new ObservableCollection<User>(searchResult);
            }
        }

        private List<User> SearchUsers(string query)
        {
            return Users.Where(user =>
                user.Login.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                user.Password.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                user.AccessRight.Contains(query, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        private void OnMainWindowOpen(object parameter)
        {
            _windowService.OpenWindow("MainMenuView", _user);
            _windowService.CloseWindow();
        }

        private void OnOpenAddWindow(object parameter)
        {

            if (_userService.IfUserCanDoCrudUsers(_user))
            {
                _windowService.OpenModalWindow("AddUser");
                LoadUsers();
            }
        }


      


        private void OnOpenEditWindow(object parameter)
        {
            if (_userService.IfUserCanDoCrudUsers(_user))
            {
                var selectedUser = parameter as User;
                if (selectedUser != null)
                {
                    _windowService.OpenModalWindow("ChangeUser", selectedUser);
                  
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

