using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;

namespace Airport.Models
{
    public class Flight : INotifyPropertyChanged
    {
        private int _flightId;
        private string _flightNumber;
        private string _status;
        private string _category;
        private DateTime _dateDeparture;
        private DateTime _dateArrival;
        private int _planeId;
        private int _dispatchBrigadeId;
        private int _navigationBrigadeId;
        private int _flightBrigadeId;
        private int _inspectionBrigadeId;
        private string _customsControl;
        private string _passengerRegistration ;
        private int _numberTickets = 0;
        private int _numberBoughtTickets = 0;
        private int _routeId;

        [BsonId]
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

        [BsonElement("dateDeparture")]
        public DateTime DateDeparture
        {
            get => _dateDeparture;
            set
            {
                if (_dateDeparture != value)
                {
                    _dateDeparture = value;
                    OnPropertyChanged(nameof(DateDeparture));
                }
            }
        }

        [BsonElement("dateArrival")]
        public DateTime DateArrival
        {
            get => _dateArrival;
            set
            {
                if (_dateArrival != value)
                {
                    _dateArrival = value;
                    OnPropertyChanged(nameof(DateArrival));
                }
            }
        }

        [BsonElement("planeId")]
        public int PlaneId
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

        [BsonElement("dispatchBrigadeId")]
        public int DispatchBrigadeId
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
        public int NavigationBrigadeId
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
        public int FlightBrigadeId
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

        [BsonElement("inspectionBrigadeId")]
        public int InspectionBrigadeId
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

        [BsonElement("customsControl")]
        public string CustomsControl
        {
            get => _customsControl;
            set
            {
                if (_customsControl != value)
                {
                    _customsControl = value;
                    OnPropertyChanged(nameof(CustomsControl));
                }
            }
        }

        [BsonElement("passengerRegistration")]
        public string PassengerRegistration
        {
            get => _passengerRegistration;
            set
            {
                if (_passengerRegistration != value)
                {
                    _passengerRegistration = value;
                    OnPropertyChanged(nameof(PassengerRegistration));
                }
            }
        }

        [BsonElement("numberTickets")]
        public int NumberTickets
        {
            get => _numberTickets;
            set
            {
                if (_numberTickets != value)
                {
                    _numberTickets = value;
                    OnPropertyChanged(nameof(NumberTickets));
                }
            }
        }

        [BsonElement("numberBoughtTickets")]
        public int NumberBoughtTickets
        {
            get => _numberBoughtTickets;
            set
            {
                if (_numberBoughtTickets != value)
                {
                    _numberBoughtTickets = value;
                    OnPropertyChanged(nameof(NumberBoughtTickets));
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

        public override string ToString()
        {
            return $"Flight ID: {FlightId}, Flight Number: {FlightNumber}, Status: {Status}, " +
                   $"Category: {Category}, Departure: {DateDeparture}, Arrival: {DateArrival}, " +
                   $"Plane ID: {PlaneId}, Dispatch Brigade ID: {DispatchBrigadeId}, " +
                   $"Navigation Brigade ID: {NavigationBrigadeId}, Flight Brigade ID: {FlightBrigadeId}, " +
                   $"Inspection Brigade ID: {InspectionBrigadeId}, Route ID: {RouteId}, " +
                   $"Customs Control: {CustomsControl}, Passenger Registration: {PassengerRegistration}, " +
                   $"Number of Tickets: {NumberTickets}, Number of Bought Tickets: {NumberBoughtTickets}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

