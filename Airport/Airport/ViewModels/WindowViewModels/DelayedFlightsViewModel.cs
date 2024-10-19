using Airport.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;
using Airport.Services.MongoDBSevice;
using Airport.Services;

namespace Airport.ViewModels.WindowViewModels
{


    public class DelayedFlightsViewModel
    {
        private readonly IWindowService _windowService;
        
        public ObservableCollection<DelayedFlightInfo> DelayedFlights { get; set; }
        private DelayedFlightsService _delayedFlightsService;

        public DelayedFlightsViewModel(IWindowService _windowService)
        {
            _delayedFlightsService = new DelayedFlightsService();
            this._windowService = _windowService;
            LoadDelayedFlights();
        }

        private void LoadDelayedFlights()
        {
            try
            {
                var delayedFlightsList = _delayedFlightsService.GetDelayedFlightsData();
                DelayedFlights = new ObservableCollection<DelayedFlightInfo>(delayedFlightsList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}