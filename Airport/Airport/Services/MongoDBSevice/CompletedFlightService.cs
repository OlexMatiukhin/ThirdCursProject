using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Airport.Models;
using MongoDB.Bson;

namespace Airport.Services.MongoDBSevice
{
    public class CompletedFlightService
    {
        private readonly IMongoCollection<CompletedFlight> _completedFlightCollection;

        public CompletedFlightService()
        {
           

            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _completedFlightCollection = database.GetCollection<CompletedFlight>("completedFlight");
        }


        public void DeleteCompletedFlight(ObjectId completedFlightId)
        {
            try
            {
                var result = _completedFlightCollection.DeleteOne(c => c.CompletedFlightId == completedFlightId);



            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }



        public void AddCompletedFlightFromFlight(Flight flight)
        {
            /*try
            {
                var completedFlight = new CompletedFlight
                {
                    FlightNumber = flight.FlightNumber,
                    Status = flight.Status,
                    Category = flight.Category,
                    DateDeparture = flight.DateDeparture,
                    DateArrival = flight.DateArrival,
                    DispatchBrigadeId = flight.DispatchBrigadeId,
                    NavigationBrigadeId = flight.NavigationBrigadeId,
                    FlightBrigadeId = flight.FlightBrigadeId,
                    InspectionBrigadeId = flight.InspectionBrigadeId,
                    RouteId = flight.RouteId
                };

                _completedFlightCollection.InsertOne(completedFlight);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при добавлении завершенного рейса: {ex.Message}");
            }*/
        }

        public List<CompletedFlight> GetCompletedFlightsData()
        {
            try
            {
                return _completedFlightCollection.Find(b => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<CompletedFlight>();
            }
        }
    }

}
