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
  
    public class Query7ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Flight> _flights;


        private User _user;
        public ICommand DoQuery { get; }

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
        private string _routeNumber;
        private double _minDurationHours;
        private double _maxDurationHours;

        public string RouteNumber
        {
            get => _routeNumber;
            set
            {
                _routeNumber = value;
                OnPropertyChanged(nameof(RouteNumber));
            }
        }

        private string _minDurationHoursText;
        public string MinDurationHoursText
        {
            get => _minDurationHoursText;
            set
            {
                _minDurationHoursText = value;
                OnPropertyChanged(nameof(MinDurationHoursText));

                if (double.TryParse(_minDurationHoursText, out double parsedDuration))
                {
                    MinDurationHours = parsedDuration;
                }
                else
                {
                    MessageBox.Show("Некорректный ввід", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private string _maxDurationHoursText;
        public string MaxDurationHoursText
        {
            get => _maxDurationHoursText;
            set
            {
                _maxDurationHoursText = value;
                OnPropertyChanged(nameof(MaxDurationHoursText));

                if (double.TryParse(_maxDurationHoursText, out double parsedDuration))
                {
                    MaxDurationHours = parsedDuration;
                }
                else
                {
                    MessageBox.Show("Некорректный ввід", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public double MinDurationHours
        {
            get => _minDurationHours;
            private set
            {
                if (_minDurationHours != value)
                {
                    _minDurationHours = value;
                    OnPropertyChanged(nameof(MinDurationHours));



                }
            }
        }

        public double MaxDurationHours
        {
            get => _maxDurationHours;
            private set
            {
                if (_maxDurationHours != value)
                {
                    _maxDurationHours = value;
                    OnPropertyChanged(nameof(MaxDurationHours));
                }
            }
        }








        private FlightService _flightService;






        private readonly IWindowService _windowService;
        public Query7ViewModel(IWindowService windowService, User user)
        {
            _windowService = windowService;
            _flightService = new FlightService();

            _userService = new UserService();
            _user = user;
            /* Login = _user.Login;
              AccessRight = _user.AccessRight;*/
            DoQuery = new RelayCommand(OnDoQuery);


        }




        public void OnDoQuery(object paramter)
        {             

             Flights = new ObservableCollection<Flight>(_flightService.GetFlightsByRouteWithDuration(RouteNumber, MinDurationHours, MaxDurationHours));                

            

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

