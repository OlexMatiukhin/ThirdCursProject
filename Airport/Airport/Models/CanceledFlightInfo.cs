using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

public class CanceledFlightInfo : INotifyPropertyChanged
{
    private int _canceledFlightInfoId;
    private string _flightNumber;
    private string _status;
    private string _category;
    private int _dispatchBrigadeId;
    private int _navigationBrigadeId;
    private int _flightBrigadeId;
    private int _unoccupiedSeatNumber;
    private int _seatNumber;
    private int _inspectionBrigadeId;
    private int _routeId;
    private string _description;
    private int _workerId;
    private string _reason;

    [BsonId]
    public int CanceledFlightInfoId
    {
        get => _canceledFlightInfoId;
        set
        {
            if (_canceledFlightInfoId != value)
            {
                _canceledFlightInfoId = value;
                OnPropertyChanged(nameof(CanceledFlightInfoId));
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

    [BsonElement("unoccupiedSeatNumber")]
    public int UnoccupiedSeatNumber
    {
        get => _unoccupiedSeatNumber;
        set
        {
            if (_unoccupiedSeatNumber != value)
            {
                _unoccupiedSeatNumber = value;
                OnPropertyChanged(nameof(UnoccupiedSeatNumber));
            }
        }
    }

    [BsonElement("seatNumber")]
    public int SeatNumber
    {
        get => _seatNumber;
        set
        {
            if (_seatNumber != value)
            {
                _seatNumber = value;
                OnPropertyChanged(nameof(SeatNumber));
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

    [BsonElement("workerId")]
    public int WorkerId
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

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

