using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class StructureUnit
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("structureUnitId")]
        public int StructureUnitId { get; set; }

        [BsonElement("structureUnitName")]
        public string StructureUnitName { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("departmentId")]
        public int DepartmentId { get; set; }
        
    

        /*public StructureUnit(int structureUnitId, string structureUnitName, string type, int departmentId)
        {
            this.structureUnitId = structureUnitId;
            this.structureUnitName = structureUnitName;
            this.type = type;
            this.departmentId = departmentId;
        }

        public int StructureUnitId { get => structureUnitId; set => structureUnitId = value; }
        public string StructureUnitName { get => structureUnitName; set => structureUnitName = value; }
        public string Type { get => type; set => type = value; }
        public int DepartmentId { get => departmentId; set => departmentId = value; }*/
    }
}
