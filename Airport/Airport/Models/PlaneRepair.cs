using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;

namespace Airport.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System;
    using System.ComponentModel;

    public class PlaneRepair : INotifyPropertyChanged
    {
        private ObjectId _planeRepairId;
        private DateTime _startDate;
        private string _status;
        private int _numberFlights;
        private DateTime? _endDate;
        private string _reason;
        private string _result;
        private ObjectId _brigadeId;
        private ObjectId _planeId;

        [BsonId]
        public ObjectId PlaneRepairId
        {
            get => _planeRepairId;
            set
            {
                if (_planeRepairId != value)
                {
                    _planeRepairId = value;
                    OnPropertyChanged(nameof(PlaneRepairId));
                }
            }
        }

        [BsonElement("startDate")]
        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
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

        [BsonElement("numberFlights")]
        public int NumberFlights
        {
            get => _numberFlights;
            set
            {
                if (_numberFlights != value)
                {
                    _numberFlights = value;
                    OnPropertyChanged(nameof(NumberFlights));
                }
            }
        }

        [BsonElement("endDate")]
        public DateTime? EndDate
        {
            get => _endDate;
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }

        [BsonElement("reason")]
        public string Reason
        {
            get => _reason;
            set
            {
                if (_reason != value)
                {
                    _reason = value;
                    OnPropertyChanged(nameof(Reason));
                }
            }
        }

        [BsonElement("result")]
        public string Result
        {
            get => _result;
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged(nameof(Result));
                }
            }
        }

        [BsonElement("brigadeId")]
        public ObjectId BrigadeId
        {
            get => _brigadeId;
            set
            {
                if (_brigadeId != value)
                {
                    _brigadeId = value;
                    OnPropertyChanged(nameof(BrigadeId));
                }
            }
        }

        [BsonElement("planeId")]
        public ObjectId PlaneId
        {
            get => _planeId;
            set
            {
                if (_planeId != value)
                {
                    _planeId = value;
                    OnPropertyChanged(nameof(PlaneId));
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


