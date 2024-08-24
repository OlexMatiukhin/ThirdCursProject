using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Worker
    {
        private int workerId;
        private string fullName;
        private int age;
        private string status;
        private string gender;
        private int numberChildrens;
        private DateTime hireDate;
        private string shift;
        private string email;
        private string phoneNumber;
        private int structureUnitId;
        private int departmentId;
        private int brigadeId;
        private int positionId;

        public Worker(int workerId, string fullName, int age, string status, string gender, int numberChildrens, DateTime hireDate, string shift, string email, string phoneNumber, int structureUnitId, int departmentId, int brigadeId, int positionId)
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
        public int PositionId { get => positionId; set => positionId = value; }
    }
}
