using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Plane
    {
        [BsonId]

  
        public int PlaneId { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("techCondition")]
        public string TechCondition { get; set; }

        [BsonElement("interiorReadiness")]
        public string InteriorReadiness { get; set; }

        [BsonElement("numberFlightsBeforeRepair")]
        public int NumberFlightsBeforeRepair { get; set; }

        [BsonElement("techInspectionDate")]
        public DateTime TechInspectionDate { get; set; }

        [BsonElement("assigned")]
        public bool Assigned { get; set; }

        [BsonElement("numberRepairs")]
        public int NumberRepairs { get; set; }

        [BsonElement("explotationDate")]
        public DateTime ExploitationDate { get; set; }

        /*public Plane(int planeId, string type, string techCondition, string interiorReadiness, int numberFlightsBeforeRepair, DateTime techInspectionDate, bool assigned, int numberRepairs, DateTime exploitationDate)
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
        public DateTime ExploitationDate { get => exploitationDate; set => exploitationDate = value; }*/
        public override string ToString()
        {
            return $"Id: {PlaneId}, Тип: {Type}, Технічний стан: {TechCondition}, Готовність салону: {InteriorReadiness}, " +
                   $"Кількість польотів до ремонту: {NumberFlightsBeforeRepair}, Дата техінспекції: {TechInspectionDate.ToShortDateString()}, " +
                   $"Приписка: {Assigned}, Кількість ремонтів: {NumberRepairs}, Дата експлуатацї: {ExploitationDate.ToShortDateString()}";
        }
    }
}

