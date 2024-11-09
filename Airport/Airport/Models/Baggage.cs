using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Airport.Models
{
    public class Baggage : INotifyPropertyChanged
    {
        private ObjectId _baggageId;
        private ObjectId _flightId;
        private string _baggageType;
        private double _weight;
        private decimal _payment;
        private ObjectId? _passengerId;

        // MongoDB ObjectId for the baggage
        [BsonId]
        public ObjectId BaggageId
        {
            get => _baggageId;
            set
            {
                if (_baggageId != value)
                {
                    _baggageId = value;
                    OnPropertyChanged(nameof(BaggageId));
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

        [BsonElement("type")]
        public string BaggageType
        {
            get => _baggageType;
            set
            {
                if (_baggageType != value)
                {
                    _baggageType = value;
                    OnPropertyChanged(nameof(BaggageType));
                }
            }
        }

        [BsonElement("weight")]
        public double Weight
        {
            get => _weight;
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    OnPropertyChanged(nameof(Weight));
                }
            }
        }

        [BsonElement("payment")]
        public decimal Payment
        {
            get => _payment;
            set
            {
                if (_payment != value)
                {
                    _payment = value;
                    OnPropertyChanged(nameof(Payment));
                }
            }
        }

        [BsonElement("passengerId")]
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
    }
}
