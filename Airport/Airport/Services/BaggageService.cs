﻿using Airport.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Airport.Services
{
    public class BaggageService
    {
        private readonly IMongoCollection<Baggage> _baggageCollection;

        public BaggageService()
        {
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _baggageCollection = database.GetCollection<Baggage>("baggage");
        }

        public int GetLastBaggeId()
        {
            var lastBaggage = _baggageCollection
                .Find(Builders<Baggage>.Filter.Empty)
                .Sort(Builders<Baggage>.Sort.Descending(w => w.BaggageId))
                .Limit(1)
                .FirstOrDefault();

            return lastBaggage?.BaggageId ?? 0;
        }

        public List<Baggage> GetBaggageData()
        {
            try
            {
                return _baggageCollection.Find(b => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<Baggage>();
            }
        }

        public void AddBaggage(Baggage newBaggage)
        {
            try
            {
                _baggageCollection.InsertOne(newBaggage);
                Console.WriteLine("Багаж успешно добавлен.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при добавлении багажа: {ex.Message}");
            }
        }

        public bool DeleteBaggage(int baggageId)
        {
            try
            {
                var result = _baggageCollection.DeleteOne(b => b.BaggageId == baggageId);
                if (result.DeletedCount > 0)
                {
                    Console.WriteLine("Багаж успешно удален.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Багаж с указанным ID не найден.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при удалении багажа: {ex.Message}");
                return false;
            }
        }

        public bool UpdateBaggage(Baggage updatedBaggage)
        {
            try
            {
                var result = _baggageCollection.ReplaceOne(b => b.BaggageId == updatedBaggage.BaggageId, updatedBaggage);
                if (result.ModifiedCount > 0)
                {
                    Console.WriteLine("Багаж успешно обновлен.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Багаж с указанным ID не найден.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при обновлении багажа: {ex.Message}");
                return false;
            }
        }
    }
}