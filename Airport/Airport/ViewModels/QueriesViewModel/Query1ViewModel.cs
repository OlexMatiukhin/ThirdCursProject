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



namespace Airport.ViewModels.QueriesViewModel
{

    public class Query1ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Flight> _flights;


        private User _user;
        public ICommand DoQuery { get; }
        public ICommand OpenMainWindowCommand { get; }





        private void OnMainWindowOpen(object parameter)
        {
            _windowService.OpenWindow("MainMenuView", _user);
            _windowService.CloseWindow();

        }

        public ObservableCollection<Flight> Flights
        {
            get => _flights;
            set
            {
                if (_flights != value)
                {
                    _flights = value;
                    OnPropertyChanged(nameof(Flights));
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

        private string _category;
        private string _planeType;
        private string _flightDirection;


        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }

        public string PlaneType
        {
            get => _planeType;
            set
            {
                _planeType = value;
                OnPropertyChanged(nameof(PlaneType));
            }
        }

        public string FlightDirection
        {
            get => _flightDirection;
            set
            {
                _flightDirection = value;
                OnPropertyChanged(nameof(FlightDirection));
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

       

        private FlightService _flightService;






        private readonly IWindowService _windowService;
        public Query1ViewModel(IWindowService windowService, User user)
        {
            _windowService = windowService;
            _flightService = new FlightService();

            _userService = new UserService();
            _user = user;
           Login = _user.Login;
            AccessRight = _user.AccessRight;
            DoQuery = new RelayCommand(OnDoQuery);
            LogoutCommand = new RelayCommand(OnLogoutCommand);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);

        }


        private void OnLogoutCommand(object parameter)
        {
            _windowService.OpenWindow("LoginView", _user);
            _windowService.CloseWindow();
        }
        public ICommand LogoutCommand { get; }
      




        public void OnDoQuery(object paramter)
        {
            if (SelectedQueryType != null && SelectedQueryType != ""&& !string.IsNullOrWhiteSpace(Category) && !string.IsNullOrWhiteSpace(PlaneType) && !string.IsNullOrWhiteSpace(FlightDirection))
            {
                string queryType = SelectedQueryType;
               
                    if (queryType != "Кількість")
                    {

                        Flights = new ObservableCollection<Flight>(_flightService.GetCharterPassengerFlights(Category.Trim(), PlaneType.Trim(), FlightDirection.Trim()));


                    }
                    else
                    {
                        MessageBox.Show($"{_flightService.GetTotalCharterPassengerFlightsCount(Category, PlaneType, FlightDirection)}", "Результат", MessageBoxButton.OK);



                    }
                
               

            }
            else
            {
                MessageBox.Show($"Неправельний ввід!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}