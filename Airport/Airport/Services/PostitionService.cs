using Airport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Airport.Services
{
    internal class PositionService
    {
        private readonly IMongoCollection<Position> _positionCollection;

        public PositionService()
        {
           
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _positionCollection = database.GetCollection<Position>("positions"); 
        }

        public List<Position> GetPositionsData()
        {
            try
            {
                return _positionCollection.Find(p => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<Position>();
            }
        }
    }
}