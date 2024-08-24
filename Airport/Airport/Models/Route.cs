using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Route
    {
        private int routeId;
        private string number;
        private string departurePoint;
        private string arrivalPoint;
        private string transitAirport;
        private string flightDirection;

        public Route(int routeId, string number, string departurePoint, string arrivalPoint, string transitAirport, string flightDirection)
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
        public string FlightDirection { get => flightDirection; set => flightDirection = value; }
    }

}
