using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.ComponentModel;

namespace Airport.Models
{
    public class RefundedTicketInfo : INotifyPropertyChanged
    {
        private int _refundedTicketId;
        private DateTime _date;
        private int _routeId;
        private int _age;
        private decimal _price;
        private string _gender;
        private string _fullname;
        private int _ticketId;
        private int _flightId;

        [BsonId]
        public int RefundedTicketId
        {
            get => _refundedTicketId;
            set
            {
                if (_refundedTicketId != value)
                {
                    _refundedTicketId = value;
                    OnPropertyChanged(nameof(RefundedTicketId));
                }
            }
        }

        [BsonElement("date")]
        public DateTime Date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged(nameof(Date));
                }
            }
        }

        [BsonElement("routeId")]
        public int RouteId
        {
            get => _routeId;
            set
            {
                if (_routeId != value)
                {
                    _routeId = value;
                    OnPropertyChanged(nameof(RouteId));
                }
            }
        }

        [BsonElement("age")]
        public int Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged(nameof(Age));
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

        [BsonElement("gender")]
        public string Gender
        {
            get => _gender;
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }

        [BsonElement("fullname")]
        public string Fullname
        {
            get => _fullname;
            set
            {
                if (_fullname != value)
                {
                    _fullname = value;
                    OnPropertyChanged(nameof(Fullname));
                }
            }
        }

        [BsonElement("ticketId")]
        public int TicketId
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

        [BsonElement("flightId")]
        public int FlightId
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
