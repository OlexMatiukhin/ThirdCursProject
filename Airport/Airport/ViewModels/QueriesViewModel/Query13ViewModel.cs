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
    public class Query13ViewModel : INotifyPropertyChanged
    {


        private ObservableCollection<DelayedFlightInfo> _delayedFlights;


        private User _user;
        public ICommand DoQuery { get; }

        private string _reason;
        private string _routeNumber;
        private readonly DelayedFlightsService _delayedFlightsService;
        public ObservableCollection<DelayedFlightInfo> DelayedFlights
        {
            get => _delayedFlights;
            set
            {
                _delayedFlights = value;
                OnPropertyChanged(nameof(DelayedFlights));
            }
        }




        public string Reason
        {
            get => _reason;
            set
            {
                _reason = value;
                OnPropertyChanged(nameof(Reason));
            }
        }

        public string RouteNumber
        {
            get => _routeNumber;
            set
            {
                _routeNumber = value;
                OnPropertyChanged(nameof(RouteNumber));
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
        public Query13ViewModel(IWindowService windowService, User user)
        {
            _windowService = windowService;
             _delayedFlightsService= new DelayedFlightsService();

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

            if (string.IsNullOrWhiteSpace(RouteNumber)|| string.IsNullOrWhiteSpace(Reason))
            {
                MessageBox.Show("Некоректний ввід.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }        


            DelayedFlights = new ObservableCollection<DelayedFlightInfo>(_delayedFlightsService.GetDelayedFlightsByReasonAndRoute(Reason, RouteNumber));
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

