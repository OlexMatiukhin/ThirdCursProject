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
    public class BiyngTicketViewModel
    {

        public ObservableCollection<Ticket> Tickets { get; set; }
      
        private TicketService _ticketService;
        private int _flightId;

        public ICommand buyTicketCommand { get; }
        private readonly IWindowService _windowService;

        public BiyngTicketViewModel(Flight flight)
        {
            _ticketService = new TicketService();
            buyTicketCommand = new RelayCommand(OnBuyingTicket);
            _windowService = new WindowService();
            LoadPassengers();
            _flightId = flight.FlightId;

        }



        private void OnBuyingTicket(object parameter)
        {

            var ticket = parameter as Ticket;
            
            if (ticket != null && ticket.Status != "проданий")
            {
               if(ticket.Status == "заброньований")
                {
                
                MessageBoxResult result = MessageBox.Show(
                $"Данний білте заброньований за пасажиром з id:{ticket.PassengerId}. Він бажає купити білет.",
                "Покупка заброньованого білету",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes) {
                        ticket.Status = "куплений";
                        _ticketService.UpdateTicket(ticket);          
                    }
                }
                else
                {
                    ticket.Status = "куплений";
                    _windowService.OpenModalWindow("AddPassanger",ticket);

                    
                }

            }
        }

        private void OnBookingTicket(object parameter)
        {
           
            var ticket = parameter as Ticket;

            if (ticket != null && ticket.Status != "проданий"&& ticket.Status!="заброньований")
            {
                ticket.Status = "заброньований";
            }
            else
            {
                
            }


        }






        private void LoadPassengers()
        {
            try
            {
                var ticketList = _ticketService.GetTicketsByFlightId(_flightId);
                Tickets = new ObservableCollection<Ticket>(ticketList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }

}
