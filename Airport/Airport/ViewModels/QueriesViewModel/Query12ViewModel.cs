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
using MongoDB.Bson;
using System.Windows;

namespace Airport.ViewModels.QueriesViewModel
{
    public class Query12ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CanceledFlightInfo> _canceledFlights;

        private CanceledFlightsService _canceledFlightsService;


        private User _user;
        public ICommand DoQuery { get; }

        public ObservableCollection<CanceledFlightInfo> CanceledFlights
        {
            get => _canceledFlights;
            set
            {
                if (_canceledFlights != value)
                {
                    _canceledFlights = value;
                    OnPropertyChanged(nameof(CanceledFlights));
                }
            }
        }

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
       

        private string _unoccupiedSeatNumberText;
        public string UnoccupiedSeatNumberText
        {
            get => _unoccupiedSeatNumberText;
            set
            {
                _unoccupiedSeatNumberText = value;
                OnPropertyChanged(nameof(UnoccupiedSeatNumberText));

               

                if (int.TryParse(_unoccupiedSeatNumberText, out int parsedDuration))
                {
                    UnoccupiedSeatNumber = parsedDuration;
                }
                else
                {
                    MessageBox.Show("Некорректный ввід", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private int _unoccupiedSeatNumber;
        private string _flightDirection;
      
        public int UnoccupiedSeatNumber
        {
            get => _unoccupiedSeatNumber;
            set
            {
                _unoccupiedSeatNumber = value;
                OnPropertyChanged(nameof(UnoccupiedSeatNumber));
            }
        }

        private string _routeNumber;
        public string RouteNumber
        {
            get => _routeNumber;
            set
            {
                _routeNumber = value;
                OnPropertyChanged(nameof(RouteNumber));
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

    









        private readonly IWindowService _windowService;
        public Query12ViewModel(IWindowService windowService, User user)
        {
            _windowService = windowService;
            _canceledFlightsService = new CanceledFlightsService();

            _userService = new UserService();
            _user = user;
            Login = _user.Login;
            AccessRight = _user.AccessRight;
            DoQuery = new RelayCommand(OnDoQuery);
            LogoutCommand = new RelayCommand(OnLogoutCommand);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);


        }


        public void OnDoQuery(object parameter)
        {

            
            
            
                


            CanceledFlights = new ObservableCollection<CanceledFlightInfo>(_canceledFlightsService.GetCanceledFlightsByRouteAndSeats(RouteNumber,UnoccupiedSeatNumber,FlightDirection));
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

