using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.ChangeDataViewModel
{

    class ChangeRouteViewModel
    {
       
            private readonly RouteService _routeService;

            public ICommand ChangeRouteCommand { get; }
            private IWindowService _windowService;
            private Route _route;
            public string _number;
            private string _departurePoint;
            private string _arrivalPoint;
            private string _transitAirport;
            private string _flightDirection;


            public string Number
            {
                get => _number;
                set
                {
                    _number = value;
                    OnPropertyChanged(nameof(Number));
                }
            }

            public string DeparturePoint
            {
                get => _departurePoint;
                set
                {
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
                set
                {
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

        private bool ValidateInputs()
        {
       
            if (string.IsNullOrWhiteSpace(Number))
            {
                return false;
            }

      
            if (string.IsNullOrWhiteSpace(DeparturePoint))
            {
                return false;
            }

           
            if (string.IsNullOrWhiteSpace(ArrivalPoint))
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(TransitAirport) && string.IsNullOrWhiteSpace(TransitAirport))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(FlightDirection))
            {
                return false;
            }

            return true;
        }



        public ChangeRouteViewModel(Route route, IWindowService windowService)
            {
                this._windowService = windowService;
                this._route = route;
                _routeService = new RouteService();
                ChangeRouteCommand = new RelayCommand(ExecuteChangeRoute, canExecute => true);
                this.Number= route.Number;
                this.DeparturePoint = route.DeparturePoint;
                this.ArrivalPoint = route.ArrivalPoint;
                this.TransitAirport = route.TransitAirport;
                this.FlightDirection = route.FlightDirection;
            }

            private void ExecuteChangeRoute(object parameter)
            {
                if (ValidateInputs())
                {
                    _route.Number = Number;
                    _route.DeparturePoint = DeparturePoint;
                    _route.ArrivalPoint = ArrivalPoint;
                    _route.TransitAirport = TransitAirport;
                    _route.FlightDirection = FlightDirection;
                    _routeService.UpdateRoute(_route);
                System.Windows.MessageBox.Show("Об'єкт успішно змінено!");
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
