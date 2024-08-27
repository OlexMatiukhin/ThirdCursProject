using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class CanceledFlightInfo
    {
        [BsonId]
        private ObjectId Id { get; set; }

        [BsonElement("canceledFlightInfoId")]
        public int CanceledFlightInfoId { get; set; }

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

        [BsonElement("flightBrigadeId")]
        public int FlightBrigadeId { get; set; }

        [BsonElement("unoccupiedSeatNumber")]
        public int UnoccupiedSeatNumber { get; set; }

        [BsonElement("seatNumber")]
        public int SeatNumber { get; set; }

        [BsonElement("inspectionBrigadeId")]
        public int InspectionBrigadeId { get; set; }

        [BsonElement("routeId")]
        public int RouteId { get; set; }

        [BsonElement("workerId")]
        public int WorkerId { get; set; }

        [BsonElement("reason")]
        public string Reason { get; set; }

        /* public CanceledFlightInfo(int canceledFlightInfoId, string flightNumber, string status, string category, int dispatchBrigadeId, int navigationBrigadeId, int flightBrigadeId, int unoccupiedSeatNumber, int seatNumber, int inspectionBrigadeId, int routeId, int workerId, string reason)
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
         }*/

       /* public int CanceledFlightInfoId { get => canceledFlightInfoId; set => canceledFlightInfoId = value; }
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
        public string Reason { get => reason; set => reason = value; }*/
    }

}
