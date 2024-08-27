using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class PlaneRepair
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("planeRepairId")]
        public int PlaneRepairId { get; set; }
        [BsonElement("startDate")]
        public DateTime StartDate { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("numberFlights")]
        public int NumberFlights { get; set; }

        [BsonElement("endDate")]
        public DateTime EndDate { get; set; }

        [BsonElement("reason")]
        public string Reason { get; set; }

        [BsonElement("result")]
        public string Result { get; set; }

        [BsonElement("brigadeId")]
        public int BrigadeId { get; set; }

        [BsonElement("planeId")]
        public int PlaneId { get; set; }

        /*public PlaneRepair(DateTime startDate, string status, int numberFlights, DateTime endDate, string reason, string result, int brigadeId, int planeId)
        {
            this.startDate = startDate;
            this.status = status;
            this.numberFlights = numberFlights;
            this.endDate = endDate;
            this.reason = reason;
            this.result = result;
            this.brigadeId = brigadeId;
            this.planeId = planeId;
        }

        public DateTime StartDate { get => startDate; set => startDate = value; }
        public string Status { get => status; set => status = value; }
        public int NumberFlights { get => numberFlights; set => numberFlights = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public string Reason { get => reason; set => reason = value; }
        public string Result { get => result; set => result = value; }
        public int BrigadeId { get => brigadeId; set => brigadeId = value; }
        public int PlaneId { get => planeId; set => planeId = value; }
    }*/



    }
}
