using Airport.Models;
using Airport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Airport.Services
{


    internal class PilotMedExamService
    {
        private readonly IMongoCollection<PilotMedExam> _pilotMedExamCollection;

        public PilotMedExamService()
        {
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _pilotMedExamCollection = database.GetCollection<PilotMedExam>("pilotMedExams"); // Название коллекции в MongoDB
        }

        public List<PilotMedExam> GetPilotMedExamsData()
        {
            try
            {
                return _pilotMedExamCollection.Find(f => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<PilotMedExam>();
            }
        }
    }

}
