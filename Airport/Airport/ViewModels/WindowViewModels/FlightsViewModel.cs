using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using Airport.ViewModels.DialogViewModels.AddDataViewModel;
using Airport.Views.Dialog.ChangeWindow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace Airport.ViewModels.WindowViewModels
{
    
    public class FlightsViewModel
    {
        public ObservableCollection<Flight> Flights { get; set; }
        private FlightService _flightService;

        public ICommand OpenEditWindowCommand { get; }
        private readonly IWindowService _windowService;

     

        public FlightsViewModel(IWindowService windowService)
        {
             this._windowService = windowService;
            _flightService = new FlightService();

            OpenEditWindowCommand = new RelayCommand(OnEdit);
            LoadFlights();
        }
        private Flight _selectedFlight;

        public Flight SelectedFlight
        {
            get => _selectedFlight;
            set
            {
                _selectedFlight = value;
                OnPropertyChanged(nameof(SelectedFlight));
                
            }
        }
        private void OnEdit(object parameter)
        {
            
            var flight = parameter as Flight;
            if (flight != null)
            {
                _windowService.OpenModalWindow("ChangeFlight", flight);
               

            }
            



        }

        private void EndCustomControl(object parameter)
        {


            var flight = parameter as Flight;
            if (flight != null)
            {
                _flightService.EndCustomControl( flight.FlightId);

            }
        }

        private void EndRegistration(object parameter)
        {


            var flight = parameter as Flight;
            if (flight != null) 
            { 
                _flightService.EndRegistration(flight.FlightId);

            }
        }

        private void LoadFlights()
        {
            try
            {
                var flightList = _flightService.GetFlightsData();
                Flights = new ObservableCollection<Flight>(flightList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}