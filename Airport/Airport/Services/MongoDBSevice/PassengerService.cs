using Airport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Airport.Services.MongoDBSevice
{
    public class PassengerService
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


        public bool AddPassenger(Passenger newPassenger)
        {
            try
            {
                _passengerCollection.InsertOne(newPassenger);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при добавлении пассажира: {ex.Message}");
                return false;
            }
        }

        public bool UpdatePassenger(Passenger updatedPassenger)
        {
            try
            {
                var result = _passengerCollection.ReplaceOne(p => p.PassengerId == updatedPassenger.PassengerId, updatedPassenger);
                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при обновлении пассажира: {ex.Message}");
                return false;
            }
        }


        public bool DeletePassenger(int passengerId)
        {
            try
            {
                var result = _passengerCollection.DeleteOne(p => p.PassengerId == passengerId);
                return result.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при удалении пассажира: {ex.Message}");
                return false;
            }
        }
        public int GetLastPassengerId()
        {
            try
            {
                var lastPassenger = _passengerCollection
                                    .Find(p => true)
                                    .SortByDescending(p => p.PassengerId)
                                    .FirstOrDefault();

                return lastPassenger != null ? lastPassenger.PassengerId : 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении последнего PassengerId: {ex.Message}");
                return 0;
            }
        }

    }
}