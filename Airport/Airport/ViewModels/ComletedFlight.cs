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
    public class CompletedFlightsViewModel
    {
        public ObservableCollection<CompletedFlight> CompletedFlights { get; set; }
        private CompletedFlightService _completedFlightService;

        public CompletedFlightsViewModel()
        {
            _completedFlightService = new CompletedFlightService();
            LoadCompletedFlights();
        }

        private void LoadCompletedFlights()
        {
            try
            {
                var completedFlightList = _completedFlightService.GetCompletedFlightsData();
                CompletedFlights = new ObservableCollection<CompletedFlight>(completedFlightList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}