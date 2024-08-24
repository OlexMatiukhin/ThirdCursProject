using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class Department
    {
        private int departmentId;
        private string departmentName;

        public Department(int departmentId, string departmentName)
        {
            this.departmentId = departmentId;
            this.departmentName = departmentName;
        }

        public int DepartmentId { get => departmentId; set => departmentId = value; }
        public string DepartmentName { get => departmentName; set => departmentName = value; }
    }
}
