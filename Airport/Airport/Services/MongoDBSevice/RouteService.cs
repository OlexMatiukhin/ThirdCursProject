using Airport.Models; 
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Services.MongoDBSevice
{
    internal class RouteService
    {
        private readonly IMongoCollection<Route> _routeCollection;
        private readonly IMongoCollection<Flight> _flightCollection;
        public RouteService()
        {
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _routeCollection = database.GetCollection<Route>("route");
            _flightCollection = database.GetCollection<Flight>("flight");
        }

        public List<Route> GetRoutes()
        {
            try
            {
                return _routeCollection.Find(r => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<Route>();
            }
        }

        public Route GetRouteById(ObjectId routeId)
        {
            try
            {
                return _routeCollection.Find(r => r.RouteId == routeId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return null;
            }
        }
        public bool HasFlightsWithRoute(ObjectId routeId)
        {
            try
            {
                var filter = Builders<Flight>.Filter.Eq(f => f.RouteNumber, routeId.ToString());
                return _flightCollection.Find(filter).Any();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при проверке рейсов по маршруту: {ex.Message}");
                return false;
            }
        }

        public void AddRoute(Route route)
        {
            try
            {
                _routeCollection.InsertOne(route);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при добавлении данных: {ex.Message}");
            }
        }

        /*public int GetLastRouteId()
        {
            var lastWorker = _routeCollection
                .Find(Builders<Route>.Filter.Empty)
                .Sort(Builders<Route>.Sort.Descending(w => w.RouteId))
                .Limit(1)
                .FirstOrDefault();

            return lastWorker?.RouteId ?? 0;
        }*/


        public void UpdateRoute(Route route)
        {
            try
            {
                var filter = Builders<Route>.Filter.Eq(r => r.RouteId, route.RouteId);
                _routeCollection.ReplaceOne(filter, route);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при обновлении данных: {ex.Message}");
            }
        }


        public void DeleteRoute(ObjectId routeId)
        {
            try
            {
                var filter = Builders<Route>.Filter.Eq(r => r.RouteId, routeId);
                _routeCollection.DeleteOne(filter);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при удалении данных: {ex.Message}");
            }
        }
    }
}
