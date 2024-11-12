using Airport.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace Airport.Services.MongoDBSevice
{
    internal class PositionService
    {
        private readonly IMongoCollection<Position> _positionCollection;
        private readonly PositionService _positionService;
        public PositionService()
        {

            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _positionCollection = database.GetCollection<Position>("position");
        }


        public ICommand AddPositionCommand { get; }

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
        public bool UpdatePostition(Position updatedPosition)
        {
            try
            {
                var result = _positionCollection.ReplaceOne(p => p.PositionId == updatedPosition.PositionId, updatedPosition);
                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при обновлении пассажира: {ex.Message}");
                return false;
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
        public bool DeletePostion(ObjectId positionId)
        {
            try
            {
                var result = _positionCollection.DeleteOne(p=> p.PositionId == positionId);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при удалении отдела: {ex.Message}");
                return false;
            }
        }

        public List<Position> GetPositionsDataByStructureUnitName(string structureUnitName)
        {
            try
            {
                return _positionCollection.Find(p => p.StructureUnitName == structureUnitName).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<Position>();
            }
        }

        
    }
}