using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Plane
    {
        private int planeId;
        private string type;
        private string techCondition;
        private string interiorReadiness;
        private int numberFlightsBeforeRepair;
        private DateTime techInspectionDate;
        private bool assigned;
        private int numberRepairs;
        private DateTime exploitationDate;

        public Plane(int planeId, string type, string techCondition, string interiorReadiness, int numberFlightsBeforeRepair, DateTime techInspectionDate, bool assigned, int numberRepairs, DateTime exploitationDate)
        {
            this.planeId = planeId;
            this.type = type;
            this.techCondition = techCondition;
            this.interiorReadiness = interiorReadiness;
            this.numberFlightsBeforeRepair = numberFlightsBeforeRepair;
            this.techInspectionDate = techInspectionDate;
            this.assigned = assigned;
            this.numberRepairs = numberRepairs;
            this.exploitationDate = exploitationDate;
        }

        public int PlaneId { get => planeId; set => planeId = value; }
        public string Type { get => type; set => type = value; }
        public string TechCondition { get => techCondition; set => techCondition = value; }
        public string InteriorReadiness { get => interiorReadiness; set => interiorReadiness = value; }
        public int NumberFlightsBeforeRepair { get => numberFlightsBeforeRepair; set => numberFlightsBeforeRepair = value; }
        public DateTime TechInspectionDate { get => techInspectionDate; set => techInspectionDate = value; }
        public bool Assigned { get => assigned; set => assigned = value; }
        public int NumberRepairs { get => numberRepairs; set => numberRepairs = value; }
        public DateTime ExploitationDate { get => exploitationDate; set => exploitationDate = value; }
    }
}
