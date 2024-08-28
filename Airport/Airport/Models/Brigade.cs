using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Airport.Models
{
    public  class Brigade
    {
        
        [BsonId]
        public int BrigadeId { get; set; }

        [BsonElement("brigadeType")]
        public string BrigadeType { get; set; }

        [BsonElement("structureUnitId")]
        public int StructureUnitId { get; set; }
        public override string ToString()
        {
            return $"{BrigadeId}: Тип:{BrigadeType}, Структурна одиниця: {StructureUnitId}";
        }
    }

   

}
