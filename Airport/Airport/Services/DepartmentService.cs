using Airport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Services
{
  
public class DepartmentService
    {
        private readonly IMongoCollection<Department> _departmentCollection;

        public DepartmentService()
        {
          
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _departmentCollection = database.GetCollection<Department>("departments");
        }

        public List<Department> GetDepartmentsData()
        {
            try
            {
                return _departmentCollection.Find(d => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<Department>();
            }
        }
    }
}

