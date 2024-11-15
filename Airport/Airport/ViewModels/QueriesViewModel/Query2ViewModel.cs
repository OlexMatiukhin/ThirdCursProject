using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.Services;
using MongoDB.Bson;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Airport.ViewModels.QueriesViewModel
{
    public class Query2ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Seat> _seats;
        private readonly SeatService _seatService;
        private string _flightId;
        private DateTime _departureDate;
        private string _routeNumber;
        private decimal _price;
        private int _departureHour;
        private int _departureMinute;

        private User _user;


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

        public ObservableCollection<Seat> Seats
        {
            get => _seats;
            set
            {
                if (_seats != value)
                {
                    _seats = value;
                    OnPropertyChanged(nameof(Seats));
                }
            }
        }

        public string FlightId
        {
            get => _flightId;
            set
            {
                _flightId = value;
                OnPropertyChanged(nameof(FlightId));
            }
        }

        public DateTime DepartureDate
        {
            get => _departureDate;
            set
            {
                _departureDate = value;
                OnPropertyChanged(nameof(DepartureDate));
            }
        }

        public string RouteNumber
        {
            get => _routeNumber;
            set
            {
                _routeNumber = value;
                OnPropertyChanged(nameof(_routeNumber));
            }
        }

 
        public decimal Price
        {
            get => _price;
            private set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        private string _priceText;
        public string PriceText
        {
            get => _priceText;
            set
            {
                _priceText = value;
                OnPropertyChanged(nameof(PriceText));

                if (decimal.TryParse(_priceText, out decimal parsedPrice))
                {
                    Price = parsedPrice;
                }
                else
                {
                    MessageBox.Show("Некорректний ввід!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

         
        public int DepartureHour
        {
            get => _departureHour;
            private set
            {
                if (_departureHour != value)
                {
                    _departureHour = value;
                    OnPropertyChanged(nameof(DepartureHour));
                }
            }
        }

        private string _departureHourText;
        public string DepartureHourText
        {
            get => _departureHourText;
            set
            {
                _departureHourText = value;
                OnPropertyChanged(nameof(DepartureHourText));

                if (int.TryParse(_departureHourText, out int parsedHour) && parsedHour >= 0 && parsedHour < 24)
                {
                    DepartureHour = parsedHour;
                }
                else
                {
                    MessageBox.Show("Некорректний ввід!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
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

        public int DepartureMinute
        {
            get => _departureMinute;
            private set
            {
                if (_departureMinute != value)
                {
                    _departureMinute = value;
                    OnPropertyChanged(nameof(DepartureMinute));
                }
            }
        }

        private string _departureMinuteText;
        public string DepartureMinuteText
        {
            get => _departureMinuteText;
            set
            {
                _departureMinuteText = value;
                OnPropertyChanged(nameof(DepartureMinuteText));

                if (int.TryParse(_departureMinuteText, out int parsedMinute) && parsedMinute >= 0 && parsedMinute < 60)
                {
                    DepartureMinute = parsedMinute;
                }
                else
                {
                    MessageBox.Show("Некорректний ввід!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        public ICommand DoQuery { get; }

        private readonly IWindowService _windowService;

        public Query2ViewModel(IWindowService windowService, User user)
        {
            _windowService = windowService;
            _seatService = new SeatService();
            DoQuery = new RelayCommand(OnDoQuery);
            /* Login = _user.Login;
                       AccessRight = _user.AccessRight;*/
            //AccessRight = _user.AccessRight;
        }

        public void OnDoQuery(object parameter)
        {
            if (!string.IsNullOrEmpty(SelectedQueryType))
            {
                if (SelectedQueryType != "кількість")
                {

                    if (ObjectId.TryParse(FlightId, out var flightObjectId) && RouteNumber != null && RouteNumber != "")
                    {
                        Seats = new ObservableCollection<Seat>(
                            _seatService.GetFilteredSeats(flightObjectId, DepartureDate, RouteNumber, Price, DepartureHour, DepartureMinute)
                        );
                    }
                    else
                    {

                        MessageBox.Show("Неправельні дані для запиту.", "Помилка", MessageBoxButton.OK);
                    }
                }
                else
                {

                    if (ObjectId.TryParse(FlightId, out var flightObjectId) && RouteNumber != null&&RouteNumber!="")
                    {
                        var seatCount = _seatService.GetFilteredSeatsCount(flightObjectId, DepartureDate, RouteNumber, Price, DepartureHour, DepartureMinute);
                        MessageBox.Show($"{seatCount}", "Результат", MessageBoxButton.OK);
                    }
                    else
                    {
                        MessageBox.Show("Неправельні дані для запиту.", "Помилка", MessageBoxButton.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("Оберіть тип запиту.", "Помилка", MessageBoxButton.OK);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

