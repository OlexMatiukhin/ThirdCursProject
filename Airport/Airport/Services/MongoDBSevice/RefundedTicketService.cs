using Airport.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Services.MongoDBSevice
{
    internal class RefundedTicketService
    {
        private readonly IMongoCollection<RefundedTicketInfo> _refundedTicketCollection;

        public RefundedTicketService()
        {
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _refundedTicketCollection = database.GetCollection<RefundedTicketInfo>("refundedTicket");
        }

        public void DeleteRefundedTicket(ObjectId refundedTicketId)
        {
            try
            {
                
                var result = _refundedTicketCollection.DeleteOne(r => r.RefundedTicketId == refundedTicketId);

          
                if (result.DeletedCount > 0)
                {
                    Console.WriteLine($"Возврат билета с ID {refundedTicketId} успешно удален.");
                }
                else
                {
                    Console.WriteLine($"Возврат билета с ID {refundedTicketId} не найден.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении данных: {ex.Message}");
            }
        }


        public void AddRefundedTicketInfo(Ticket ticket, Passenger passenger)
        {
            try
            {
                if (ticket == null)
                {
                    Console.WriteLine("Переданный билет равен null.");
                    return;
                }


                var refundedTicket = new RefundedTicketInfo
                {
                    RefundedTicketId = ObjectId.GenerateNewId(),
                    Date = DateTime.UtcNow,
                    RouteId = ticket.FlightId,
                    Age = passenger.Age,
                    Price = ticket.Price,
                    Gender = passenger.Gender,
                    Fullname = passenger.FullName,
                    TicketId = ticket.TicketId,
                    FlightId = ticket.FlightId
                };


                _refundedTicketCollection.InsertOne(refundedTicket);

                Console.WriteLine($"Возврат билета для TicketId {ticket.TicketId} успешно добавлен.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении возврата билета: {ex.Message}");
            }
        }



        public List<RefundedTicketInfo> GetRefundedTicketsData()
        {
            try
            {
                return _refundedTicketCollection.Find(r => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<RefundedTicketInfo>();
            }
        }
    }
}

