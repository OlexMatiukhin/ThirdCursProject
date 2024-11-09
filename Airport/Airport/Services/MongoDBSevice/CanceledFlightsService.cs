using Airport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Services.MongoDBSevice
{

    public class CanceledFlightsService
    {
        private readonly IMongoCollection<CanceledFlightInfo> _canceledFlightCollection;

        public CanceledFlightsService()
        {

            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _canceledFlightCollection = database.GetCollection<CanceledFlightInfo>("canceledFlightInfo");
        }

        public void AddCanceledFlight(Flight flight, string reason, string description )
        {
            var canceledFlightInfo = new CanceledFlightInfo
            {
                FlightNumber = flight.FlightNumber,
                Status = "Canceled",
                Category = flight.Category,
                DispatchBrigadeId = flight.DispatchBrigadeId,
                NavigationBrigadeId = flight.NavigationBrigadeId,
                FlightBrigadeId = flight.FlightBrigadeId,
                InspectionBrigadeId = flight.InspectionBrigadeId,
                RouteNumber = flight.RouteNumber,
                WorkerId = null,
                Reason = reason,
                Description = description

            };

            try
            {
                _canceledFlightCollection.InsertOne(canceledFlightInfo);
                Console.WriteLine("Данные о canceled flight успешно добавлены.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении данных: {ex.Message}");
            }
        }

        public List<CanceledFlightInfo> GetCanceledFlightsData()
        {
            try
            {
                return _canceledFlightCollection.Find(b => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<CanceledFlightInfo>();
            }
        }
    }
}
