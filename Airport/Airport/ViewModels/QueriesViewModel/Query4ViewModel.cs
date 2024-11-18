using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace Airport.ViewModels.QueriesViewModel
{
    public class Query4ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PassengerCompletedFlight> _passengersCompletedFlight;
        private readonly PassengerCompletedFlightService _passengerCompletedFlightService;

        public ObservableCollection<PassengerCompletedFlight> PassengersCompletedFlight
        {
            get => _passengersCompletedFlight;
            set
            {
                if (_passengersCompletedFlight != value)
                {
                    _passengersCompletedFlight = value;
                    OnPropertyChanged(nameof(PassengersCompletedFlight));
                }
            }
        }

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

        private string _flightCategory;
        private string _baggageStatus;
        private string _gender;
        private DateTime _startDate;
        private DateTime _endDate;

        public string FlightCategory
        {
            get => _flightCategory;
            set
            {
                _flightCategory = value;
                OnPropertyChanged(nameof(FlightCategory));
            }
        }

        public string BaggageStatus
        {
            get => _baggageStatus;
            set
            {
                _baggageStatus = value;
                OnPropertyChanged(nameof(BaggageStatus));
            }
        }

        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        private int _minAge;
        public int MinAge
        {
            get => _minAge;
            set
            {
                _minAge = value;
                OnPropertyChanged(nameof(MinAge));
            }
        }

        private string _minAgeText;
        public string MinAgeText
        {
            get => _minAgeText;
            set
            {
                if (_minAgeText != value)
                {
                    _minAgeText = value;
                    OnPropertyChanged(nameof(MinAgeText));


                    if (int.TryParse(_minAgeText, out int parsedValue))
                    {
                        MinAge = parsedValue;
                    }
                    else
                    {
                        MessageBox.Show("Неправельний ввід", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        public ICommand DoQuery { get; }

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






        public Query4ViewModel(IWindowService windowService, User user)
        {
            _windowService = windowService;
            _passengerCompletedFlightService = new PassengerCompletedFlightService();
            DoQuery = new RelayCommand(OnDoQuery);

            Login = _user.Login;
            AccessRight = _user.AccessRight;
            LogoutCommand = new RelayCommand(OnLogoutCommand);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);


        }

        public void OnDoQuery(object parameter)
        {
            if (SelectedQueryType != "кількість")
            {
                PassengersCompletedFlight = new ObservableCollection<PassengerCompletedFlight>(
                    _passengerCompletedFlightService.GetFilteredPassengers(StartDate,EndDate, FlightCategory, BaggageStatus, Gender, MinAge));

            }
            else
            {
                var result = _passengerCompletedFlightService.GetFilteredPassengerCount(StartDate, EndDate,FlightCategory, BaggageStatus,  Gender, MinAge);
                MessageBox.Show($"{result}", "Результат", MessageBoxButton.OK);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


