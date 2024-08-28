using Airport.Models;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;

namespace Airport.ViewModels.WindowViewModels
{


    public class DelayedFlightsViewModel
    {
        public ObservableCollection<DelayedFlightInfo> DelayedFlights { get; set; }
        private DelayedFlightsService _delayedFlightsService;

        public DelayedFlightsViewModel()
        {
            _delayedFlightsService = new DelayedFlightsService();
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