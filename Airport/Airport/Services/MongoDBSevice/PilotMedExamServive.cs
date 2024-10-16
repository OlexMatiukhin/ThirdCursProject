﻿using Airport.Models;
using Airport.Models;
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
