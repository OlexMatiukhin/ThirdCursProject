using Airport.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Numerics;
using System.Windows;

namespace Airport.Services.MongoDBSevice
{
    internal class PlaneService
    {
        private readonly IMongoCollection<AirPlane> _planeCollection;
        private readonly IMongoCollection<Flight> _flightCollection;

        public PlaneService()
        {

            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _planeCollection = database.GetCollection<AirPlane>("plane");
            _flightCollection = database.GetCollection<Flight>("flight");

        }
        public bool IsPlaneInFlight(string planeNumber)
        {
            try
            {

              

                var filter = Builders<Flight>.Filter.Eq(f => f.PlaneNumber, planeNumber);
                var flights = _flightCollection.Find(filter).ToList();
                foreach (var flight in flights)
                {
                    MessageBox.Show($"Found flight: {flight.PlaneNumber}","ddd",MessageBoxButton.OK);
                }

                if (flights.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Console.WriteLine($"Error checking if plane is in flight: {ex.Message}");
                return false;
            }
        }

        public void AddPlane(AirPlane plane)
        {
            try
            {
                _planeCollection.InsertOne(plane);
            }
            catch (Exception ex)
            {
                Console.WriteLine($": {ex.Message}");
            }
        }


        public void UpdatePlane(AirPlane updatedPlane)
        {
            try
            {
                var filter = Builders<AirPlane>.Filter.Eq(p => p.PlaneId, updatedPlane.PlaneId);
                var result = _planeCollection.ReplaceOne(filter, updatedPlane);

               
            }
            catch (Exception ex)
            {
                Console.WriteLine($": {ex.Message}");
            }
        }

        /*public List<AirPlane> Search(string query)
        {
            var filterBuilder = Builders<AirPlane>.Filter;
            var filters = new List<FilterDefinition<AirPlane>>();
            
            if (ObjectId.TryParse(query, out ObjectId planeId))
            {
                filters.Add(filterBuilder.Eq(ap => ap.PlaneId, planeId));
            }

           
            else if (DateTime.TryParseExact(query,
                new[] { "dd.MM.yyyy HH:mm:ss", "dd.MM.yyyy" },
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                filters.Add(filterBuilder.Eq(ap => ap.TechInspectionDate, date) |
                            filterBuilder.Eq(ap => ap.ExploitationDate, date));


                var startOfDay = date.Date; 
                var endOfDay = startOfDay.AddDays(1).AddTicks(-1); 
                
                filters.Add(
                    filterBuilder.And(
                        filterBuilder.Gte(ap => ap.TechInspectionDate, startOfDay),
                        filterBuilder.Lte(ap => ap.TechInspectionDate, endOfDay)
                    ) |
                    filterBuilder.And(
                        filterBuilder.Gte(ap => ap.ExploitationDate, startOfDay),
                        filterBuilder.Lte(ap => ap.ExploitationDate, endOfDay)
                    )
                );
            }

        
            else if (int.TryParse(query, out int number))
            {
                filters.Add(filterBuilder.Eq(ap => ap.NumberFlightsBeforeRepair, number) |
                            filterBuilder.Eq(ap => ap.NumberRepairs, number));
            }

            else if (bool.TryParse(query, out bool assigned))
            {
                filters.Add(filterBuilder.Eq(ap => ap.Assigned, assigned));
            }

            else
            {
                filters.Add(filterBuilder.Regex(ap => ap.Type, new BsonRegularExpression(query, "i")) |
                            filterBuilder.Regex(ap => ap.TechCondition, new BsonRegularExpression(query, "i")) |
                            filterBuilder.Regex(ap => ap.InteriorReadiness, new BsonRegularExpression(query, "i")) |
                            filterBuilder.Regex(ap => ap.PlaneFuelStatus, new BsonRegularExpression(query, "i")) |
                            filterBuilder.Regex(ap => ap.PlaneNumber, new BsonRegularExpression(query, "i")));
            }

        
            var combinedFilter = filterBuilder.Or(filters);
            return _planeCollection.Find(combinedFilter).ToList();
        }*/



        public AirPlane GetPlaneById(ObjectId planeId)
        {
            try
            {
                return _planeCollection.Find(f => f.PlaneId==planeId).First();
            }
            catch (Exception ex)
            {
                Console.WriteLine($": {ex.Message}");
                return null;
            }
        }


        public AirPlane GetPlaneByPlaneNumber(string planeNumber)
        {
            try
            {
                return _planeCollection.Find(f => f.PlaneNumber == planeNumber).First();
            }
            catch (Exception ex)
            {
                Console.WriteLine($": {ex.Message}");
                return null;
            }
        }

        public void DeletePlane(ObjectId planeId)
        {
            try
            {
              
                var result = _planeCollection.DeleteOne(p => p.PlaneId == planeId);

                if (result.DeletedCount > 0)
                {
                    Console.WriteLine($"Літак с ID {planeId} усішно видалено.");
                }
                else
                {
                    Console.WriteLine($"Літак с ID {planeId} не знайдено.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении данных: {ex.Message}");
            }
        }
        public List<AirPlane> GetPlanesData()
        {
            try
            {
                return _planeCollection.Find(f => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($": {ex.Message}");
                return new List<AirPlane>();
            }
        }





        public List<AirPlane> GetPlanesWithFlightsAndRepair(DateTime startDate, DateTime endDate, string assigned, string status)
        {
            var pipeline = new[] {
            new BsonDocument("$lookup", new BsonDocument {
                { "from", "flight" },
                { "localField", "planeNumber" },
                { "foreignField", "planeNumber" },
                { "as", "flights" }
            }),
            new BsonDocument("$unwind", "$flights"),
            new BsonDocument("$match", new BsonDocument {
                { "assigned", assigned },
                { "flights.status", status },
                { "flights.dateArrival", new BsonDocument {
                    { "$gte", new BsonDateTime(startDate) },
                    { "$lte", new BsonDateTime(endDate) }
                }}
            }),
            new BsonDocument("$sort", new BsonDocument {
                { "flights.dateArrival", 1 },
                { "numberFlightsBeforeRepair", -1 }
            }),
            new BsonDocument("$project", new BsonDocument {
                { "flights", 0 }
            })
        };

            return _planeCollection.Aggregate<AirPlane>(pipeline).ToList();
        }

        public int GetPlanesCountWithFlightsAndRepair(DateTime startDate, DateTime endDate, string assigned, string status)
        {
            var pipeline = new[] {
            new BsonDocument("$lookup", new BsonDocument {
                { "from", "flight" },
                { "localField", "planeNumber" },
                { "foreignField", "planeNumber" },
                { "as", "flights" }
            }),
            new BsonDocument("$unwind", "$flights"),
            new BsonDocument("$match", new BsonDocument {
                { "assigned", assigned },
                { "flights.status", status },
                { "flights.dateArrival", new BsonDocument {
                    { "$gte", new BsonDateTime(startDate) },
                    { "$lte", new BsonDateTime(endDate) }
                }}
            }),
            new BsonDocument("$sort", new BsonDocument {
                { "flights.dateArrival", 1 },
                { "numberFlightsBeforeRepair", -1 }
            }),
            new BsonDocument("$count", "totalPlanes")
        };

            var result = _planeCollection.Aggregate<BsonDocument>(pipeline).FirstOrDefault();
            return result != null ? result["totalPlanes"].ToInt32() : 0;
        }
    }
}
