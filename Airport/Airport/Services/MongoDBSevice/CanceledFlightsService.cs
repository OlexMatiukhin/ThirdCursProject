using Airport.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Services.MongoDBSevice
{

    public class CanceledFlightsService
    {
        private readonly IMongoCollection<CanceledFlightInfo> _canceledFlightCollection;

        public CanceledFlightsService()
        {

            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _canceledFlightCollection = database.GetCollection<CanceledFlightInfo>("canceledFlightInfo");
        }

        public void AddCanceledFlight(Flight flight, string reason, string description )
        {
            var canceledFlightInfo = new CanceledFlightInfo
            {
                FlightNumber = flight.FlightNumber,
                Status = "Canceled",
                Category = flight.Category,
                DispatchBrigadeId = flight.DispatchBrigadeId,
                NavigationBrigadeId = flight.NavigationBrigadeId,
                FlightBrigadeId = flight.FlightBrigadeId,
                InspectionBrigadeId = flight.InspectionBrigadeId,
                RouteNumber = flight.RouteNumber,
                WorkerId = null,
                Reason = reason,
                Description = description

            };

            try
            {
                _canceledFlightCollection.InsertOne(canceledFlightInfo);
                Console.WriteLine("Данные о canceled flight успешно добавлены.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении данных: {ex.Message}");
            }
        }


        public void DeleteCanceledFlight(ObjectId flightId)
        {
            try
            {
                var result = _canceledFlightCollection.DeleteOne(f => f.CanceledFlightInfoId == flightId);
                if (result.DeletedCount > 0)
                {
                    Console.WriteLine($"Рейс с ID {flightId} упішно видалнео з canceled flights.");
                }
                else
                {
                    Console.WriteLine($"Рейс с ID {flightId} не знайдено.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка видаленення даних: {ex.Message}");
            }
        }


        public List<CanceledFlightInfo> GetCanceledFlightsData()
        {
            try
            {
                return _canceledFlightCollection.Find(b => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<CanceledFlightInfo>();
            }
        }

        public List<CanceledFlightInfo> GetCanceledFlightsByRouteAndSeats(string routeNumber, int unoccupiedSeatNumber, string flightDirection)
        {
            try
            {
                var pipeline = new[]
                {

                    new BsonDocument("$match", new BsonDocument
                    {
                        { "status", "скасований" },
                        { "routeNumber", routeNumber },
                        { "unoccupiedSeatNumber", unoccupiedSeatNumber }
                    }),

                    
                    new BsonDocument("$lookup", new BsonDocument
                    {
                        { "from", "route" },
                        { "localField", "routeNumber" },
                        { "foreignField", "number" },
                        { "as", "routeDetails" }
                    }),

            
                    new BsonDocument("$unwind", "$routeDetails"),

                    new BsonDocument("$match", new BsonDocument
                    {
                        { "routeDetails.flightDirection", flightDirection }
                    }),

                    new BsonDocument("$project", new BsonDocument
                    {
                        { "routeDetails", 0 }
                    })
                };

                return _canceledFlightCollection.Aggregate<CanceledFlightInfo>(pipeline).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при выполнении агрегации: {ex.Message}");
                return new List<CanceledFlightInfo>();
            }
        }







    }
}
