using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Position
    {
        private int positionId;
        private string positionName;
        private decimal salary;

        public Position(int positionId, string positionName, decimal salary)
        {
            this.positionId = positionId;
            this.positionName = positionName;
            this.salary = salary;
        }

        public int PositionId { get => positionId; set => positionId = value; }
        public string PositionName { get => positionName; set => positionName = value; }
        public decimal Salary { get => salary; set => salary = value; }
    }
    

}
