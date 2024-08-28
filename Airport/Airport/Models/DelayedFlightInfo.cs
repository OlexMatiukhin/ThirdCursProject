using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class DelayedFlightInfo
    {
        [BsonId]

     
        public int DelayedFlightInfoId { get; set; } // Идентификатор документа в MongoDB

        [BsonElement("flightNumber")]
        public string FlightNumber { get; set; }
    

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("dispatchBrigadeId")]
        public int DispatchBrigadeId { get; set; }

        [BsonElement("navigationBrigadeId")]
        public int NavigationBrigadeId { get; set; }

        [BsonElement("flightBrigadeId")]
        public int FlightBrigadeId { get; set; }

        [BsonElement("newDateDeparture")]
        public DateTime NewDateDeparture { get; set; }

        [BsonElement("newDateArrival")]
        public DateTime NewDateArrival { get; set; }

        [BsonElement("inspectionBrigadeId")]
        public int InspectionBrigadeId { get; set; }

        [BsonElement("reason")]
        public string Reason { get; set; }

        [BsonElement("flightId")]
        public int FlightId { get; set; }

        [BsonElement("routeId")]
        public int RouteId { get; set; }

        [BsonElement("workerId")]
        public int WorkerId { get; set; }
  

        /*public DelayedFlightInfo(string flightNumber, string category, int dispatchBrigadeId, int navigationBrigadeId, int flightBrigadeId, DateTime newDateDeparture, DateTime newDateArrival, int inspectionBrigadeId, string reason, int flightId, int routeId, int workerId)
        {
            this.flightNumber = flightNumber;
            this.category = category;
            this.dispatchBrigadeId = dispatchBrigadeId;
            this.navigationBrigadeId = navigationBrigadeId;
            this.flightBrigadeId = flightBrigadeId;
            this.newDateDeparture = newDateDeparture;
            this.newDateArrival = newDateArrival;
            this.inspectionBrigadeId = inspectionBrigadeId;
            this.reason = reason;
            this.flightId = flightId;
            this.routeId = routeId;
            this.workerId = workerId;
        }

        public string FlightNumber { get => flightNumber; set => flightNumber = value; }
        public string Category { get => category; set => category = value; }
        public int DispatchBrigadeId { get => dispatchBrigadeId; set => dispatchBrigadeId = value; }
        public int NavigationBrigadeId { get => navigationBrigadeId; set => navigationBrigadeId = value; }
        public int FlightBrigadeId { get => flightBrigadeId; set => flightBrigadeId = value; }
        public DateTime NewDateDeparture { get => newDateDeparture; set => newDateDeparture = value; }
        public DateTime NewDateArrival { get => newDateArrival; set => newDateArrival = value; }
        public int InspectionBrigadeId { get => inspectionBrigadeId; set => inspectionBrigadeId = value; }
        public string Reason { get => reason; set => reason = value; }
        public int FlightId { get => flightId; set => flightId = value; }
        public int RouteId { get => routeId; set => routeId = value; }
        public int WorkerId { get => workerId; set => workerId = value; }
    }*/

    }
}

