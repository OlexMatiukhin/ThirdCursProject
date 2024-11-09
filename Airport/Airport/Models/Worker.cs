using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.ComponentModel;

namespace Airport.Models
{
    public class Worker : INotifyPropertyChanged
    {
        private ObjectId _workerId;
        private string _fullName;
        private int _age;
        private string _status;
        private string _gender;
        private int _numberChildren;
        private DateTime _hireDate;
        private string _shift;
        private string _email;
        private string _phoneNumber;
        private ObjectId? _brigadeId;
        private string _positionName;
        private DateTime _lastMedExamDate;
        private string _resultMedExam;

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId WorkerId
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

        [BsonElement("fullName")]
        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        [BsonElement("age")]
        public int Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged(nameof(Age));
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

        [BsonElement("gender")]
        public string Gender
        {
            get => _gender;
            set
            {
                if (_gender != value)
                {
                    _gender = value;
                    OnPropertyChanged(nameof(Gender));
                }
            }
        }

        [BsonElement("numberChildrens")]
        public int NumberChildren
        {
            get => _numberChildren;
            set
            {
                if (_numberChildren != value)
                {
                    _numberChildren = value;
                    OnPropertyChanged(nameof(NumberChildren));
                }
            }
        }

        [BsonElement("hireDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime HireDate
        {
            get => _hireDate;
            set
            {
                if (_hireDate != value)
                {
                    _hireDate = value;
                    OnPropertyChanged(nameof(HireDate));
                }
            }
        }

        [BsonElement("shift")]
        public string Shift
        {
            get => _shift;
            set
            {
                if (_shift != value)
                {
                    _shift = value;
                    OnPropertyChanged(nameof(Shift));
                }
            }
        }

        [BsonElement("email")]
        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        [BsonElement("phoneNumber")]
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged(nameof(PhoneNumber));
                }
            }
        }

        [BsonElement("brigadeId")]
        public ObjectId? BrigadeId
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

        [BsonElement("lastMedExamDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime LastMedExamDate
        {
            get => _lastMedExamDate;
            set
            {
                if (_lastMedExamDate != value)
                {
                    _lastMedExamDate = value;
                    OnPropertyChanged(nameof(LastMedExamDate));
                }
            }
        }

        [BsonElement("resultMedExam")]
        public string ResultMedExam
        {
            get => _resultMedExam;
            set
            {
                if (_resultMedExam != value)
                {
                    _resultMedExam = value;
                    OnPropertyChanged(nameof(ResultMedExam));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

