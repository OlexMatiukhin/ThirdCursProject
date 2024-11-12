using Airport.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Airport.Services.MongoDBSevice
{
    internal class PlaneRepairService
    {
        private readonly IMongoCollection<PlaneRepair> _planeRepairCollection;

        public PlaneRepairService()
        {

            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _planeRepairCollection = database.GetCollection<PlaneRepair>("planeRepair");
        }
        public bool UpdatePlaneRepair(PlaneRepair updatePilotMedExam)
        {
            try
            {
                var result = _planeRepairCollection.ReplaceOne(p => p.PlaneRepairId == updatePilotMedExam.PlaneRepairId, updatePilotMedExam);
                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public void DeletePlaneRepair(ObjectId planeRepairId)
        {
            try
            {
                
                var result = _planeRepairCollection.DeleteOne(p => p.PlaneRepairId == planeRepairId);

                if (result.DeletedCount > 0)
                {
                    Console.WriteLine($"Ремонт самолета с ID {planeRepairId} успешно удален.");
                }
                else
                {
                    Console.WriteLine($"Ремонт самолета с ID {planeRepairId} не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении данных: {ex.Message}");
            }
        }
    

    public void Add(PlaneRepair planeRepair)
        {
            try
            {
                _planeRepairCollection.InsertOne(planeRepair);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка додавання даних: {ex.Message}");
            }
        }
        public List<PlaneRepair> GetPlaneRepairsData()
        {
            try
            {
                return _planeRepairCollection.Find(b => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<PlaneRepair>();
            }
        }
    }
}