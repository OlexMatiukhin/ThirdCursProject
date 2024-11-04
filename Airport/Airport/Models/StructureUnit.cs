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
    public class StructureUnit : INotifyPropertyChanged
    {
        private int _structureUnitId;
        private string _structureUnitName;
        private string _type;
        private int _departmentId;

        [BsonId]
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

        [BsonElement("departmentId")]
        public int DepartmentId
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"ID: {StructureUnitId}, Name: {StructureUnitName}, Type: {Type}";
        }
    }
}
