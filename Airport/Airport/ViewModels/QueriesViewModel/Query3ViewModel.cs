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
using System.Numerics;

namespace Airport.ViewModels.QueriesViewModel
{
    public class Query3ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<AirPlane> _planes;
        private readonly PlaneService _planeService;
        private string _flightId;
        private DateTime _departureDate;
        private string _routeId;
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

        public ObservableCollection<AirPlane> Planes
        {
            get => _planes;
            set
            {
                if (_planes != value)
                {
                    _planes = value;
                    OnPropertyChanged(nameof(Planes));
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


        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }

        private string _assigned;
        public string Assigned
        {
            get => _assigned;
            set
            {
                if (_assigned != value)
                {
                    _assigned = value;
                    OnPropertyChanged(nameof(Assigned));
                }
            }
        }

        private string _status;
        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        private ObservableCollection<Plane> _flights;
        public ObservableCollection<Plane> Flights
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





        public ICommand DoQuery { get; }

        private readonly IWindowService _windowService;

        public Query3ViewModel(IWindowService windowService, User user)
        {
            _windowService = windowService;
            _planeService = new PlaneService();
            _user = user;
            DoQuery = new RelayCommand(OnDoQuery);
            Login = _user.Login;
            AccessRight = _user.AccessRight;
            LogoutCommand = new RelayCommand(OnLogoutCommand);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);


        }

        public void OnDoQuery(object parameter)
        {
         
            if (string.IsNullOrEmpty(SelectedQueryType))
            {
                MessageBox.Show("Оберіть тип.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

           
            if (StartDate > EndDate)
            {
                MessageBox.Show("Дата початку неможе бути пізніше кінцевої дати.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

         
            if (string.IsNullOrEmpty(Assigned))
            {
                MessageBox.Show("Будь ласка оберіть приписку.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

    
            if (string.IsNullOrEmpty(Status))
            {
                MessageBox.Show("Будь ласка введть статус.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

      
            if (SelectedQueryType != "кількість")
            {
               
                Planes = new ObservableCollection<AirPlane>(_planeService.GetPlanesWithFlightsAndRepair(StartDate, EndDate, Assigned, Status));
            }
            else
            {          
                var result = _planeService.GetPlanesCountWithFlightsAndRepair(StartDate, EndDate, Assigned, Status);
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
