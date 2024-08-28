using Airport.Models;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Airport.ViewModels.WindowViewModels
{
    public class FlightViewModel
    {
        public ObservableCollection<Flight> Flights { get; set; }
        private FlightService _flightService;

        public FlightViewModel()
        {
            _flightService = new FlightService();
            LoadFlights();
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
    }
}