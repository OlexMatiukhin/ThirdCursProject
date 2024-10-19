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

        public PassengersViewModel(IWindowService _windowService)
        {
            _passengerService = new PassengerService();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            _windowService = new WindowService();
            this._windowService=_windowService;
            LoadPassengers();
        }
        private void OnEdit(object parameter)
        {

            var passanger = parameter as Passenger;
            if (passanger != null)
            {
                _windowService.OpenModalWindow("ChangePilotMedExam", passanger);         

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
