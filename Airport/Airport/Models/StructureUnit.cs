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
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.ComponentModel;


  
        public class StructureUnit : INotifyPropertyChanged
        {
            private ObjectId _structureUnitId;
            private string _departmentName;
            private string _structureUnitName;
            private string _type;

            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public ObjectId StructureUnitId
            {
                get => _structureUnitId;
                private set
                {
                    if (_structureUnitId != value)
                    {
                        _structureUnitId = value;
                        OnPropertyChanged(nameof(StructureUnitId));
                    }
                }
            }

            [BsonElement("departmentName")]
            public string DepartmentName
            {
                get => _departmentName;
                set
                {
                    if (_departmentName != value)
                    {
                        _departmentName = value;
                        OnPropertyChanged(nameof(DepartmentName));
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

            [BsonElement("type")]
            public string Type
            {
                get => _type;
                set
                {
                    if (_type != value)
                    {
                        _type = value;
                        OnPropertyChanged(nameof(Type));
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
                return $"ID: {StructureUnitId}, Department Name: {DepartmentName}, Structure Unit Name: {StructureUnitName}, Type: {Type}";
            }
        }
    



}
