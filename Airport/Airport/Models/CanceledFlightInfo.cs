using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class CanceledFlightInfo
    {
        private int canceledFlightInfoId;
        private string flightNumber;
        private string status;
        private string category;
        private int dispatchBrigadeId;
        private int navigationBrigadeId;
        private int flightBrigadeId;
        private int unoccupiedSeatNumber;
        private int seatNumber;
        private int inspectionBrigadeId;
        private int routeId;
        private int workerId;
        private string reason;

        public CanceledFlightInfo(int canceledFlightInfoId, string flightNumber, string status, string category, int dispatchBrigadeId, int navigationBrigadeId, int flightBrigadeId, int unoccupiedSeatNumber, int seatNumber, int inspectionBrigadeId, int routeId, int workerId, string reason)
        {
            this.canceledFlightInfoId = canceledFlightInfoId;
            this.flightNumber = flightNumber;
            this.status = status;
            this.category = category;
            this.dispatchBrigadeId = dispatchBrigadeId;
            this.navigationBrigadeId = navigationBrigadeId;
            this.flightBrigadeId = flightBrigadeId;
            this.unoccupiedSeatNumber = unoccupiedSeatNumber;
            this.seatNumber = seatNumber;
            this.inspectionBrigadeId = inspectionBrigadeId;
            this.routeId = routeId;
            this.workerId = workerId;
            this.reason = reason;
        }

        public int CanceledFlightInfoId { get => canceledFlightInfoId; set => canceledFlightInfoId = value; }
        public string FlightNumber { get => flightNumber; set => flightNumber = value; }
        public string Status { get => status; set => status = value; }
        public string Category { get => category; set => category = value; }
        public int DispatchBrigadeId { get => dispatchBrigadeId; set => dispatchBrigadeId = value; }
        public int NavigationBrigadeId { get => navigationBrigadeId; set => navigationBrigadeId = value; }
        public int FlightBrigadeId { get => flightBrigadeId; set => flightBrigadeId = value; }
        public int UnoccupiedSeatNumber { get => unoccupiedSeatNumber; set => unoccupiedSeatNumber = value; }
        public int SeatNumber { get => seatNumber; set => seatNumber = value; }
        public int InspectionBrigadeId { get => inspectionBrigadeId; set => inspectionBrigadeId = value; }
        public int RouteId { get => routeId; set => routeId = value; }
        public int WorkerId { get => workerId; set => workerId = value; }
        public string Reason { get => reason; set => reason = value; }
    }

}
