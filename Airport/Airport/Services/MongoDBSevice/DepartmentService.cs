using Airport.Models;
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

        // Під`єднання до  департаменту
        public DepartmentService()
        {

            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _departmentCollection = database.GetCollection<Department>("department");
        }



        // Додавання департаменту
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
        public int GetLastDepartmentId()
        {
            var lastBaggage = _departmentCollection
                .Find(Builders<Department>.Filter.Empty)
                .Sort(Builders<Department>.Sort.Descending(w => w.DepartmentId))
                .Limit(1)
                .FirstOrDefault();

            return lastBaggage?.DepartmentId ?? 0;
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
        // Метод редагування департаменту в базі
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


        // Метод видалення департаменту

        public bool DeleteDepartment(int departmentId)
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

