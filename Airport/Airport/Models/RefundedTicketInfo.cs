using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class RefundedTicketInfo
    {
        private int refundedTicketId;
        private DateTime date;
        private int routeId;
        private int age;
        private decimal price;
        private string gender;
        private string fullname;
        private int ticketId;
        private int flightId;

        public RefundedTicketInfo(int refundedTicketId, DateTime date, int routeId, int age, decimal price, string gender, string fullname, int ticketId, int flightId)
        {
            this.refundedTicketId = refundedTicketId;
            this.date = date;
            this.routeId = routeId;
            this.age = age;
            this.price = price;
            this.gender = gender;
            this.fullname = fullname;
            this.ticketId = ticketId;
            this.flightId = flightId;
        }

        public int RefundedTicketId { get => refundedTicketId; set => refundedTicketId = value; }
        public DateTime Date { get => date; set => date = value; }
        public int RouteId { get => routeId; set => routeId = value; }
        public int Age { get => age; set => age = value; }
        public decimal Price { get => price; set => price = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public int TicketId { get => ticketId; set => ticketId = value; }
        public int FlightId { get => flightId; set => flightId = value; }
    }
}
