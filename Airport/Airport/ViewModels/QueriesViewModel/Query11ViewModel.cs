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
    public class Query11ViewModel : INotifyPropertyChanged
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
        private string _flightIdString;
        public string FlightIdString
        {
            get => _flightIdString;
            set
            {
                _flightIdString = value;
                OnPropertyChanged(nameof(FlightIdString));
            }
        }





        private WorkerService _workerService;






        private readonly IWindowService _windowService;
        public Query11ViewModel(IWindowService windowService, User user)
        {
            _windowService = windowService;
            _workerService = new WorkerService();

            _userService = new UserService();
            _user = user;
            /* Login = _user.Login;
                          AccessRight = _user.AccessRight;*/
            DoQuery = new RelayCommand(OnDoQuery);


        }


        public void OnDoQuery(object parameter)
        {
          
            if (string.IsNullOrWhiteSpace(FlightIdString))
            {
                MessageBox.Show("Некоректний ввід.", "Помилка",MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }

            if (!ObjectId.TryParse(FlightIdString, out ObjectId flightId))
            {
                MessageBox.Show("Некоректний ввід.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

          
            Workers = new ObservableCollection<Worker>(_workerService.GetWorkersByFlightId(flightId));
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

