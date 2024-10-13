using Airport.Models;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.ViewModels.WindowViewModels
{
    class CanceledFligthsViewModel
    {
        public ObservableCollection<CanceledFlightInfo> CanceledFlights { get; set; }
        private CanceledFlightsService _canceledeFlightsService;

        public CanceledFligthsViewModel()
        {
            _canceledeFlightsService = new CanceledFlightsService();
            LoadCanceledFlights();
        }

        private void LoadCanceledFlights()
        {
            try
            {
                var canceldFlightsList = _canceledeFlightsService.GetCanceledFlightsData();
                CanceledFlights = new ObservableCollection<CanceledFlightInfo>(canceldFlightsList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}