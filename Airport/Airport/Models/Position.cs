using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.ComponentModel;


    

    namespace Airport.Models
    {
        public class Position : INotifyPropertyChanged
        {
            private ObjectId _positionId;
            private string _positionName;
            private decimal _salary;
            private string _structureUnitName;

            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public ObjectId PositionId
            {
                get => _positionId;
                private set
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

            public override string ToString()
            {
                return $"Position: {PositionName}, Salary: {Salary}, Structure Unit: {StructureUnitName}";
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


