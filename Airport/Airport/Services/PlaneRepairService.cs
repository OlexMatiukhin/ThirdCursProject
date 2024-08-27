﻿

using Airport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Airport.Services
{
    internal class PlaneRepairService
    {
        private readonly IMongoCollection<PlaneRepair> _planeRepairCollection;

        public PlaneRepairService()
        {

            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _planeRepairCollection = database.GetCollection<PlaneRepair>("planeRepairs"); // Название коллекции в MongoDB
        }

        public List<PlaneRepair> GetPlaneRepairsData()
        {
            try
            {
                return _planeRepairCollection.Find(_ => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<PlaneRepair>();
            }
        }
    }
}