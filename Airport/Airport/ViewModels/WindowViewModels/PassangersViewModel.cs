using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Airport.ViewModels.WindowViewModels
{



    public class PassengersViewModel
    {
        public ObservableCollection<Passenger> Passengers { get; set; }
        private PassengerService _passengerService;
        public ICommand OpenEditWindowCommand { get; }
        private readonly IWindowService _windowService;

        public PassengersViewModel()
        {
            _passengerService = new PassengerService();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            _windowService = new WindowService();
            LoadPassengers();
        }
        private void OnEdit(object parameter)
        {

            var passanger = parameter as Passenger;
            if (passanger != null)
            {
                _windowService.OpenWindow("ChangePilotMedExam", passanger);
                _windowService.CloseWindow();

            }




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
