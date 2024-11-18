using Airport.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BrigadeService
{
      
        private readonly IMongoCollection<Brigade> _brigadeCollection;
    private readonly IMongoCollection<Worker> _workerCollection;

    public BrigadeService()
        {
        
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _brigadeCollection = database.GetCollection<Brigade>("brigade");
            _workerCollection = database.GetCollection<Worker>("worker");
    }

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
    public void AddWorkerToBrigade(ObjectId briadeId)
    {
        if (briadeId != null) {
            _brigadeCollection.Find((b) => b.BrigadeId == briadeId).FirstOrDefault().NumberWorkers++;
        }
       


    }
    public void DeleteWorkerFromBrigade(ObjectId briadeId)
    {
        _brigadeCollection.Find((b) => b.BrigadeId == briadeId).FirstOrDefault().NumberWorkers--;



    }

    public void RemoveBrigadeFromWorkers(ObjectId brigadeId)
    {
        try
        {
           
            var filter = Builders<Worker>.Filter.Eq(w => w.BrigadeId, brigadeId);
            var update = Builders<Worker>.Update.Set(w => w.BrigadeId, null);

            _workerCollection.UpdateMany(filter, update);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка при удалении бригады у работников: {ex.Message}");
        }
    }


    public bool HasWorkersInBrigade(ObjectId brigadeId)
    {
        try
        {
            var workersInBrigade = _workerCollection.Find(w => w.BrigadeId == brigadeId).ToList();
            return workersInBrigade.Any();  
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка при проверке работников в бригаде: {ex.Message}");
            return false;  
        }
    }


/* public int GetLastBrigadeId()
     {
         var lastBaggage = _brigadeCollection
             .Find(Builders<Brigade>.Filter.Empty)
             .Sort(Builders<Brigade>.Sort.Descending(w => w.BrigadeId))
             .Limit(1)
             .FirstOrDefault();

         return lastBaggage?.BrigadeId ?? 0;
     }*/

public Brigade GetBrigadeById(ObjectId brigadeId)
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

    public List<Brigade> GetBrigadesByType(string BrigadeType)
    {
        try
        {
            return _brigadeCollection.Find(b => b.BrigadeType == BrigadeType).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
            return null;
        }
    }

 
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

      
        public void DeleteBrigade(ObjectId brigadeId)
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


