using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using Airport.Models;

namespace Airport.Services
{
    internal class SeatService
    {
        private readonly IMongoCollection<Seat> _seatCollection;

        public SeatService()
        {

            var client = new MongoClient("mongodb+srv://aleks:administrator@cursproject.bsthnb0.mongodb.net/?retryWrites=true&w=majority&appName=CursProject");
            var database = client.GetDatabase("airport");
            _seatCollection = database.GetCollection<Seat>("seat"); 
        }
        public int GetLastSeatId()
        {
            var lastSeat = _seatCollection
                .Find(Builders<Seat>.Filter.Empty)
                .Sort(Builders<Seat>.Sort.Descending(f => f.SeatId))
                .Limit(1)
                .FirstOrDefault();

            return lastSeat?.SeatId ?? 0;
        }


        public List<Seat> GetSeatsData()
        {
            try
            {
                return _seatCollection.Find(s => true).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return new List<Seat>();
            }
        }

      
        public Seat GetSeatById(int seatId)
        {
            try
            {
                return _seatCollection.Find(s => s.SeatId == seatId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при получении данных: {ex.Message}");
                return null;
            }
        }

       
        public void AddSeat(Seat seat)
        {
            try
            {
                _seatCollection.InsertOne(seat);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при добавлении данных: {ex.Message}");
            }
        }

      
        public void UpdateSeat(Seat seat)
        {
            try
            {
                var filter = Builders<Seat>.Filter.Eq(s => s.SeatId, seat.SeatId);
                _seatCollection.ReplaceOne(filter, seat);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при обновлении данных: {ex.Message}");
            }
        }

    
        public void DeleteSeat(int seatId)
        {
            try
            {
                var filter = Builders<Seat>.Filter.Eq(s => s.SeatId, seatId);
                _seatCollection.DeleteOne(filter);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при удалении данных: {ex.Message}");
            }
        }
    }
}