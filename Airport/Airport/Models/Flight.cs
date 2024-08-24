using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Flight
    {
        private int flightId;
        private string flightNumber;
        private string status;
        private string category;
        private DateTime dateDeparture;
        private DateTime dateArrival;
        private int planeId;
        private int dispatchBrigadeId;
        private int navigationBrigadeId;
        private int flightBrigadeId;
        private int inspectionBrigadeId;
        private int routeId;

        public Flight(int flightId, string flightNumber, string status, string category, DateTime dateDeparture, DateTime dateArrival, int planeId, int dispatchBrigadeId, int navigationBrigadeId, int flightBrigadeId, int inspectionBrigadeId, int routeId)
        {
            this.flightId = flightId;
            this.flightNumber = flightNumber;
            this.status = status;
            this.category = category;
            this.dateDeparture = dateDeparture;
            this.dateArrival = dateArrival;
            this.planeId = planeId;
            this.dispatchBrigadeId = dispatchBrigadeId;
            this.navigationBrigadeId = navigationBrigadeId;
            this.flightBrigadeId = flightBrigadeId;
            this.inspectionBrigadeId = inspectionBrigadeId;
            this.routeId = routeId;
        }

        public int FlightId { get => flightId; set => flightId = value; }
        public string FlightNumber { get => flightNumber; set => flightNumber = value; }
        public string Status { get => status; set => status = value; }
        public string Category { get => category; set => category = value; }
        public DateTime DateDeparture { get => dateDeparture; set => dateDeparture = value; }
        public DateTime DateArrival { get => dateArrival; set => dateArrival = value; }
        public int PlaneId { get => planeId; set => planeId = value; }
        public int DispatchBrigadeId { get => dispatchBrigadeId; set => dispatchBrigadeId = value; }
        public int NavigationBrigadeId { get => navigationBrigadeId; set => navigationBrigadeId = value; }
        public int FlightBrigadeId { get => flightBrigadeId; set => flightBrigadeId = value; }
        public int InspectionBrigadeId { get => inspectionBrigadeId; set => inspectionBrigadeId = value; }
        public int RouteId { get => routeId; set => routeId = value; }
    }
}
