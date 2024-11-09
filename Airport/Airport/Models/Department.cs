using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.ComponentModel;

namespace Airport.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using System.ComponentModel;

    
        public class Department : INotifyPropertyChanged
        {
            private ObjectId _departmentId; 
            private string _departmentName;

            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public ObjectId DepartmentId
            {
                get => _departmentId;
                set
                {
                    if (_departmentId != value)
                    {
                        _departmentId = value;
                        OnPropertyChanged(nameof(DepartmentId));
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

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public override string ToString()
            {
                return $"DepartmentId: {DepartmentId}, DepartmentName: {DepartmentName}";
            }
        }
    

}

