using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{

    public class Position
    {
        [BsonId] 

        public int PositionId { get; set; }

        [BsonElement("positionName")] // Указывает имя поля в MongoDB
        public string PositionName { get; set; }

        [BsonElement("salary")]
        public decimal Salary { get; set; }
        
        [BsonElement("structureUnitId")]
        public int StructureUnitId { get; set; }

    }

    /*public int PositionId { get => positionId; set => positionId = value; }
        public string PositionName { get => positionName; set => positionName = value; }
        public decimal Salary { get => salary; set => salary = value; }
    }*/
    

}
