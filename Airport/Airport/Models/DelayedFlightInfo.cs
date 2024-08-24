using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class DelayedFlightInfo
    {
        private string flightNumber;
        private string category;
        private int dispatchBrigadeId;
        private int navigationBrigadeId;
        private int flightBrigadeId;
        private DateTime newDateDeparture;
        private DateTime newDateArrival;
        private int inspectionBrigadeId;
        private string reason;
        private int flightId;
        private int routeId;
        private int workerId;

        public DelayedFlightInfo(string flightNumber, string category, int dispatchBrigadeId, int navigationBrigadeId, int flightBrigadeId, DateTime newDateDeparture, DateTime newDateArrival, int inspectionBrigadeId, string reason, int flightId, int routeId, int workerId)
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
    }

}
