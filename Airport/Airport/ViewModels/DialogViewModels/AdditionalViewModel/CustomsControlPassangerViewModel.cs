using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Numerics;
using System.Windows;

namespace Airport.ViewModels.DialogViewModels.AdditionalViewModel
{
   public class PassengersViewModel
    {
       
            public ObservableCollection<Passenger> Passengers { get; set; }
            private PassengerService _passengerService;
            private TicketService ticketService;
            private int _flightId;

            public ICommand CheckPassangerCommand { get; }
            private readonly IWindowService _windowService;

            public PassengersViewModel(Flight flight)
            {
                _passengerService = new PassengerService();
                CheckPassangerCommand = new RelayCommand(OnCheckPassanger);
                _windowService = new WindowService();
                LoadPassengers();
                _flightId=flight.FlightId;


            }
              


            private void OnCheckPassanger(object parameter)
            {

                var passanger = parameter as Passenger;
                Ticket ticket = ticketService.GetTicketByPassangerId(passanger.FlightId);
                if (passanger != null&& ticket.Status=="проданий")
                {

                     MessageBoxResult result = MessageBox.Show(
                     "Допустити пасажира?",
                     "Митна перевірка",
                     MessageBoxButton.YesNo,
                     MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        passanger.CustomsControlsStatus = "допущений";

                        _passengerService.UpdatePassenger(passanger);

                        MessageBox.Show("Перевірку пасажира завершено!", "Успішний результат", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        passanger.CustomsControlsStatus = "не допущений";

                        _passengerService.UpdatePassenger(passanger);

                        MessageBox.Show("Пасажира не допущено до рейсу!", "Успішний результат", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
    
                }
            }


            private void LoadPassengers()
            {
                try
                {
                    var passengerList = _passengerService.GetPassengersByFlightId(_flightId);
                    Passengers = new ObservableCollection<Passenger>(passengerList);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
            }
   }
}
