using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Airport.Models
{
    public class Route : INotifyPropertyChanged
    {
        private int _routeId;
        private string _number;
        private string _departurePoint;
        private string _arrivalPoint;
        private string _transitAirport;
        private string _flightDirection;

        [BsonId]
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

        [BsonElement("number")]
        public string Number
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

        [BsonElement("departurePoint")]
        public string DeparturePoint
        {
            get => _departurePoint;
            set
            {
                if (_departurePoint != value)
                {
                    _departurePoint = value;
                    OnPropertyChanged(nameof(DeparturePoint));
                }
            }
        }

        [BsonElement("arrivalPoint")]
        public string ArrivalPoint
        {
            get => _arrivalPoint;
            set
            {
                if (_arrivalPoint != value)
                {
                    _arrivalPoint = value;
                    OnPropertyChanged(nameof(ArrivalPoint));
                }
            }
        }

        [BsonElement("transitAirport")]
        public string TransitAirport
        {
            get => _transitAirport;
            set
            {
                if (_transitAirport != value)
                {
                    _transitAirport = value;
                    OnPropertyChanged(nameof(TransitAirport));
                }
            }
        }

        [BsonElement("flightDirection")]
        public string FlightDirection
        {
            get => _flightDirection;
            set
            {
                if (_flightDirection != value)
                {
                    _flightDirection = value;
                    OnPropertyChanged(nameof(FlightDirection));
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
            return $"{RouteId}: Номер {Number}, Точка відправлення {DeparturePoint}, Точка прибуття {ArrivalPoint}, Проміжний пункт {TransitAirport}, Напрям: {FlightDirection}";
        }
    }
}

