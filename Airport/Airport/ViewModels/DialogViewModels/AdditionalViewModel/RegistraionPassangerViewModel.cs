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
using System.Windows;

namespace Airport.ViewModels.DialogViewModels.AdditionalViewModel
{
    

    public class RegistraionPassangerViewModel
    {

        public ObservableCollection<Passenger> Passengers { get; set; }
        private PassengerService _passengerService;
        private TicketService ticketService;
        private int _flightId;

        public ICommand RegestrationPassangerCommand { get; }
        private readonly IWindowService _windowService;

        public RegistraionPassangerViewModel(Flight flight)
        {
            _passengerService = new PassengerService();
            RegestrationPassangerCommand = new RelayCommand(OnRegestrationPassanger);
            _windowService = new WindowService();
            LoadPassengers();
            _flightId = flight.FlightId;


        }



        private void OnRegestrationPassanger(object parameter)
        {

            var passenger = parameter as Passenger;
            Ticket ticket = ticketService.GetTicketByPassangerId(passenger.FlightId);
            if (passenger != null && ticket.Status == "проданий" && passenger.CustomsControlsStatus == "допущений")
            {

                MessageBoxResult result = MessageBox.Show(
               "Зареєструвати пасажира на рейс?",
               "Митна перевірка",
               MessageBoxButton.YesNo,
               MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    passenger.CustomsControlsStatus = "зареєстрований";

                    _passengerService.UpdatePassenger(passenger);

                    MessageBox.Show("Реєстрацію пасажира завершено!", "Успішний результат", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {



                    MessageBox.Show("Пасажира не допущено до рейсу!", "", MessageBoxButton.OK, MessageBoxImage.Information);

                }

            }
            else
            {

                MessageBox.Show("Пасажира не може бути зареєстрований, оскільки не купив білет або не пройшов митну перевірку!", "", MessageBoxButton.OK, MessageBoxImage.Information);
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
