using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Seat
    {
        private int seatId;
        private int number;
        private string status;
        private int flightId;

        public Seat(int seatId, int number, string status, int flightId)
        {
            this.seatId = seatId;
            this.number = number;
            this.status = status;
            this.flightId = flightId;
        }

        public int SeatId { get => seatId; set => seatId = value; }
        public int Number { get => number; set => number = value; }
        public string Status { get => status; set => status = value; }
        public int FlightId { get => flightId; set => flightId = value; }
    }


}
