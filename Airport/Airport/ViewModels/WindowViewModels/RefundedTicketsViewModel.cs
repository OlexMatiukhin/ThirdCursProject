using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.ViewModels.WindowViewModels
{
    


    public class RefundedTicketsViewModel
    {
        public ObservableCollection<RefundedTicketInfo> RefundedTickets { get; set; }
        private RefundedTicketService _ticketService;
        private IWindowService _windowService;
        public RefundedTicketsViewModel(IWindowService windowService)
        {
            this._windowService = windowService;

            _ticketService = new RefundedTicketService();
            LoadTickets();
        }

        private void LoadTickets()
        {
            try
            {
                var ticketList = _ticketService.GetRefundedTicketsData();
                RefundedTickets = new ObservableCollection<RefundedTicketInfo>(ticketList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
