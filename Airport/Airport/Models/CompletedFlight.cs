using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;

namespace Airport.Models
{
    
        public class CompletedFlight : INotifyPropertyChanged
        {
            private ObjectId _completedFlightId;
            private string _flightNumber;
            private string _status;
            private string _category;
            private ObjectId _dispatchBrigadeId;
            private ObjectId _navigationBrigadeId;
            private DateTime _dateDeparture;
            private DateTime _dateArrival;
            private ObjectId _flightBrigadeId;
            private ObjectId _inspectionBrigadeId;
            private string _routeNumber;

            [BsonId]
            public ObjectId CompletedFlightId
            {
                get => _completedFlightId;
                set
                {
                    if (_completedFlightId != value)
                    {
                        _completedFlightId = value;
                        OnPropertyChanged(nameof(CompletedFlightId));
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

            [BsonElement("dateDeparture")]
            [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
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
            [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
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

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }



