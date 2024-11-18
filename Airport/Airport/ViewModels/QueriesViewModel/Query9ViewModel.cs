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

    public class Query9ViewModel : INotifyPropertyChanged
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

        private string _planeType;
        public string PlaneType
        {
            get => _planeType;
            set
            {
                if (_planeType != value)
                {
                    _planeType = value;
                    OnPropertyChanged(nameof(PlaneType));
                }
            }
        }






        private FlightService _flightService;


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
        public Query9ViewModel(IWindowService windowService, User user)
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




        public void OnDoQuery(object paramter)
        {
            if(PlaneType!=null&& PlaneType != "")
            {
                Flights = new ObservableCollection<Flight>(_flightService.GetFlightsByPlaneType(PlaneType));
            }


         



        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

