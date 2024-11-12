using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using MongoDB.Bson;
namespace Airport.Models
{
    public class Brigade : INotifyPropertyChanged
    {
        private ObjectId _brigadeId;
        private string _brigadeType;
        private int _numberWorkers;
        private string _structureUnitName;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId BrigadeId
        {
            get => _brigadeId;
            private set
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

        [BsonElement("structureUnitName")]
        public string StructureUnitName
        {
            get => _structureUnitName;
            set
            {
                if (_structureUnitName != value)
                {
                    _structureUnitName = value;
                    OnPropertyChanged(nameof(StructureUnitName));
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
            return $"ID: {BrigadeId}, Тип: {BrigadeType}, Кількість працівників: {NumberWorkers}, Назва структурної одиниці: {StructureUnitName}";
        }

        public static List<Brigade> SearchBrigades(List<Brigade> brigades, string query)
        {
            return brigades.Where(brigade =>
                brigade.BrigadeId.ToString().Contains(query, StringComparison.OrdinalIgnoreCase) ||
                brigade.BrigadeType.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                brigade.NumberWorkers.ToString().Contains(query) ||
                brigade.StructureUnitName.Contains(query, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
    }

}
