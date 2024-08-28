using Airport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace Airport.Services
    {
        internal class PassengerCompletedFlightService
        {
            private readonly IMongoCollection<PassengerCompletedFlight> _passengerCompletedFlightCollection;

            public PassengerCompletedFlightService()
            {
                var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
                var database = client.GetDatabase("airport");
                _passengerCompletedFlightCollection = database.GetCollection<PassengerCompletedFlight>("passengerCompletedFlights");
            }

            // Метод для получения всех записей о завершенных полетах пассажиров
            public List<PassengerCompletedFlight> GetPassengerCompletedFlightsData()
            {
                try
                {
                    return _passengerCompletedFlightCollection.Find(pcf => true).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                    return new List<PassengerCompletedFlight>();
                }
            }

            
            public PassengerCompletedFlight GetPassengerCompletedFlightById(int id)
            {
                try
                {
                    return _passengerCompletedFlightCollection.Find(pcf => pcf.CompletedFlightId == id).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                    return null;
                }
            }

     
            public void AddPassengerCompletedFlight(PassengerCompletedFlight passengerCompletedFlight)
            {
                try
                {
                    _passengerCompletedFlightCollection.InsertOne(passengerCompletedFlight);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка при добавлении данных: {ex.Message}");
                }
            }

            // Метод для обновления существующей записи о завершенном полете пассажира
            public void UpdatePassengerCompletedFlight(PassengerCompletedFlight passengerCompletedFlight)
            {
                try
                {
                    var filter = Builders<PassengerCompletedFlight>.Filter.Eq(pcf => pcf.PassengerId, passengerCompletedFlight.PassengerId);
                    _passengerCompletedFlightCollection.ReplaceOne(filter, passengerCompletedFlight);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка при обновлении данных: {ex.Message}");
                }
            }

            // Метод для удаления записи о завершенном полете пассажира
            public void DeletePassengerCompletedFlight(int id)
            {
                try
                {
                    var filter = Builders<PassengerCompletedFlight>.Filter.Eq(pcf => pcf.CompletedFlightId, id);
                    _passengerCompletedFlightCollection.DeleteOne(filter);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка при удалении данных: {ex.Message}");
                }
            }
        }
    }

