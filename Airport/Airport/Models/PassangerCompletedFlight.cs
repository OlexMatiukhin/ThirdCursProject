using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;

namespace Airport.Models
{
    public class PassengerCompletedFlight : INotifyPropertyChanged
    {
        private int _passengerId;
        private int _age;
        private string _gender;
        private string _passportNumber;
        private string _internPassportNumber;
        private string _baggageStatus;
        private string _phoneNumber;
        private string _email;
        private string _fullName;
        private int _completedFlightId;

        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int PassengerId
        {
            get => _passengerId;
            set
            {
                if (_passengerId != value)
                {
                    _passengerId = value;
                    OnPropertyChanged(nameof(PassengerId));
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

        [BsonElement("passportNumber")]
        public string PassportNumber
        {
            get => _passportNumber;
            set
            {
                if (_passportNumber != value)
                {
                    _passportNumber = value;
                    OnPropertyChanged(nameof(PassportNumber));
                }
            }
        }

        [BsonElement("internPassportNumber")]
        public string InternPassportNumber
        {
            get => _internPassportNumber;
            set
            {
                if (_internPassportNumber != value)
                {
                    _internPassportNumber = value;
                    OnPropertyChanged(nameof(InternPassportNumber));
                }
            }
        }

        [BsonElement("baggageStatus")]
        public string BaggageStatus
        {
            get => _baggageStatus;
            set
            {
                if (_baggageStatus != value)
                {
                    _baggageStatus = value;
                    OnPropertyChanged(nameof(BaggageStatus));
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

        [BsonElement("fullname")]
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

        [BsonElement("completedFlightId")]
        public int CompletedFlightId
        {
            get => _completedFlightId;
            set
            {
                if (_completedFlightId != value)
                {
                    _completedFlightId = value;
                    OnPropertyChanged(nameof(CompletedFlightId));
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

