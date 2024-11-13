using Airport.Models;
using Airport.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Airport.Services.MongoDBSevice
{


    internal class PilotMedExamService
    {
        private readonly IMongoCollection<PilotMedExam> _pilotMedExamCollection;

        public PilotMedExamService()
        {
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _pilotMedExamCollection = database.GetCollection<PilotMedExam>("pilotMedExam"); // Название коллекции в MongoDB
        }
        public bool UpdatePilotMedExam(PilotMedExam updatePilotMedExam)
        {
            try
            {
                var result = _pilotMedExamCollection.ReplaceOne(p => p.ExamId == updatePilotMedExam.ExamId, updatePilotMedExam);
                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
        /*public int GetLastPilotId()
        {
            try
            {
                var lastPassenger = _pilotMedExamCollection
                                    .Find(p => true)
                                    .SortByDescending(p => p.ExamId)
                                    .FirstOrDefault();

                return lastPassenger != null ? lastPassenger.ExamId : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении последнего PassengerId: {ex.Message}");
                return 0;
            }
        }*/
        public void AddPilotMedExamForWorker(Worker worker)
        {
           try
            {
                var newPilotMedExam = new PilotMedExam
                {
                    
                    PilotId = worker.WorkerId,
                    DoctorId = null,
                    DateExamination = null,
                    Result = null,
                   
                };

                _pilotMedExamCollection.InsertOne(newPilotMedExam);
               
            }
            catch 
            { 
              
            }
        }
        public void DeletePilotMedExam(ObjectId examId)
        {
            try
            {
                var result = _pilotMedExamCollection.DeleteOne(p => p.ExamId == examId);

                if (result.DeletedCount > 0)
                {
                    Console.WriteLine($"Медицинское обследование с ID {examId} успешно удалено.");
                  
                }
                else
                {
                    Console.WriteLine($"Медицинское обследование с ID {examId} не найдено.");
                  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении медицинского обследования: {ex.Message}");
               
            }
        }

        public List<PilotMedExam> GetPilotMedExamsData()
        {
            try
            {
                return _pilotMedExamCollection.Find(f => true).ToList();
            }
            catch (Exception ex)
            {
                
                return new List<PilotMedExam>();
            }
        }

        public List<BsonDocument> GetPilotMedExamsWithPilotInfo(DateTime startDate, DateTime endDate)
        {
            try
            {
                var pipeline = new[]
                {
                    new BsonDocument
                    {
                        { "$match", new BsonDocument
                            {
                                { "dateExamination", new BsonDocument
                                    {
                                        { "$gte", startDate },
                                        { "$lt", endDate }
                                    }
                                }
                            }
                        }
                    },
                    new BsonDocument
                    {
                        { "$lookup", new BsonDocument
                            {
                                { "from", "worker" },
                                { "localField", "pilotId" },
                                { "foreignField", "_id" },
                                { "as", "pilotInfo" }
                            }
                        }
                    },
                    new BsonDocument ("$unwind", "$pilotInfo"),
                    new BsonDocument
                    {
                        { "$project", new BsonDocument
                            {
                                { "pilotInfo", 1 },
                                { "_id", 0 }
                            }
                        }
                    }
                };

                return _pilotMedExamCollection.Aggregate<BsonDocument>(pipeline).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при выполнении агрегационного запроса для получения информации о пилотах: {ex.Message}");
                return new List<BsonDocument>();
            }
        }


        public int GetTotalPilotMedExamsCount(DateTime startDate, DateTime endDate)
        {
            try
            {
                var pipeline = new[]
                {
                    new BsonDocument
                    {
                        { "$match", new BsonDocument
                            {
                                { "dateExamination", new BsonDocument
                                    {
                                        { "$gte", startDate },
                                        { "$lt", endDate }
                                    }
                                }
                            }
                        }
                    },
                    new BsonDocument ("$count", "totalExams")
                };

                var result = _pilotMedExamCollection.Aggregate<BsonDocument>(pipeline).FirstOrDefault();
                return result?["totalExams"].AsInt32 ?? 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при выполнении агрегационного запроса для подсчета медицинских обследований: {ex.Message}");
                return 0;
            }
        }





    }

}
