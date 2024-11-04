using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Airport.ViewModels.WindowViewModels
{
    public class CompletedFlightsViewModel
    {
        public ObservableCollection<CompletedFlight> CompletedFlights { get; set; }
        private CompletedFlightService _completedFlightService;
        private readonly IWindowService _windowService;
        public CompletedFlightsViewModel( IWindowService _windowService)
        {
            _completedFlightService = new CompletedFlightService();
            LoadCompletedFlights();
            this._windowService = _windowService;
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