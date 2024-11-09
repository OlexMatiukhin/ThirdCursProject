using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;

public class CanceledFlightInfo : INotifyPropertyChanged
{
    private ObjectId _canceledFlightInfoId;  
    private string _flightNumber;
    private string _status;
    private string _category;
    private ObjectId _dispatchBrigadeId;
    private ObjectId _navigationBrigadeId;
    private ObjectId _flightBrigadeId;
    private int _unoccupiedSeatNumber;
    private int _seatNumber;
    private ObjectId _inspectionBrigadeId;
    private string _routeNumber;
    private string _description;
    private ObjectId? _workerId;
    private string _reason;

    [BsonId]  
    public ObjectId CanceledFlightInfoId
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

