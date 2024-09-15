using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Department
    {
        [BsonId]
      
        [BsonElement("departmentName")]
    public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }
    }
}
