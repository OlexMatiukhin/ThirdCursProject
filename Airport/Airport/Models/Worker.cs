using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Worker
    {
        [BsonId]        
        public int WorkerId { get; set; }

        [BsonElement("fullName")]
        public string FullName { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("gender")]
        public string Gender { get; set; }

        [BsonElement("numberChildrens")]
        public int NumberChildrens { get; set; }

        [BsonElement("hireDate")]
        public DateTime HireDate { get; set; }

        [BsonElement("shift")]
        public string Shift { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }


        [BsonElement("brigadeId")]
        public int BrigadeId { get; set; }

        [BsonElement("positionId")]
        public int PositionId { get; set; }

        /*public Worker(int workerId, string fullName, int age, string status, string gender, int numberChildrens, DateTime hireDate, string shift, string email, string phoneNumber, int structureUnitId, int departmentId, int brigadeId, int positionId)
        {
            this.workerId = workerId;
            this.fullName = fullName;
            this.age = age;
            this.status = status;
            this.gender = gender;
            this.numberChildrens = numberChildrens;
            this.hireDate = hireDate;
            this.shift = shift;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.structureUnitId = structureUnitId;
            this.departmentId = departmentId;
            this.brigadeId = brigadeId;
            this.positionId = positionId;
        }

        public int WorkerId { get => workerId; set => workerId = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public int Age { get => age; set => age = value; }
        public string Status { get => status; set => status = value; }
        public string Gender { get => gender; set => gender = value; }
        public int NumberChildrens { get => numberChildrens; set => numberChildrens = value; }
        public DateTime HireDate { get => hireDate; set => hireDate = value; }
        public string Shift { get => shift; set => shift = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public int StructureUnitId { get => structureUnitId; set => structureUnitId = value; }
        public int DepartmentId { get => departmentId; set => departmentId = value; }
        public int BrigadeId { get => brigadeId; set => brigadeId = value; }
        public int PositionId { get => positionId; set => positionId = value; }*/
    }
}
