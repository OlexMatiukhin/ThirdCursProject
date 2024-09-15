using Airport.Models;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.ViewModels.WindowViewModels
{
    public class FlightsViewModel
    {
        public ObservableCollection<Flight> Flights { get; set; }
        private FlightService _flightService;

        public FlightsViewModel()
        {
            _flightService = new FlightService();
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