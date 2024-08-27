using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public  class Brigade
    {
        [BsonId]  
         
        public Object  Id { get; set; }

        [BsonElement("brigadeId")] 
        public int BrigadeId { get; set; }

        [BsonElement("brigadeName")]
        public string BrigadeName { get; set; }

        [BsonElement("structureUnitId")]
        public int StructureUnitId { get; set; }
    }
    
}
