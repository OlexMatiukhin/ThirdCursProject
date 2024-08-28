using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{

    public class RefundedTicketInfo 
    {
        [BsonId]
       
        public string RefundedTicketId { get; set; }

        [BsonElement("date")] // Опционально: указывает на имя поля в MongoDB
        public DateTime Date { get; set; }

        [BsonElement("routeId")]
        public int RouteId { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("fullname")]
        public string Fullname { get; set; }

        [BsonElement("ticketId")]
        public int TicketId { get; set; }

        [BsonElement("flightId")]
        public int FlightId { get; set; }
    }

    /*public RefundedTicketInfo(int refundedTicketId, DateTime date, int routeId, int age, decimal price, string gender, string fullname, int ticketId, int flightId)
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
        }*/

        /*public int RefundedTicketId { get => refundedTicketId; set => refundedTicketId = value; }
        public DateTime Date { get => date; set => date = value; }
        public int RouteId { get => routeId; set => routeId = value; }
        public int Age { get => age; set => age = value; }
        public decimal Price { get => price; set => price = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public int TicketId { get => ticketId; set => ticketId = value; }
        public int FlightId { get => flightId; set => flightId = value; }*/
    
}
