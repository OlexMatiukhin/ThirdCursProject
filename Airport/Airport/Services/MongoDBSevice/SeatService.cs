using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Airport.Models;
using MongoDB.Bson;

namespace Airport.Services.MongoDBSevice
{
    internal class SeatService
    {
        private readonly IMongoCollection<Seat> _seatCollection;

        public SeatService()
        {

            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _seatCollection = database.GetCollection<Seat>("seat");
        }


        public List<Seat> GetFilteredSeats(ObjectId flightId, DateTime departureDate, string routeNumber, decimal price, int departureHour, int departureMinute)
        {
            var pipeline = new[]
            {
                new BsonDocument
                {
                    { "$lookup", new BsonDocument
                        {
                            { "from", "flight" },
                            { "localField", "flightId" },
                            { "foreignField", "_id" },
                            { "as", "flight" }
                        }
                    }
                },
                new BsonDocument ("$unwind", "$flight"),
                new BsonDocument
                {
                    { "$lookup", new BsonDocument
                        {
                            { "from", "route" },
                            { "localField", "flight.routeNumber" },
                            { "foreignField", "number" },
                            { "as", "route" }
                        }
                    }
                },
                new BsonDocument ("$unwind", "$route"),
                new BsonDocument
                {
                    { "$match", new BsonDocument
                        {
                            { "flight._id", flightId },
                            { "flight.dateDeparture", new BsonDocument
                                {
                                    { "$gte", departureDate.ToUniversalTime() },
                                    { "$lt", departureDate.AddDays(1).ToUniversalTime() }
                                }
                            },
                            { "route.number", routeNumber },
                            { "flight.price", price },
                            { "$expr", new BsonDocument
                                {
                                    { "$and", new BsonArray
                                        {
                                            new BsonDocument("$eq", new BsonArray { new BsonDocument("$hour", "$flight.dateDeparture"), departureHour }),
                                            new BsonDocument("$eq", new BsonArray { new BsonDocument("$minute", "$flight.dateDeparture"), departureMinute })
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                new BsonDocument
                {
                    { "$project", new BsonDocument
                        {
                            { "flight", 0 },
                            { "route", 0 }
                        }
                    }
                }
            };

            return _seatCollection.Aggregate<Seat>(pipeline).ToList();
        }

        public int GetFilteredSeatsCount(ObjectId flightId, DateTime departureDate, string routeNumber, decimal price, int departureHour, int departureMinute)
        {
            var pipeline = new[]
            {
                new BsonDocument
                {
                    { "$lookup", new BsonDocument
                        {
                            { "from", "flight" },
                            { "localField", "flightId" },
                            { "foreignField", "_id" },
                            { "as", "flight" }
                        }
                    }
                },
                new BsonDocument ("$unwind", "$flight"),
                new BsonDocument
                {
                    { "$lookup", new BsonDocument
                        {
                            { "from", "route" },
                            { "localField", "flight.routeNumber" },
                            { "foreignField", "number" },
                            { "as", "route" }
                        }
                    }
                },
                new BsonDocument ("$unwind", "$route"),
                new BsonDocument
                {
                    { "$match", new BsonDocument
                        {
                            { "flight._id", flightId },
                            { "flight.dateDeparture", new BsonDocument
                                {
                                    { "$gte", departureDate.ToUniversalTime() },
                                    { "$lt", departureDate.AddDays(1).ToUniversalTime() }
                                }
                            },
                            { "route.number",   routeNumber },
                            { "flight.price", price },
                            { "$expr", new BsonDocument
                                {
                                    { "$and", new BsonArray
                                        {
                                            new BsonDocument("$eq", new BsonArray { new BsonDocument("$hour", "$flight.dateDeparture"), departureHour }),
                                            new BsonDocument("$eq", new BsonArray { new BsonDocument("$minute", "$flight.dateDeparture"), departureMinute })
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                new BsonDocument ("$count", "seatCount")
            };

            var result = _seatCollection.Aggregate<BsonDocument>(pipeline).FirstOrDefault();
            return result != null ? result["seatCount"].AsInt32 : 0;
        }
    






    public int GetLastSeatNumber()
        {
            var lastSeat = _seatCollection
                .Find(Builders<Seat>.Filter.Empty)
                .Sort(Builders<Seat>.Sort.Descending(f => f.SeatId))
                .Limit(1)
                .FirstOrDefault();

            return lastSeat?.Number ?? 0;
        }

        public List<Seat> GetSeatsData()
        {
            try
            {
                return _seatCollection.Find(s => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<Seat>();
            }
        }


        public Seat GetSeatById(ObjectId seatId)
        {
            try
            {
                return _seatCollection.Find(s => s.SeatId == seatId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return null;
            }
        }


        public void AddSeat(Seat seat)
        {
            try
            {
                _seatCollection.InsertOne(seat);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при добавлении данных: {ex.Message}");
            }
        }


        public void UpdateSeat(Seat seat)
        {
            try
            {
                var filter = Builders<Seat>.Filter.Eq(s => s.SeatId, seat.SeatId);
                _seatCollection.ReplaceOne(filter, seat);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при обновлении данных: {ex.Message}");
            }
        }

        public void DeleteSeatsByFlightId(ObjectId flightId)
        {
            try
            {
                var result = _seatCollection.DeleteMany(f => f.FlightId == flightId);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при удалении пассажира: {ex.Message}");

            }
        }
        public void DeleteSeat(ObjectId seatId)
        {
            try
            {
                var filter = Builders<Seat>.Filter.Eq(s => s.SeatId, seatId);
                _seatCollection.DeleteOne(filter);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при удалении данных: {ex.Message}");
            }
        }
    }
}