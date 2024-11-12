using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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

        public UserViewModel(IWindowService windowService)
        {
            _windowService = windowService;
            _userService = new UserService();

            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            OpenAddWindowCommand = new RelayCommand(OnOpenAddWindow);
            OpenEditWindowCommand = new RelayCommand(OnOpenEditWindow);


            LoadUsers();
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
            _windowService.OpenWindow("MainMenuView");
            _windowService.CloseWindow();
        }

        private void OnOpenAddWindow(object parameter)
        {
            _windowService.OpenWindow("AddUserWindow");
        }

        private void OnOpenEditWindow(object parameter)
        {
            var selectedUser = parameter as User;
            if (selectedUser != null)
            {
                _windowService.OpenWindow("EditUserWindow", selectedUser);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

