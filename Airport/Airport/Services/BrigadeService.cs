using Airport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class BrigadeService
{
      
        private readonly IMongoCollection<Brigade> _brigadeCollection;

        public BrigadeService()
        {
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _brigadeCollection = database.GetCollection<Brigade>("brigades"); // Название коллекции в MongoDB
        }

        // Метод для получения всех бригад
        public List<Brigade> GetBrigadesData()
        {
            try
            {
                return _brigadeCollection.Find(b => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<Brigade>();
            }
        }

        // Метод для получения бригады по ID
        public Brigade GetBrigadeById(int brigadeId)
        {
            try
            {
                return _brigadeCollection.Find(b => b.BrigadeId == brigadeId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return null;
            }
        }

        // Метод для добавления новой бригады
        public void AddBrigade(Brigade brigade)
        {
            try
            {
                _brigadeCollection.InsertOne(brigade);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при добавлении данных: {ex.Message}");
            }
        }

        // Метод для обновления существующей бригады
        public void UpdateBrigade(Brigade brigade)
        {
            try
            {
                var filter = Builders<Brigade>.Filter.Eq(b => b.BrigadeId, brigade.BrigadeId);
                _brigadeCollection.ReplaceOne(filter, brigade);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при обновлении данных: {ex.Message}");
            }
        }

        // Метод для удаления бригады
        public void DeleteBrigade(int brigadeId)
        {
            try
            {
                var filter = Builders<Brigade>.Filter.Eq(b => b.BrigadeId, brigadeId);
                _brigadeCollection.DeleteOne(filter);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при удалении данных: {ex.Message}");
            }
        }
}


