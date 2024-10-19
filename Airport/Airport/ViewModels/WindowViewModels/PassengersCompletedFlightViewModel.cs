using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Airport.ViewModels.WindowViewModels
{


   

    public class PassengersCompletedFlightViewModel
    {
        public ObservableCollection<PassengerCompletedFlight> Passengers { get; set; }
        private PassengerCompletedFlightService _passengerService;

        private IWindowService _windowService;
        public PassengersCompletedFlightViewModel(IWindowService _windowService)
        {
            _passengerService = new PassengerCompletedFlightService();
            this._windowService = _windowService;
            LoadPassengers();
        }

        private void LoadPassengers()
        {
            try
            {
                var passengerList = _passengerService.GetPassengerCompletedFlightsData();
                Passengers = new ObservableCollection<PassengerCompletedFlight>(passengerList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }

}
