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





        public List<Worker> GetFilteredPilots(string gender, string positionName, int minAge, int maxAge, decimal minSalary, decimal maxSalary)
        {
            try
            {
                var pipeline = new[]
                {
            new BsonDocument("$lookup", new BsonDocument
            {
                { "from", "position" },
                { "localField", "positionName" },
                { "foreignField", "positionName" },
                { "as", "positionInfo" }
            }),
            new BsonDocument("$match", new BsonDocument
            {
                { "gender", gender },
                { "positionName", positionName },
                { "age", new BsonDocument { { "$gte", minAge }, { "$lte", maxAge } } },
                { "positionInfo.salary", new BsonDocument { { "$gte", minSalary }, { "$lte", maxSalary } } }
            }),
            new BsonDocument("$project", new BsonDocument { { "positionInfo", 0 } })
        };

                return _workerCollection.Aggregate<Worker>(pipeline).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при выполнении агрегации: {ex.Message}");
                return new List<Worker>();
            }
        }

        public int GetFilteredPilotCount(string gender, string positionName, int minAge, int maxAge, decimal minSalary, decimal maxSalary)
        {
            try
            {
                var pipeline = new[]
                {
            new BsonDocument("$lookup", new BsonDocument
            {
                { "from", "position" },
                { "localField", "positionName" },
                { "foreignField", "positionName" },
                { "as", "positionInfo" }
            }),
            new BsonDocument("$match", new BsonDocument
            {
                { "gender", gender },
                { "positionName", positionName },
                { "age", new BsonDocument { { "$gte", minAge }, { "$lte", maxAge } } },
                { "positionInfo.salary", new BsonDocument { { "$gte", minSalary }, { "$lte", maxSalary } } }
            }),
            new BsonDocument("$count", "pilotCount")
        };

                var result = _workerCollection.Aggregate<BsonDocument>(pipeline).FirstOrDefault();
                return result != null ? result["pilotCount"].AsInt32 : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при выполнении агрегации: {ex.Message}");
                return 0;
            }
        }


        //8 
        public List<Worker> GetWorkersByBrigadeIdAndMinAge(ObjectId brigadeId, int minAge)
        {
            try
            {
                var filter = Builders<Worker>.Filter.And(
                    Builders<Worker>.Filter.Eq("brigadeId", brigadeId),
                    Builders<Worker>.Filter.Gte("age", minAge)
                );
                return _workerCollection.Find(filter).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<Worker>();
            }
        }

        public List<Worker> GetWorkersByFlightId(ObjectId flightId)
        {
            try
            {
                var pipeline = new[]
                {
                    new BsonDocument("$lookup", new BsonDocument
                    {
                        { "from", "flight" },
                        { "localField", "brigadeId" },
                        { "foreignField", "dispatchBrigadeId" }, // Используем соответствующее поле из рейса
                        { "as", "flights" }
                    }),
                    new BsonDocument("$match", new BsonDocument("flights._id", flightId)),
                    new BsonDocument("$project", new BsonDocument("flights", 0)) // Исключаем поле "flights" из результата
                };

                return _workerCollection.Aggregate<Worker>(pipeline).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при выполнении агрегации: {ex.Message}");
                return new List<Worker>();
            }
        }


        //10 
        public List<Worker> GetWorkersByGenderAgeAndPosition(string gender, int minAge, int maxAge, int minSalary, string structureUnitName)
        {
            try
            {
                var pipeline = new[]
                {
                    new BsonDocument("$lookup", new BsonDocument
                    {
                        { "from", "position" },
                        { "localField", "positionName" },
                        { "foreignField", "positionName" },
                        { "as", "positionInfo" }
                    }),
                    new BsonDocument("$match", new BsonDocument
                    {
                        { "gender", gender },
                        { "age", new BsonDocument { { "$gte", minAge } } },
                        { "numberChildrens", 0 },
                        { "positionInfo", new BsonDocument("$elemMatch", new BsonDocument
                            {
                                { "salary", new BsonDocument { { "$gte", minSalary } } },
                                { "structureUnitName", structureUnitName }
                            })
                        }
                    }),
                    new BsonDocument("$project", new BsonDocument { { "salaryInfo", 0 } })
                };

                return _workerCollection.Aggregate<Worker>(pipeline).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during aggregation: {ex.Message}");
                return new List<Worker>();
            }
        }


        public int GetTotalWorkersByStatusGenderAgeAndPosition(string status, string gender, int minAge, int maxAge, int minSalary)
        {
            try
            {
                var pipeline = new[]
                {
                    new BsonDocument("$lookup", new BsonDocument
                    {
                        { "from", "position" },
                        { "localField", "positionName" },
                        { "foreignField", "positionName" },
                        { "as", "positionInfo" }
                    }),
                    new BsonDocument("$match", new BsonDocument
                    {
                        { "status", status },
                        { "gender", gender },
                        { "age", new BsonDocument { { "$gte", minAge } } },
                        { "numberChildrens", 0 },
                        { "positionInfo", new BsonDocument("$elemMatch", new BsonDocument
                            {
                                { "salary", new BsonDocument { { "$gte", minSalary } } }
                            })
                        }
                    }),
                    new BsonDocument("$project", new BsonDocument { { "salaryInfo", 0 } }),
                    new BsonDocument("$count", "totalWorkers")
                };

                var result = _workerCollection.Aggregate<BsonDocument>(pipeline).FirstOrDefault();
                return result != null ? result["totalWorkers"].ToInt32() : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during aggregation: {ex.Message}");
                return 0;
            }
        }

        public int GetTotalWorkersByStructureUnit(string gender, int minAge, int maxAge, int minSalary, string structureUnitName)
        {
            try
            {
                var pipeline = new[]
                {
                    new BsonDocument("$lookup", new BsonDocument
                    {
                        { "from", "position" },
                        { "localField", "positionName" },
                        { "foreignField", "positionName" },
                        { "as", "positionInfo" }
                    }),
                    new BsonDocument("$match", new BsonDocument
                    {
                        { "gender", gender },
                        { "age", new BsonDocument { { "$gte", minAge } } },
                        { "numberChildrens", 0 },
                        { "positionInfo", new BsonDocument("$elemMatch", new BsonDocument
                            {
                                { "salary", new BsonDocument { { "$gte", minSalary } } },
                                { "structureUnitName", structureUnitName }
                            })
                        }
                    }),
                    new BsonDocument("$project", new BsonDocument { { "salaryInfo", 0 } }),
                    new BsonDocument("$count", "totalWorkers")
                };

                var result = _workerCollection.Aggregate<BsonDocument>(pipeline).FirstOrDefault();
                return result != null ? result["totalWorkers"].ToInt32() : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during aggregation: {ex.Message}");
                return 0;
            }
        }






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
