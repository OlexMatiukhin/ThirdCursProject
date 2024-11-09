using Airport.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Airport.Services.MongoDBSevice
{
    internal class PlaneService
    {
        private readonly IMongoCollection<AirPlane> _planeCollection;

        public PlaneService()
        {

            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _planeCollection = database.GetCollection<AirPlane>("plane");
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
    }
}
