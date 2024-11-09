using Airport.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Services.MongoDBSevice
{

    public class DepartmentService
    {
        private readonly IMongoCollection<Department> _departmentCollection;


        public DepartmentService()
        {

            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _departmentCollection = database.GetCollection<Department>("department");
        }




        public void AddDepartment(Department department)
        {
            try
            {
                _departmentCollection.InsertOne(department);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при добавлении данных: {ex.Message}");
            }
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

        public bool UpdateDepartment(Department updatedDepartment)
        {
            try
            {
                var result = _departmentCollection.ReplaceOne(d => d.DepartmentId == updatedDepartment.DepartmentId, updatedDepartment);
                if (result.ModifiedCount > 0)
                {

                    return true;
                }
                else
                {

                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


      

        public bool DeleteDepartment(ObjectId departmentId)
        {
            try
            {
                var result = _departmentCollection.DeleteOne(d => d.DepartmentId == departmentId);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при удалении отдела: {ex.Message}");
                return false;
            }
        }
         
        




    }



}

