using Airport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Airport.Services.MongoDBSevice
{
    internal class TicketService
    {
        private readonly IMongoCollection<Ticket> _ticketCollection;

        public TicketService()
        {

            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _ticketCollection = database.GetCollection<Ticket>("ticket");
        }

        public Ticket GetTicketByPassangerId(int passangerId)
        {
            try
            {
                return _ticketCollection.Find(t => t.PassengerId==passangerId).First();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new Ticket();
            }

        }
        public int GetLastTicketId()
        {
            var lastTicket = _ticketCollection
                .Find(Builders<Ticket>.Filter.Empty)
                .Sort(Builders<Ticket>.Sort.Descending(f => f.TicketId))
                .Limit(1)
                .FirstOrDefault();

            return lastTicket?.TicketId ?? 0;
        }
        
       public List<Ticket>GetTicketsByFlightId(int flightId)
        {

            try
            {
                return _ticketCollection.Find(t => t.FlightId==flightId).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<Ticket>();
            }
        }


        public List<Ticket> GetTicketsData()
        {
            try
            {
                return _ticketCollection.Find(t => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<Ticket>();
            }
        }


        public Ticket GetTicketById(int ticketId)
        {
            try
            {
                return _ticketCollection.Find(t => t.TicketId == ticketId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return null;
            }
        }


        public void AddTicket(Ticket ticket)
        {
            try
            {
                _ticketCollection.InsertOne(ticket);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при добавлении данных: {ex.Message}");
            }
        }


        public void UpdateTicket(Ticket ticket)
        {
            try
            {
                var filter = Builders<Ticket>.Filter.Eq(t => t.TicketId, ticket.TicketId);
                _ticketCollection.ReplaceOne(filter, ticket);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при обновлении данных: {ex.Message}");
            }
        }

        public void DeleteTicketsByFlightId(int flightId)
        {
            try
            {
                var result = _ticketCollection.DeleteMany(f=> f.FlightId == flightId);
           
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при удалении пассажира: {ex.Message}");

            }
        }
        public void DeleteTicket(int ticketId)
        {
            try
            {
                var filter = Builders<Ticket>.Filter.Eq(t => t.TicketId, ticketId);
                _ticketCollection.DeleteOne(filter);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при удалении данных: {ex.Message}");
            }
        }
    }
}
