using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.ComponentModel;

using System;
using System.ComponentModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Airport.Models
{
    public class Seat : INotifyPropertyChanged
    {
        private ObjectId _seatId;
        private int _number;
        private string _status;
        private ObjectId _flightId;

        [BsonId]
        [BsonElement("_id")]
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

        [BsonElement("number")]
        public int Number
        {
            get => _number;
            set
            {
                if (_number != value)
                {
                    _number = value;
                    OnPropertyChanged(nameof(Number));
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

        [BsonElement("flightId")]
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"Seat ID: {SeatId}, Number: {Number}, Status: {Status}, Flight ID: {FlightId}";
        }
    }
}
