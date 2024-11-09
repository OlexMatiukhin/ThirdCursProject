using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;

namespace Airport.Models
{
    public class Ticket : INotifyPropertyChanged
    {
        private ObjectId _ticketId;
        private string _status;
        private bool _availability;
        private DateTime _dateChanges;
        private decimal _price;
        private ObjectId _flightId;
        private ObjectId _seatId;
        private ObjectId? _passengerId;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId TicketId
        {
            get => _ticketId;
            set
            {
                if (_ticketId != value)
                {
                    _ticketId = value;
                    OnPropertyChanged(nameof(TicketId));
                }
            }
        }

        [BsonElement("status")]
        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        [BsonElement("availability")]
        public bool Availability
        {
            get => _availability;
            set
            {
                if (_availability != value)
                {
                    _availability = value;
                    OnPropertyChanged(nameof(Availability));
                }
            }
        }

        [BsonElement("dateChanges")]
       
        public DateTime DateChanges
        {
            get => _dateChanges;
            set
            {
                if (_dateChanges != value)
                {
                    _dateChanges = value;
                    OnPropertyChanged(nameof(DateChanges));
                }
            }
        }

        [BsonElement("price")]
        public decimal Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }

        [BsonElement("flightId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId FlightId
        {
            get => _flightId;
            set
            {
                if (_flightId != value)
                {
                    _flightId = value;
                    OnPropertyChanged(nameof(FlightId));
                }
            }
        }

        [BsonElement("seatId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId SeatId
        {
            get => _seatId;
            set
            {
                if (_seatId != value)
                {
                    _seatId = value;
                    OnPropertyChanged(nameof(SeatId));
                }
            }
        }

        [BsonElement("passengerId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId? PassengerId
        {
            get => _passengerId;
            set
            {
                if (_passengerId != value)
                {
                    _passengerId = value;
                    OnPropertyChanged(nameof(PassengerId));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"TicketId: {TicketId}, Status: {Status}, Availability: {Availability}, DateChanges: {DateChanges}, " +
                   $"Price: {Price}, FlightId: {FlightId}, SeatId: {SeatId}, PassengerId: {PassengerId}";
        }
    }
}

