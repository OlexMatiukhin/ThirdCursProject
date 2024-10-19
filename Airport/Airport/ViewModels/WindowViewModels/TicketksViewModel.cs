using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;

namespace Airport.ViewModels.WindowViewModels
{
    public class TicketsViewModel
    {
        public ObservableCollection<Ticket> Tickets { get; set; }
        private TicketService _ticketService;
        private IWindowService _windowService;
        public TicketsViewModel(IWindowService windowService)
        {
            this._windowService = windowService;

            _ticketService = new TicketService();
            LoadTickets();
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