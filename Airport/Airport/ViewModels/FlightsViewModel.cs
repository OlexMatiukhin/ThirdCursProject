using Airport.Models;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.ViewModels
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