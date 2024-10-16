﻿using MongoDB.Bson.Serialization.Attributes;
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
      
    public int DepartmentId {  get; set; }

        [BsonElement("departmentName")]

        public string DepartmentName { get; set; }
        public override string ToString()
        {
            return $"DepartmentId: {DepartmentId}, DepartmentName: {DepartmentName}";
        }

    }

}
