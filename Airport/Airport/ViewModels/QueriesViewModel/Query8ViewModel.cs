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

    public class Query8ViewModel : INotifyPropertyChanged
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
        public string RouteNumber
        {
            get => _routeNumber;
            set
            {
                if (_routeNumber != value)
                {
                    _routeNumber = value;
                    OnPropertyChanged(nameof(RouteNumber));
                }
            }
        }

        private string _minTicketPriceText;
        public string MinTicketPriceText
        {
            get => _minTicketPriceText;
            set
            {
                if (_minTicketPriceText != value)
                {
                    _minTicketPriceText = value;
                    OnPropertyChanged(nameof(MinTicketPriceText));

                    if (double.TryParse(_minTicketPriceText, out double parsedValue))
                    {
                        MinTicketPrice = parsedValue;
                    }
                    else
                    {
                        MessageBox.Show("Некорректный вввід", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private double _minTicketPrice;
        public double MinTicketPrice
        {
            get => _minTicketPrice;
            private set
            {
                if (_minTicketPrice != value)
                {
                    _minTicketPrice = value;
                    OnPropertyChanged(nameof(MinTicketPrice));
                }
            }
        }

        private string _maxTicketPriceText;
        public string MaxTicketPriceText
        {
            get => _maxTicketPriceText;
            set
            {
                if (_maxTicketPriceText != value)
                {
                    _maxTicketPriceText = value;
                    OnPropertyChanged(nameof(MaxTicketPriceText));

                    if (double.TryParse(_maxTicketPriceText, out double parsedValue))
                    {
                        MaxTicketPrice = parsedValue;
                    }
                    else
                    {
                        MessageBox.Show("Некорректный вввід", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private double _maxTicketPrice;
        public double MaxTicketPrice
        {
            get => _maxTicketPrice;
            private set
            {
                if (_maxTicketPrice != value)
                {
                    _maxTicketPrice = value;
                    OnPropertyChanged(nameof(MaxTicketPrice));
                }
            }
        }


        private string _minDurationHoursText;
        public string MinDurationHoursText
        {
            get => _minDurationHoursText;
            set
            {
                if (_minDurationHoursText != value)
                {
                    _minDurationHoursText = value;
                    OnPropertyChanged(nameof(MinDurationHoursText));

                    if (int.TryParse(_minDurationHoursText, out int parsedValue))
                    {
                        MinDurationHours = parsedValue;
                    }
                    else
                    {
                        MessageBox.Show("Некорректный вввід", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private int _minDurationHours;
        public int MinDurationHours
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

        private string _maxDurationHoursText;
        public string MaxDurationHoursText
        {
            get => _maxDurationHoursText;
            set
            {
                if (_maxDurationHoursText != value)
                {
                    _maxDurationHoursText = value;
                    OnPropertyChanged(nameof(MaxDurationHoursText));

                    if (int.TryParse(_maxDurationHoursText, out int parsedValue))
                    {
                        MaxDurationHours = parsedValue;
                    }
                    else
                    {
                        MessageBox.Show("Некорректный вввід", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private int _maxDurationHours;
        public int MaxDurationHours
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


        public Query8ViewModel(IWindowService windowService, User user)
        {
            _windowService = windowService;
            _flightService = new FlightService();

            _userService = new UserService();
            _user = user;
             Login = _user.Login;
               AccessRight = _user.AccessRight;
            LogoutCommand = new RelayCommand(OnLogoutCommand);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);

            DoQuery = new RelayCommand(OnDoQuery);


        }




        public void OnDoQuery(object paramter)
        {

           MessageBox.Show($"{_flightService.GetAverageTicketsSold(MinTicketPrice, MaxTicketPrice, RouteNumber, MinDurationHours, MaxDurationHours)}");



        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

