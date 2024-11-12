using Airport.Models;

namespace Airport.Services.MongoDBSevice
{
    using MongoDB.Bson;
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



        public void DeleteDelayedFlight (ObjectId flightId)
        {
           
                
                var result = _delayedFlightCollection.DeleteOne(f => f.DelayedFlightInfoId == flightId);

                if (result.DeletedCount > 0)
                {
                    Console.WriteLine($"Рейс  з ID {flightId} успешно удален.");
                }
                else
                {
                    Console.WriteLine($"Завершенный рейс с ID {flightId} не найден.");
                }
           
          
        }
        public void AddDelayedFlightInfoFromFlight(Flight flight,  string reason, string descritption)
        {
           if (flight == null)
            {
                throw new ArgumentNullException(nameof(flight), "Flight cannot be null");
            }

            var delayedFlightInfo = new DelayedFlightInfo
            {
                FlightNumber = flight.FlightNumber,
                Category = flight.Category,
                DispatchBrigadeId = flight.DispatchBrigadeId,
                NavigationBrigadeId = flight.NavigationBrigadeId,
                FlightBrigadeId = flight.FlightBrigadeId,
                StartDelayDate = DateTime.Now,  
                EndDelayDate = null,      
                InspectionBrigadeId = flight.InspectionBrigadeId,
                Reason = reason,
                FlightId = flight.FlightId,
                RouteNumber = flight.RouteNumber,
                Description= descritption,
                WorkerId = null
            };

            try
            {
                _delayedFlightCollection.InsertOne(delayedFlightInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при добавлении информации о задержке: {ex.Message}");
            }
        }
    }






}

