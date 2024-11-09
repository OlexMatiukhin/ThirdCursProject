using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel;


namespace Airport.Models
{
    public class DelayedFlightInfo : INotifyPropertyChanged
    {
        private ObjectId _delayedFlightInfoId;
        private string _flightNumber;
        private string _category;
        private ObjectId _dispatchBrigadeId;
        private ObjectId _navigationBrigadeId;
        private ObjectId _flightBrigadeId;
        private DateTime _startDelayDate;
        private DateTime? _endDelayDate;
        private ObjectId _inspectionBrigadeId;
        private string _reason;
        private ObjectId _flightId;
        private string _routeNumber;
        private ObjectId? _workerId;
        private string _description;

        [BsonId]
        public ObjectId DelayedFlightInfoId
        {
            get => _delayedFlightInfoId;
            set
            {
                if (_delayedFlightInfoId != value)
                {
                    _delayedFlightInfoId = value;
                    OnPropertyChanged(nameof(DelayedFlightInfoId));
                }
            }
        }

        [BsonElement("flightNumber")]
        public string FlightNumber
        {
            get => _flightNumber;
            set
            {
                if (_flightNumber != value)
                {
                    _flightNumber = value;
                    OnPropertyChanged(nameof(FlightNumber));
                }
            }
        }

        [BsonElement("category")]
        public string Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value;
                    OnPropertyChanged(nameof(Category));
                }
            }
        }

        [BsonElement("dispatchBrigadeId")]
        public ObjectId DispatchBrigadeId
        {
            get => _dispatchBrigadeId;
            set
            {
                if (_dispatchBrigadeId != value)
                {
                    _dispatchBrigadeId = value;
                    OnPropertyChanged(nameof(DispatchBrigadeId));
                }
            }
        }

        [BsonElement("navigationBrigadeId")]
        public ObjectId NavigationBrigadeId
        {
            get => _navigationBrigadeId;
            set
            {
                if (_navigationBrigadeId != value)
                {
                    _navigationBrigadeId = value;
                    OnPropertyChanged(nameof(NavigationBrigadeId));
                }
            }
        }

        [BsonElement("flightBrigadeId")]
        public ObjectId FlightBrigadeId
        {
            get => _flightBrigadeId;
            set
            {
                if (_flightBrigadeId != value)
                {
                    _flightBrigadeId = value;
                    OnPropertyChanged(nameof(FlightBrigadeId));
                }
            }
        }

        [BsonElement("startDelayDate")]
        public DateTime StartDelayDate
        {
            get => _startDelayDate;
            set
            {
                if (_startDelayDate != value)
                {
                    _startDelayDate = value;
                    OnPropertyChanged(nameof(StartDelayDate));
                }
            }
        }

        [BsonElement("endDelayDate")]
        public DateTime? EndDelayDate
        {
            get => _endDelayDate;
            set
            {
                if (_endDelayDate != value)
                {
                    _endDelayDate = value;
                    OnPropertyChanged(nameof(EndDelayDate));
                }
            }
        }

        [BsonElement("inspectionBrigadeId")]
        public ObjectId InspectionBrigadeId
        {
            get => _inspectionBrigadeId;
            set
            {
                if (_inspectionBrigadeId != value)
                {
                    _inspectionBrigadeId = value;
                    OnPropertyChanged(nameof(InspectionBrigadeId));
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

        [BsonElement("description")]
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
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

        [BsonElement("routeNumber")]
        public string RouteNumber
        {
            get => _routeNumber;
            set
            {
                if (_routeNumber != value)
                {
                    _routeNumber = value;
                    OnPropertyChanged(nameof(RouteNumber));
                }
            }
        }

        [BsonElement("workerId")]
        public ObjectId? WorkerId
        {
            get => _workerId;
            set
            {
                if (_workerId != value)
                {
                    _workerId = value;
                    OnPropertyChanged(nameof(WorkerId));
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



