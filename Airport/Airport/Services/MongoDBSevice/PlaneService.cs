﻿using Airport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Airport.Services.MongoDBSevice
{
    internal class PlaneService
    {
        private readonly IMongoCollection<Plane> _planeCollection;

        public PlaneService()
        {

            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _planeCollection = database.GetCollection<Plane>("plane");
        }

        public void AddPlane(Plane plane)
        {
            try
            {
                _planeCollection.InsertOne(plane);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при добавлении данных: {ex.Message}");
            }
        }


        public void UpdatePlane(Plane updatedPlane)
        {
            try
            {
                var filter = Builders<Plane>.Filter.Eq(p => p.PlaneId, updatedPlane.PlaneId);
                var result = _planeCollection.ReplaceOne(filter, updatedPlane);

               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при обновлении данных: {ex.Message}");
            }
        }

        public Plane GetPlaneById(int planeId)
        {
            try
            {
                return _planeCollection.Find(f => f.PlaneId==planeId).First();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return null;
            }
        }
        public int GetLastPlaneId()
        {
            var lastBaggage = _planeCollection
                .Find(Builders<Plane>.Filter.Empty)
                .Sort(Builders<Plane>.Sort.Descending(w => w.PlaneId))
                .Limit(1)
                .FirstOrDefault();

            return lastBaggage?.PlaneId ?? 0;
        }

        public List<Plane> GetPlanesData()
        {
            try
            {
                return _planeCollection.Find(f => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<Plane>();
            }
        }
    }
}
