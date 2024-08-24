using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Models
{
    public class StructureUnit
    {
        private int structureUnitId;
        private string structureUnitName;
        private string type;
        private int departmentId;

        public StructureUnit(int structureUnitId, string structureUnitName, string type, int departmentId)
        {
            this.structureUnitId = structureUnitId;
            this.structureUnitName = structureUnitName;
            this.type = type;
            this.departmentId = departmentId;
        }

        public int StructureUnitId { get => structureUnitId; set => structureUnitId = value; }
        public string StructureUnitName { get => structureUnitName; set => structureUnitName = value; }
        public string Type { get => type; set => type = value; }
        public int DepartmentId { get => departmentId; set => departmentId = value; }
    }
}
