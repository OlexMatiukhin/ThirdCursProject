using Airport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Services
{
    internal class PassengerService
    {

        private readonly IMongoCollection<Passenger> _passengerCollection;

        public PassengerService()
        {
          
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _passengerCollection = database.GetCollection<Passenger>("passenger"); // Название коллекции в MongoDB
        }

        public List<Passenger> GetPassengersData()
        {
            try
            {
                return _passengerCollection.Find(f => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<Passenger>();
            }
        }
    }
        
}
