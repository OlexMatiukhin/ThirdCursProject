using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Airport.Services.MongoDBSevice
{
    internal class StructureUnitService
    {
        private readonly IMongoCollection<StructureUnit> _structureUnitCollection;

        public StructureUnitService()
        {

            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _structureUnitCollection = database.GetCollection<StructureUnit>("structureUnit");
        }

        /*public int GetLastStructureUnitd()
        {
            var lastWorker = _structureUnitCollection
                .Find(Builders<StructureUnit>.Filter.Empty)
                .Sort(Builders<StructureUnit>.Sort.Descending(w => w.StructureUnitId))
                .Limit(1)
                .FirstOrDefault();

            return lastWorker?.StructureUnitId ?? 0;
        }*/

        public List<StructureUnit> GetStructureUnitsData()
        {
            try
            {
                return _structureUnitCollection.Find(s => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<StructureUnit>();
            }
        }


        public List<StructureUnit> GetStructureUnitsDataByDepartmentName(string departmentName)
        {
            try
            {
                return _structureUnitCollection.Find(s => s.DepartmentName== departmentName).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<StructureUnit>();
            }
        }
        
        public StructureUnit GetStructureUnitById(ObjectId structureUnitId)
        {
            try
            {
                return _structureUnitCollection.Find(s => s.StructureUnitId == structureUnitId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return null;
            }
        }


        public void AddStructureUnit(StructureUnit structureUnit)
        {
            try
            {
                _structureUnitCollection.InsertOne(structureUnit);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при добавлении данных: {ex.Message}");
            }
        }


        public void UpdateStructureUnit(StructureUnit structureUnit)
        {
            try
            {
                var filter = Builders<StructureUnit>.Filter.Eq(s => s.StructureUnitId, structureUnit.StructureUnitId);
                _structureUnitCollection.ReplaceOne(filter, structureUnit);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при обновлении данных: {ex.Message}");
            }
        }

        public void DeleteStructureUnit(ObjectId structureUnitId)
        {
            try
            {
                var filter = Builders<StructureUnit>.Filter.Eq(s => s.StructureUnitId, structureUnitId);
                _structureUnitCollection.DeleteOne(filter);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при удалении данных: {ex.Message}");
            }
        }
    }
}
