using Airport.Models; // Убедитесь, что класс Plane определен здесь
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Airport.Services
{
    internal class PlaneService
    {
        private readonly IMongoCollection<Plane> _planeCollection;

        public PlaneService()
        {
            
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _planeCollection = database.GetCollection<Plane>("plane"); 
        }

        public List<Plane> GetPlanesData()
        {
            try
            {
                return _planeCollection.Find(f => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<Plane>();
            }
        }
    }
}
