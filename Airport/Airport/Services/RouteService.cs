using Airport.Models; // Убедитесь, что этот using корректен
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Services
{
    internal class RouteService
    {
        private readonly IMongoCollection<Route> _routeCollection;

        public RouteService()
        {
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _routeCollection = database.GetCollection<Route>("routes"); 
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

        public Route GetRouteById(int routeId)
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

      
        public void DeleteRoute(int routeId)
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
