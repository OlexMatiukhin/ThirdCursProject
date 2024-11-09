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
    public class FlightService
    {
        private readonly IMongoCollection<Flight> _flightCollection;

        public FlightService()
        {
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _flightCollection = database.GetCollection<Flight>("flight");
        }
      /* public int GetLastFlightId()
        {
            var lastFlight = _flightCollection
                .Find(Builders<Flight>.Filter.Empty)
                .Sort(Builders<Flight>.Sort.Descending(f => f.FlightId))
                .Limit(1)
                .FirstOrDefault();

            return lastFlight?.FlightId ?? 0;
        }*/

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



    }
}



