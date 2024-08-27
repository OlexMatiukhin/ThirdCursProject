using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public  class CompletedFlight
    {
        [BsonId] 
        
        public ObjectId Id { get; set; }

        [BsonElement("completedFlightId")]
        public int CompletedFlightId { get; set; }

        [BsonElement("flightNumber")]
        public string FlightNumber { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("dispatchBrigadeId")]
        public int DispatchBrigadeId { get; set; }

        [BsonElement("navigationBrigadeId")]
        public int NavigationBrigadeId { get; set; }

        [BsonElement("dateDeparture")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DateDeparture { get; set; }

        [BsonElement("dateArrival")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime DateArrival { get; set; }

        [BsonElement("flightBrigadeId")]
        public int FlightBrigadeId { get; set; }

        [BsonElement("inspectionBrigadeId")]
        public int InspectionBrigadeId { get; set; }

        [BsonElement("routeId")]
        public int RouteId { get; set; }
    }
}
