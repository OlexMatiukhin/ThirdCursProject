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
    public class Department : INotifyPropertyChanged
    {
        private int _departmentId;
        private string _departmentName;


        [BsonId]
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
