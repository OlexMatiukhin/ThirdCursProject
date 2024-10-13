using Airport.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Airport.Services.MongoDBSevice
{
    public class FlightService
    {
        private readonly IMongoCollection<Flight> _flightCollection;

        public FlightService()
        {
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _flightCollection = database.GetCollection<Flight>("flight");
        }
        public int GetLastFlightId()
        {
            var lastFlight = _flightCollection
                .Find(Builders<Flight>.Filter.Empty)
                .Sort(Builders<Flight>.Sort.Descending(f => f.FlightId))
                .Limit(1)
                .FirstOrDefault();

            return lastFlight?.FlightId ?? 0;
        }

        public void AddFlight(Flight flight)
        {
            try
            {
                _flightCollection.InsertOne(flight);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }


        public void UpdateFlight(int flightId, Flight updatedFlight)
        {
            try
            {
                // Создаем фильтр для поиска рейса по FlightId
                var filter = Builders<Flight>.Filter.Eq(f => f.FlightId, flightId);

                // Выполняем обновление данных
                var result = _flightCollection.ReplaceOne(filter, updatedFlight);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при обновлении рейса: {ex.Message}");

            }

        }
        public List<Flight> GetFlightsData()
        {
            try
            {
                return _flightCollection.Find(f => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<Flight>();
            }
        }
    }
}



