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
        private int _baggageId;
        private string _baggageType;
        private double _weight;
        private decimal _payment;
        private int _passangerId;

        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int BaggageId
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

        [BsonElement("passangerId")]
        public int PassangerId
        {
            get => _passangerId;
            set
            {
                if (_passangerId != value)
                {
                    _passangerId = value;
                    OnPropertyChanged(nameof(PassangerId));
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
