using Airport.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Airport.Services.MongoDBSevice
{
    internal class WorkerService
    {
        private readonly IMongoCollection<Worker> _workerCollection;

        public WorkerService()
        {

            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject"); ;
            var database = client.GetDatabase("airport");
            _workerCollection = database.GetCollection<Worker>("worker");

        }
       public void DeleteBrigadeFromWorker( ObjectId workerId)
        {
            try {
                _workerCollection.Find(w => w.WorkerId == workerId).First().BrigadeId=null;
            }
            catch (Exception ex)
            {

            }
            

        }
        public List<Worker> GetWorkersByPositionName(string positionName)
        {
            try
            {
                return _workerCollection.Find(w => w.PositionName== positionName).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return null;
            }
        }

        public List<Worker> GetWorkerDataByPositionId(string positionName)
        {
            try
            {
                return _workerCollection.Find(w => w.PositionName == positionName).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<Worker>();
            }
        }

        public List<Worker> GetWorkersData()
        {
            try
            {
                return _workerCollection.Find(w => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<Worker>();
            }
        }


        public Worker GetWorkerById(ObjectId? workerId)
        {
            try
            {
                return _workerCollection.Find(w => w.WorkerId == workerId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return null;
            }
        }

        public void AddWorker(Worker worker)
        {
            try
            {
                _workerCollection.InsertOne(worker);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при добавлении данных: {ex.Message}");
            }
        }

       /* public int GetLastWorkerId()
        {
            var lastWorker = _workerCollection
                .Find(Builders<Worker>.Filter.Empty)
                .Sort(Builders<Worker>.Sort.Descending(w => w.WorkerId))
                .Limit(1)
                .FirstOrDefault();

            return lastWorker?.WorkerId ?? 0;
        }*/

        
        public bool UpdateWorker(Worker updatedWorker)
        {
            try
            {
                var result = _workerCollection.ReplaceOne(w => w.WorkerId == updatedWorker.WorkerId, updatedWorker);
                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при обновлении пассажира: {ex.Message}");
                return false;
            }
        }

        public void DeleteWorker(ObjectId workerId)
        {
            try
            {
                var filter = Builders<Worker>.Filter.Eq(w => w.WorkerId, workerId);
                _workerCollection.DeleteOne(filter);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при удалении данных: {ex.Message}");
            }
        }
    }
}
