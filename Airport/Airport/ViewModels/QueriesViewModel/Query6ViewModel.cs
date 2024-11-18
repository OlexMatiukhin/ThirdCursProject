using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBService;
using Airport.Services.MongoDBSevice;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Media.Media3D;

namespace Airport.ViewModels.QueriesViewModel
{

    public class Query6ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Worker> _workers;


        private User _user;
        public ICommand DoQuery { get; }

        public ObservableCollection<Worker> Workers
        {
            get => _workers;
            set
            {
                if (_workers != value)
                {
                    _workers = value;
                    OnPropertyChanged(nameof(Workers));
                }
            }
        }
        private readonly UserService _userService;



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
        private int _minAge;
        private int _maxAge;
        private decimal _minSalary;
        private decimal _maxSalary;



        public int MinAge
        {
            get => _minAge;
            private set
            {
                if (_minAge != value)
                {
                    _minAge = value;
                    OnPropertyChanged(nameof(MinAge));
                }
            }
        }

        private string _minAgeText;
        public string MinAgeText
        {
            get => _minAgeText;
            set
            {
                _minAgeText = value;
                OnPropertyChanged(nameof(MinAgeText));

                if (int.TryParse(_minAgeText, out int parsedAge))
                {
                    MinAge = parsedAge;
                }
                else
                {
                    MessageBox.Show("Некорректный ввід", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        public int MaxAge
        {
            get => _maxAge;
            private set
            {
                if (_maxAge != value)
                {
                    _maxAge = value;
                    OnPropertyChanged(nameof(MaxAge));
                }
            }
        }

        private string _maxAgeText;
        public string MaxAgeText
        {
            get => _maxAgeText;
            set
            {
                _maxAgeText = value;
                OnPropertyChanged(nameof(MaxAgeText));

                if (int.TryParse(_maxAgeText, out int parsedAge))
                {
                    MaxAge = parsedAge;
                }
                else
                {
                    MessageBox.Show("Некорректный ввід", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public decimal MinSalary
        {
            get => _minSalary;
            private set
            {
                if (_minSalary != value)
                {
                    _minSalary = value;
                    OnPropertyChanged(nameof(MinSalary));
                }
            }
        }

        private string _minSalaryText;
        public string MinSalaryText
        {
            get => _minSalaryText;
            set
            {
                _minSalaryText = value;
                OnPropertyChanged(nameof(MinSalaryText));

                if (decimal.TryParse(_minSalaryText, out decimal parsedSalary))
                {
                    MinSalary = parsedSalary;
                }
                else
                {
                    MessageBox.Show("Некорректный ввід", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

   
        public decimal MaxSalary
        {
            get => _maxSalary;
            private set
            {
                if (_maxSalary != value)
                {
                    _maxSalary = value;
                    OnPropertyChanged(nameof(MaxSalary));
                }
            }
        }

        private string _maxSalaryText;
        public string MaxSalaryText
        {
            get => _maxSalaryText;
            set
            {
                _maxSalaryText = value;
                OnPropertyChanged(nameof(MaxSalaryText));

                if (decimal.TryParse(_maxSalaryText, out decimal parsedSalary))
                {
                    MaxSalary = parsedSalary;
                }
                else
                {
                    MessageBox.Show("Некорректный ввід", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private string _selectedQueryType;

        public string SelectedQueryType
        {
            get => _selectedQueryType;
            set
            {
                _selectedQueryType = value;
                OnPropertyChanged(nameof(SelectedQueryType));
            }
        }

        private string _position;
        public string Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }

        private string _gender;
        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public void OnDoQuery(object parameter)
        {
            string queryType = SelectedQueryType;
            if (!string.IsNullOrEmpty(SelectedQueryType))
            {
                if (queryType != "Кількість")
                {
                    
                    int minAge = MinAge;
                    int maxAge = MaxAge;
                    decimal minSalary = MinSalary;
                    decimal maxSalary = MaxSalary;

                   
                    if (minAge > maxAge)
                    {
                        MessageBox.Show("Некорректный ввід!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    if (minSalary > maxSalary)
                    {
                        MessageBox.Show("Некорректный ввід!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                
                    Workers = new ObservableCollection<Worker>(
                        _workerService.GetFilteredPilots(Gender, Position, minAge, maxAge, minSalary, maxSalary)
                    );
                }
                else
                {
                       int count = _workerService.GetFilteredPilotCount(
                        Gender, Position, MinAge, MaxAge, MinSalary, MaxSalary
                    );
                    MessageBox.Show($"Результат: {count}", "Результат", MessageBoxButton.OK);
                }
            }
        }




        private WorkerService _workerService;


        public ICommand OpenMainWindowCommand { get; }

        private void OnMainWindowOpen(object parameter)
        {
            _windowService.OpenWindow("MainMenuView", _user);
            _windowService.CloseWindow();

        }

        public ICommand LogoutCommand { get; }

        private void OnLogoutCommand(object parameter)
        {
            _windowService.OpenWindow("LoginView", _user);
            _windowService.CloseWindow();
        }



        private readonly IWindowService _windowService;
        public Query6ViewModel(IWindowService windowService, User user)
        {
            _windowService = windowService;
            _workerService = new WorkerService();

            _userService = new UserService();
            _user = user;
             Login = _user.Login;
             AccessRight = _user.AccessRight;
            DoQuery = new RelayCommand(OnDoQuery);
            LogoutCommand = new RelayCommand(OnLogoutCommand);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);


        }




      

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

