using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Route
    {

        [BsonId]
    
        public int RouteId { get; set; }

        [BsonElement("number")]
        public string Number { get; set; }

        [BsonElement("departurePoint")]
        public string DeparturePoint { get; set; }

        [BsonElement("arrivalPoint")]
        public string ArrivalPoint { get; set; }

        [BsonElement("transitAirport")]
        public string TransitAirport { get; set; }

        [BsonElement("flightDirection")]
        public string FlightDirection { get; set; }

        /* public Route(int routeId, string number, string departurePoint, string arrivalPoint, string transitAirport, string flightDirection)
     {
         this.routeId = routeId;
         this.number = number;
         this.departurePoint = departurePoint;
         this.arrivalPoint = arrivalPoint;
         this.transitAirport = transitAirport;
         this.flightDirection = flightDirection;
     }

     public int RouteId { get => routeId; set => routeId = value; }
     public string Number { get => number; set => number = value; }
     public string DeparturePoint { get => departurePoint; set => departurePoint = value; }
     public string ArrivalPoint { get => arrivalPoint; set => arrivalPoint = value; }
     public string TransitAirport { get => transitAirport; set => transitAirport = value; }
     public string FlightDirection { get => flightDirection; set => flightDirection = value; }*/
        public override string ToString()
        {
            return $"{RouteId}: Номер {Number}, Точка відправлення {DeparturePoint}, Точка прибуття {ArrivalPoint}, Проміжний пункт {TransitAirport},Напрям: {FlightDirection}";
        }

    }

}
