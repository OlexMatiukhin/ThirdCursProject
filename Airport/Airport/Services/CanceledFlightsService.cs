using Airport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Services
{
    
    public class CanceledFlightsService
    {
        private readonly IMongoCollection<CanceledFlightInfo> _canceledFligthCollection;

        public CanceledFlightsService()
        {

            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _canceledFligthCollection = database.GetCollection<CanceledFlightInfo>("canceledFlightInfo");
        }

        public List<CanceledFlightInfo> GetCanceledFlightsData()
        {
            try
            {
                return _canceledFligthCollection.Find(b => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<CanceledFlightInfo>();
            }
        }
    }
}
