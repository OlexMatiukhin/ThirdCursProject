using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Seat
    {
        [BsonId]
     
        public int SeatId { get; set; }

        [BsonElement("number")]
        public int Number { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("flightId")]
        public int FlightId { get; set; }


        /*public Seat(int seatId, int number, string status, int flightId)
        {
            this.seatId = seatId;
            this.number = number;
            this.status = status;
            this.flightId = flightId;
        }*/

        /* public int SeatId { get => seatId; set => seatId = value; }
         public int Number { get => number; set => number = value; }
         public string Status { get => status; set => status = value; }
         public int FlightId { get => flightId; set => flightId = value; }*/
    }


}
