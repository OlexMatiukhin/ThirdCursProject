using Airport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace Airport.Services
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

