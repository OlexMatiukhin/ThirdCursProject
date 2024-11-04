using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;

namespace Airport.ViewModels.WindowViewModels
{
    public class TicketsViewModel
    {
        public ObservableCollection<Ticket> Tickets { get; set; }
        private TicketService _ticketService;
        private PassengerService _passengerService;
        private IWindowService _windowService;
        public ICommand BuyTicketCommand { get; }
        public ICommand BookTicketCommand { get; }
        public TicketsViewModel(IWindowService windowService)
        {
            this._windowService = windowService;
            BuyTicketCommand = new RelayCommand(OnBuyingTicket);
            BookTicketCommand = new RelayCommand(OnBookingTicket);
            _ticketService = new TicketService();
            _passengerService=new PassengerService();
            LoadTickets();

        }

        private void OnBuyingTicket(object parameter)
        {

            var ticket = parameter as Ticket;

            if (ticket != null && ticket.Status != "проданий")
            {
                if (ticket.Status == "заброньований")
                {

                    MessageBoxResult result = MessageBox.Show(
                    $"Данний білте заброньований за пасажиром з id:{ticket.PassengerId}. Він бажає купити білет.",
                    "Покупка заброньованого білету",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        ticket.Status = "куплений";
                        _ticketService.UpdateTicket(ticket);
                    }
                }
                else
                {
                    ticket.Status = "куплений";
                    _windowService.OpenModalWindow("AddPassangerViewModel", ticket);


                }

            }
        }

        private void OnBookingTicket(object parameter)
        {

            var ticket = parameter as Ticket;

            if (ticket != null && ticket.Status != "проданий" && ticket.Status != "заброньований")
            {
                ticket.Status = "заброньований";
                _windowService.OpenModalWindow("AddPassangerViewModel", ticket);
;
            }
          


        }


        private void OnTicketReturn(object parameter)
        {
          

            var ticket = parameter as Ticket;

            if (ticket != null && ticket.Status == "проданий" && ticket.Status == "заброньований")
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Ви точно хочете повернути білет",
                    "Повернення білету",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes) {

                    ticket.Status = "доступний";
                    _passengerService.DeletePassenger(ticket.PassengerId);
                    ticket.PassengerId = 0;

                    
                }
                
                
            }



        }
        private void LoadTickets()
        {
            try
            {
                var ticketList = _ticketService.GetTicketsData();
                Tickets = new ObservableCollection<Ticket>(ticketList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}