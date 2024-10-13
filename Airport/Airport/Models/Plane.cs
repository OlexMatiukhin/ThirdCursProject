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

       

        public override string ToString()
        {
            return $"Id: {PlaneId}, Тип: {Type}, Технічний стан: {TechCondition}, Готовність салону: {InteriorReadiness}, " +
                   $"Кількість польотів до ремонту: {NumberFlightsBeforeRepair}, Дата техінспекції: {TechInspectionDate.ToShortDateString()}, " +
                   $"Приписка: {Assigned}, Кількість ремонтів: {NumberRepairs}, Дата експлуатацї: {ExploitationDate.ToShortDateString()}";
        }
    }
}

