using Airport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    
namespace Airport.Services
{
    public class FlightService
    {
        private readonly IMongoCollection<Flight> _flightCollection;

        public FlightService()
        {
           
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _flightCollection = database.GetCollection<Flight>("flights"); // Название коллекции в MongoDB
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


