using Airport.Command.AddDataCommands;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{


    
    public class AddRouteViewModel : INotifyPropertyChanged
    {
        private IWindowService _windowService;
        private readonly RouteService _routeService;

        public ICommand AddRouteCommand { get; }







        public string _number;
        private string _departurePoint;

        private string _arrivalPoint;
        private string _transitAirport;
        private string _flightDirection;


        public string Number
        {
            get => _number;
            set {
                _number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        public string DeparturePoint
        {
            get => _departurePoint;
            set {
                _departurePoint = value;
                OnPropertyChanged(nameof(DeparturePoint));
            }
        }

        public string ArrivalPoint
        {
            get => _arrivalPoint;
            set
            {
                _arrivalPoint = value;
                OnPropertyChanged(nameof(ArrivalPoint));
            }
        }

        public string TransitAirport
        {
            get => _transitAirport;
            set {
                _transitAirport = value;
                OnPropertyChanged(nameof(TransitAirport));
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




        public AddRouteViewModel(IWindowService windowService)
        {
                
            _routeService = new RouteService();
            this._windowService = windowService;
            AddRouteCommand = new RelayCommand(ExecuteAddRoute, canExecute => true);
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(Number))
            {
                MessageBox.Show("Номер маршруту не може бути порожнім.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(DeparturePoint))
            {
                MessageBox.Show("Точка відправлення не може бути порожньою.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(ArrivalPoint))
            {
                MessageBox.Show("Точка прибуття не може бути порожньою.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(FlightDirection))
            {
                MessageBox.Show("Напрямок польоту не може бути порожнім.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
        private void ExecuteAddRoute(object parameter)
        {
            if (ValidateInputs()) { 
                var newRoute = new Route
                {

                    Number = Number,
                    DeparturePoint = DeparturePoint,
                    ArrivalPoint = ArrivalPoint,
                    TransitAirport = TransitAirport,
                    FlightDirection = FlightDirection
                };
                MessageBox.Show("Об'єкт упішно додано!");
                _windowService.CloseModalWindow();
            }
        } 
    


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





    }
}

