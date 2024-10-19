using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{

    public class Flight
    {
        [BsonId]
        public int FlightId { get; set; }

        [BsonElement("flightNumber")]
        public string FlightNumber { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("category")]
        public string Category { get; set; }

        [BsonElement("dateDeparture")]
        public DateTime DateDeparture { get; set; }

        [BsonElement("dateArrival")]
        public DateTime DateArrival { get; set; }

        [BsonElement("planeId")]
        public int PlaneId { get; set; }

        [BsonElement("dispatchBrigadeId")]
        public int DispatchBrigadeId { get; set; }

        [BsonElement("navigationBrigadeId")]
        public int NavigationBrigadeId { get; set; }

        [BsonElement("flightBrigadeId")]
        public int FlightBrigadeId { get; set; }

        [BsonElement("inspectionBrigadeId")]
        public int InspectionBrigadeId { get; set; }



        [BsonElement("customsControl")]
        public bool CustomsControl { get; set; } = false;

        [BsonElement("passengerRegistration")]
        public bool PassengerRegistration { get; set; } = false;

        [BsonElement("numberTickets")]
        public int NumberTickets { get; set; } = 0; 

        [BsonElement("numberBoughtTickets")]
        public int NumberBoughtTickets { get; set; } = 0;

        [BsonElement("routeId")]
        public int RouteId { get; set; }

        public override string ToString()
        {
            return $"Flight ID: {FlightId}, Flight Number: {FlightNumber}, Status: {Status}, " +
                   $"Category: {Category}, Departure: {DateDeparture}, Arrival: {DateArrival}, " +
                   $"Plane ID: {PlaneId}, Dispatch Brigade ID: {DispatchBrigadeId}, " +
                   $"Navigation Brigade ID: {NavigationBrigadeId}, Flight Brigade ID: {FlightBrigadeId}, " +
                   $"Inspection Brigade ID: {InspectionBrigadeId}, Route ID: {RouteId}, " +
                   $"Customs Control: {CustomsControl}, Passenger Registration: {PassengerRegistration}, " +
                   $"Number of Tickets: {NumberTickets}, Number of Bought Tickets: {NumberBoughtTickets}";
        }



    }
}
