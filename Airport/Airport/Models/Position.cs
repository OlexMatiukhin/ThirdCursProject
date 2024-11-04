using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.ComponentModel;

namespace Airport.Models
{
    public class Position : INotifyPropertyChanged
    {
        private int _positionId;
        private string _positionName;
        private decimal _salary;
        private int _structureUnitId;

        [BsonId]
        public int PositionId
        {
            get => _positionId;
            set
            {
                if (_positionId != value)
                {
                    _positionId = value;
                    OnPropertyChanged(nameof(PositionId));
                }
            }
        }

        [BsonElement("positionName")]
        public string PositionName
        {
            get => _positionName;
            set
            {
                if (_positionName != value)
                {
                    _positionName = value;
                    OnPropertyChanged(nameof(PositionName));
                }
            }
        }

        [BsonElement("salary")]
        public decimal Salary
        {
            get => _salary;
            set
            {
                if (_salary != value)
                {
                    _salary = value;
                    OnPropertyChanged(nameof(Salary));
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

        public override string ToString()
        {
            return $"Position: {PositionName}, Salary: {Salary}, Structure Unit ID: {StructureUnitId}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
