using Airport.Models;

namespace Airport.Services
{

    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;

    public class DelayedFlightsService
    {
        private readonly IMongoCollection<DelayedFlightInfo> _delayedFlightCollection;

        public DelayedFlightsService()
        {
            
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _delayedFlightCollection = database.GetCollection<DelayedFlightInfo>("delayedFlightInfo");
        }

        public List<DelayedFlightInfo> GetDelayedFlightsData()
        {
            try
            {
                return _delayedFlightCollection.Find(b => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<DelayedFlightInfo>();
            }
        }
    }
}
