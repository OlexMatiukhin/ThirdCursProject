using Airport.Command.AddDataCommands;
using Airport.Models;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddRouteViewModel : INotifyPropertyChanged
    {

        private AddRouteCommand _addRouteCommand;
        public AddRouteCommand AddRouteCommand
        {
            get => _addRouteCommand;
            set
            {
                _addRouteCommand = value;


            }
        }





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

        


        public AddRouteViewModel()
        {

            _addRouteCommand = new AddRouteCommand(this);
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





    }
}

