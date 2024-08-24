using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Ticket
    {
        private int ticketId;
        private string status;
        private bool availability;
        private DateTime dateChanges;
        private decimal price;
        private int flightId;
        private int seatId;
        private int passengerId;

        public Ticket(int ticketId, string status, bool availability, DateTime dateChanges, decimal price, int flightId, int seatId, int passengerId)
        {
            this.ticketId = ticketId;
            this.status = status;
            this.availability = availability;
            this.dateChanges = dateChanges;
            this.price = price;
            this.flightId = flightId;
            this.seatId = seatId;
            this.passengerId = passengerId;
        }

        public int TicketId { get => ticketId; set => ticketId = value; }
        public string Status { get => status; set => status = value; }
        public bool Availability { get => availability; set => availability = value; }
        public DateTime DateChanges { get => dateChanges; set => dateChanges = value; }
        public decimal Price { get => price; set => price = value; }
        public int FlightId { get => flightId; set => flightId = value; }
        public int SeatId { get => seatId; set => seatId = value; }
        public int PassengerId { get => passengerId; set => passengerId = value; }
    }
}
