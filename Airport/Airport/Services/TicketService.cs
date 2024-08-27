﻿using Airport.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Airport.Services
{
    internal class TicketService
    {
        private readonly IMongoCollection<Ticket> _ticketCollection;

        public TicketService()
        {
         
            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _ticketCollection = database.GetCollection<Ticket>("tickets"); 
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