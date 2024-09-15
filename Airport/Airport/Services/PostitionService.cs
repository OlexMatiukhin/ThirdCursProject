using Airport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Airport.Services
{
    internal class PositionService
    {
        private readonly IMongoCollection<Position> _positionCollection;

        public PositionService()
        {
           
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _positionCollection = database.GetCollection<Position>("position"); 
        }

        public int GetLastPositionId()
        {
            var lastPosition = _positionCollection
                .Find(Builders<Position>.Filter.Empty)
                .Sort(Builders<Position>.Sort.Descending(w => w.PositionId))
                .Limit(1)
                .FirstOrDefault();

            return lastPosition?.PositionId ?? 0;
        }
        public void AddPostion(Position position)
        {
            try
            {
                _positionCollection.InsertOne(position);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при добавлении данных: {ex.Message}");
            }
           

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