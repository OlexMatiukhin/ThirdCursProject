using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;

public class Brigade : INotifyPropertyChanged
{
    private int _brigadeId;
    private string _brigadeType;
    private int _structureUnitId;
    private int _numberWorkers;

    [BsonId]
    public int BrigadeId
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

    [BsonElement("brigadeType")]
    public string BrigadeType
    {
        get => _brigadeType;
        set
        {
            if (_brigadeType != value)
            {
                _brigadeType = value;
                OnPropertyChanged(nameof(BrigadeType));
            }
        }
    }

    [BsonElement("structureUnitId")]
    public int StructureUnitId
    {
        get => _structureUnitId;
        set
        {
            if (_structureUnitId != value)
            {
                _structureUnitId = value;
                OnPropertyChanged(nameof(StructureUnitId));
            }
        }
    }

    [BsonElement("numberWorkers")]
    public int NumberWorkers
    {
        get => _numberWorkers;
        set
        {
            if (_numberWorkers != value)
            {
                _numberWorkers = value;
                OnPropertyChanged(nameof(NumberWorkers));
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
        return $"{BrigadeId}: Тип: {BrigadeType}, Структурна одиниця: {StructureUnitId}";
    }
}
