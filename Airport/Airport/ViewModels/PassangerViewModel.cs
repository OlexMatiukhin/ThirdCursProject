using Airport.Models;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Airport.ViewModels
{
   

    
        public class PassengersViewModel
        {
            public ObservableCollection<Passenger> Passengers { get; set; }
            private PassengerService _passengerService;

            public PassengersViewModel()
            {
                _passengerService = new PassengerService();
                LoadPassengers();
            }

            private void LoadPassengers()
            {
                try
                {
                    var passengerList = _passengerService.GetPassengersData();
                    Passengers = new ObservableCollection<Passenger>(passengerList);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
            }
        }
    
}
