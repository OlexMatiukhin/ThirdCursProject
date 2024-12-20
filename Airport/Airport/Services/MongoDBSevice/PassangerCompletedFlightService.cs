﻿using Airport.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Services.MongoDBSevice
{
    internal class PassengerCompletedFlightService
    {
        private readonly IMongoCollection<PassengerCompletedFlight> _passengerCompletedFlightCollection;

        public PassengerCompletedFlightService()
        {
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _passengerCompletedFlightCollection = database.GetCollection<PassengerCompletedFlight>("passengerCompletedFlight");
        }



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




        /*public int GetLastPassengerCompletedFlightId()
        {
            var lastFlight = _passengerCompletedFlightCollection
                .Find(Builders<PassengerCompletedFlight>.Filter.Empty)
                .Sort(Builders<PassengerCompletedFlight>.Sort.Descending(f => f.PassengerId))
                .Limit(1)
                .FirstOrDefault();

            return lastFlight?.PassengerId ?? 0;
        }*/


        public PassengerCompletedFlight GetPassengerCompletedFlightById(ObjectId id)
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

        public void AddPassengersToCompletedFlight(List<Passenger> passengers)
        {
            try
            {
                var passengerCompletedFlights = passengers.Select(p => new PassengerCompletedFlight
                {
                    
                    FullName = p.FullName,
                    Age = p.Age,
                    Gender = p.Gender,
                    PassportNumber = p.PassportNumber,
                    InternPassportNumber = p.InternPassportNumber,
                    BaggageStatus = p.BaggageStatus,
                    PhoneNumber = p.PhoneNumber,
                    Email = p.Email,
                   CompletedFlightId = p.FlightId,
                }).ToList();

                _passengerCompletedFlightCollection.InsertMany(passengerCompletedFlights);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при добавлении пассажиров: {ex.Message}");
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

        public void DeletePassengerCompletedFlight( ObjectId id)
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


        public List<PassengerCompletedFlight> GetFilteredPassengers(DateTime startDate, DateTime endDate, string flightCategory, string baggageStatus, string gender, int minAge)
        {
            try
            {
                var pipeline = new[]
                {
            new BsonDocument
            {
                { "$lookup", new BsonDocument
                    {
                        { "from", "completedFlight" },
                        { "localField", "completedFlightId" },
                        { "foreignField", "_id" },
                        { "as", "flightDetails" }
                    }
                }
            },
            new BsonDocument("$unwind", "$flightDetails"),
            new BsonDocument
            {
                { "$match", new BsonDocument
                    {
                        { "flightDetails.dateDeparture", new BsonDocument { { "$gte", startDate }, { "$lt", endDate } } },
                        { "flightDetails.category", flightCategory },
                        { "baggageStatus", baggageStatus },
                        { "gender", gender },
                        { "age", new BsonDocument { { "$gte", minAge } } },
                        
                    }
                }
            },
            new BsonDocument ("$project", new BsonDocument { { "flightDetails", 0 } } )
        };

                return _passengerCompletedFlightCollection.Aggregate<PassengerCompletedFlight>(pipeline).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при выполнении агрегационного запроса для выборки пассажиров: {ex.Message}");
                return new List<PassengerCompletedFlight>();
            }
        }

        public int GetFilteredPassengerCount(DateTime startDate, DateTime endDate, string flightCategory, string baggageStatus, string gender, int minAge)
        {
            try
            {
                var pipeline = new[]
                {
                    new BsonDocument
                    {
                        { "$lookup", new BsonDocument
                            {
                                { "from", "completedFlight" },
                                { "localField", "completedFlightId" },
                                { "foreignField", "_id" },
                                { "as", "flightDetails" }
                            }
                        }
                    },
                    new BsonDocument ("$unwind", "$flightDetails"),
                    new BsonDocument
                    {
                        { "$match", new BsonDocument
                            {
                                { "flightDetails.dateDeparture", new BsonDocument { { "$gte", startDate }, { "$lt", endDate } } },
                                { "flightDetails.category", flightCategory },
                                { "baggageStatus", baggageStatus },
                                { "gender", gender },
                                { "age", new BsonDocument { { "$gte", minAge } } },
                               
                            }
                        }
                    },
                    new BsonDocument ("$count", "totalPassengers")
                };

                var result = _passengerCompletedFlightCollection.Aggregate<BsonDocument>(pipeline).FirstOrDefault();
                return result?["totalPassengers"].AsInt32 ?? 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при выполнении агрегационного запроса для подсчета пассажиров: {ex.Message}");
                return 0;
            }
        }
    }
}

