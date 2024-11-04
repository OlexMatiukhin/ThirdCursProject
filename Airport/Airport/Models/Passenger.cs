using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel;

namespace Airport.Models
{
    public class Passenger : INotifyPropertyChanged
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
        private string _customsControlsStatus;
        private string _registrationStatus;
        private int _flightId;

        [BsonId]
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

        [BsonElement("bagageStatus")]
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

        [BsonElement("customsControlStatus")]
        public string CustomsControlsStatus
        {
            get => _customsControlsStatus;
            set
            {
                if (_customsControlsStatus != value)
                {
                    _customsControlsStatus = value;
                    OnPropertyChanged(nameof(CustomsControlsStatus));
                }
            }
        }

        [BsonElement("registrationStatus")]
        public string RegistrationStatus
        {
            get => _registrationStatus;
            set
            {
                if (_registrationStatus != value)
                {
                    _registrationStatus = value;
                    OnPropertyChanged(nameof(RegistrationStatus));
                }
            }
        }

        [BsonElement("flightId")]
        public int FlightId
        {
            get => _flightId;
            set
            {
                if (_flightId != value)
                {
                    _flightId = value;
                    OnPropertyChanged(nameof(FlightId));
                }
            }
        }

        public override string ToString()
        {
            return $"PassengerId: {PassengerId}, Fullname: {FullName}, Age: {Age}, Gender: {Gender}, " +
                   $"PassportNumber: {PassportNumber}, InternPassportNumber: {InternPassportNumber}, " +
                   $"BaggageStatus: {BaggageStatus}, PhoneNumber: {PhoneNumber}, Email: {Email}, " +
                   $"CustomControlStatus: {CustomsControlsStatus}, RegistrationStatus: {RegistrationStatus}, " +
                   $"FlightId: {FlightId}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}




