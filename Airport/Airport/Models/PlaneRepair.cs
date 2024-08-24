using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class PlaneRepair
    {
        private DateTime startDate;
        private string status;
        private int numberFlights;
        private DateTime endDate;
        private string reason;
        private string result;
        private int brigadeId;
        private int planeId;

        public PlaneRepair(DateTime startDate, string status, int numberFlights, DateTime endDate, string reason, string result, int brigadeId, int planeId)
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
    }

    

}
