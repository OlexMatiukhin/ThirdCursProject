using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Airport.Models;

namespace Airport.Services
{
    public class CompletedFlightService
    {
        private readonly IMongoCollection<CompletedFlight> _completedFlightCollection;

        public CompletedFlightService()
        {
            // Connecting to MongoDB
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _completedFlightCollection = database.GetCollection<CompletedFlight>("completedFlights");
        }

        // Method to retrieve all completed flights
        public List<CompletedFlight> GetCompletedFlightsData()
        {
            try
            {
                return _completedFlightCollection.Find(b => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<CompletedFlight>();
            }
        }
    }

}
