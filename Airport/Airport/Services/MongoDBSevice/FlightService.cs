using Airport.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
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


        public void DeleteFlight(ObjectId flightId)
        {
            try
            {
                var filter = Builders<Flight>.Filter.Eq(f => f.FlightId, flightId);
                var result = _flightCollection.DeleteOne(filter);
                if (result.DeletedCount == 0)
                {
                    Console.WriteLine($"Рейс с ID {flightId} не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении рейса: {ex.Message}");
            }
        }


        public void UpdateFlight(Flight updatedFlight)
        {
            try
            {

                var filter = Builders<Flight>.Filter.Eq(f => f.FlightId, updatedFlight.FlightId);


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

        //1

        public Flight GetFlightById(ObjectId flightId)
        {
            try
            {
                var filter = Builders<Flight>.Filter.Eq(f => f.FlightId, flightId);
                return _flightCollection.Find(filter).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении рейса с ID {flightId}: {ex.Message}");
                return null;
            }
        }
        public List<Flight> GetCharterPassengerFlights(string category, string planeType, string flightDirection)
        {
            var pipeline = new[]
            {
                new BsonDocument("$lookup", new BsonDocument
                {
                    { "from", "plane" },
                    { "localField", "planeNumber" },
                    { "foreignField", "planeNumber" },
                    { "as", "planeDetail" }
                }),
                new BsonDocument("$unwind", "$planeDetail"),
                new BsonDocument("$lookup", new BsonDocument
                {
                    { "from", "route" },
                    { "localField", "routeNumber" },
                    { "foreignField", "number" },
                    { "as", "routeDetail" }
                }),
                new BsonDocument("$unwind", "$routeDetail"),
                new BsonDocument("$match", new BsonDocument
                {
                    { "category", category },
                    { "planeDetail.type", planeType },
                    { "routeDetail.flightDirection", flightDirection }
                }),
                new BsonDocument("$project", new BsonDocument
                {
                    { "planeDetail", 0 },
                    { "routeDetail", 0 }
                })
            };

            return _flightCollection.Aggregate<Flight>(pipeline).ToList();
        }


        public ObjectId GetLastFlightId()
        {
            try
            {
                var lastFlight = _flightCollection
                    .Find(f => true)
                    .SortByDescending(f => f.FlightId)
                    .FirstOrDefault();

                if (lastFlight == null)
                {
                    Console.WriteLine("В коллекции нет рейсов.");
                    return ObjectId.Empty;
                }

                return lastFlight.FlightId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении последнего ID рейса: {ex.Message}");
                return ObjectId.Empty;
            }
        }
        public int GetTotalCharterPassengerFlightsCount(string category, string planeType, string flightDirection)
        {
            var pipeline = new[]
            {
                new BsonDocument("$lookup", new BsonDocument
                {
                    { "from", "plane" },
                    { "localField", "planeNumber" },
                    { "foreignField", "planeNumber" },
                    { "as", "planeDetail" }
                }),
                new BsonDocument("$unwind", "$planeDetail"),
                new BsonDocument("$lookup", new BsonDocument
                {
                    { "from", "route" },
                    { "localField", "routeNumber" },
                    { "foreignField", "number" },
                    { "as", "routeDetail" }
                }),
                new BsonDocument("$unwind", "$routeDetail"),
                new BsonDocument("$match", new BsonDocument
                {
                    { "category", category },
                    { "planeDetail.type", planeType },
                    { "routeDetail.flightDirection", flightDirection }
                }),
                new BsonDocument("$count", "totalFlights")
            };

            var result = _flightCollection.Aggregate<BsonDocument>(pipeline).FirstOrDefault();
            return result == null ? 0 : result["totalFlights"].AsInt32;
        }



        //6
        public List<Flight> GetFlightsByRouteWithDuration(string routeNumber, double minDurationHours, double maxDurationHours)
        {
            var pipeline = new[]
            {
        new BsonDocument("$match", new BsonDocument("routeNumber", routeNumber)),
        new BsonDocument("$addFields", new BsonDocument("flightDuration", new BsonDocument("$subtract", new BsonArray { "$dateArrival", "$dateDeparture" }))),
        new BsonDocument("$match", new BsonDocument("flightDuration", new BsonDocument
        {
            { "$gte", minDurationHours * 60 * 60 * 1000 },
            { "$lte", maxDurationHours * 60 * 60 * 1000 }
        })),
        new BsonDocument("$project", new BsonDocument("flightDuration", 0))
        };

            return _flightCollection.Aggregate<Flight>(pipeline).ToList();
        }


        //7
        public double GetAverageTicketsSold(double minTicketPrice, double maxTicketPrice, string routeNumber, double minDurationHours, double maxDurationHours)
        {
            var pipeline = new[]
            {
            new BsonDocument("$lookup", new BsonDocument
            {
                { "from", "ticket" },
                { "localField", "_id" },
                { "foreignField", "flightId" },
                { "as", "tickets" }
            }),
            new BsonDocument("$unwind", "$tickets"),
            new BsonDocument("$match", new BsonDocument("tickets.price", new BsonDocument
            {
                { "$gte", minTicketPrice },
                { "$lte", maxTicketPrice }
            })),
            new BsonDocument("$lookup", new BsonDocument
            {
                { "from", "route" },
                { "localField", "routeNumber" },
                { "foreignField", "number" },
                { "as", "routeInfo" }
            }),
            new BsonDocument("$unwind", "$routeInfo"),
            new BsonDocument("$addFields", new BsonDocument("flightDuration", new BsonDocument("$subtract", new BsonArray { "$dateArrival", "$dateDeparture" }))),
            new BsonDocument("$match", new BsonDocument
            {
                { "routeNumber", routeNumber },
                { "flightDuration", new BsonDocument
                    {
                        { "$gte", minDurationHours * 60 * 60 * 1000 },
                        { "$lte", maxDurationHours * 60 * 60 * 1000 }
                    }
                }
            }),
            new BsonDocument("$group", new BsonDocument
            {
                { "_id", "$routeNumber" },
                { "averageTicketsSold", new BsonDocument("$avg", "$numberBoughtTickets") }
            }),
            new BsonDocument("$project", new BsonDocument
            {
                { "_id", 0 },
                { "averageTicketsSold", 1 }
            })
        };

            var result = _flightCollection.Aggregate<BsonDocument>(pipeline).FirstOrDefault();
            return result != null ? result["averageTicketsSold"].AsDouble : 0;
        }


        public List<Flight> GetFlightsByPlaneType(string planeType)
        {
            var pipeline = new[]
            {
            new BsonDocument("$lookup", new BsonDocument
            {
                { "from", "plane" },
                { "localField", "planeNumber" },
                { "foreignField", "planeNumber" },
                { "as", "planeInfo" }
            }),
            new BsonDocument("$unwind", "$planeInfo"),
            new BsonDocument("$match", new BsonDocument("planeInfo.type", planeType)),
            new BsonDocument("$project", new BsonDocument("planeInfo", 0)) // Исключаем информацию о самолете
        };

            return _flightCollection.Aggregate<Flight>(pipeline).ToList();
        }
    }


    



}














