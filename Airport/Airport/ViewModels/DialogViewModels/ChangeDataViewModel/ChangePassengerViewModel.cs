using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using System.ComponentModel;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.ChangeDataViewModel
{
    public class ChangePassengerViewModel
    {
        private readonly PassengerService _passengerService;



        public ICommand ChangePassengerCommand { get; }

        public List<string> Gender { get; set; } = new List<string>
        {   "чоловік",
            "жінка"
        };
      


        private int _id;
        private string _gender;
        private string _passportNumber;
        private string _internPassportNumber;
        private string _selectedGender;
        private string _baggageStatus;
        private string _phoneNumber;
        private string _email;
        private string _fullName;
        private int _completedFlightId;
        private int _age;
        private string _customsControlStatus;
        private string _registrationStatus;
        private int _flightId ;
        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public string PassportNumber
        {
            get => _passportNumber;
            set
            {
                _passportNumber = value;
                OnPropertyChanged(nameof(PassportNumber));
            }
        }
        public string SelectedGender
        {
            get => _selectedGender;
            set
            {
                _selectedGender = value;
                OnPropertyChanged(nameof(SelectedGender));
            }
        }

        public string InternPassportNumber
        {
            get => _internPassportNumber;
            set
            {
                _internPassportNumber = value;
                OnPropertyChanged(nameof(InternPassportNumber));
            }
        }

        public string BaggageStatus 

        {
            get => _baggageStatus;
            set
            {
                _baggageStatus = value;
                OnPropertyChanged(nameof(_baggageStatus));
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public int CompletedFlightId
        {
            get => _completedFlightId;
            set
            {
                _completedFlightId = value;
                OnPropertyChanged(nameof(CompletedFlightId));
            }
        }


        public ChangePassengerViewModel(Passenger passenger)
        {
            _passengerService = new PassengerService();

            ChangePassengerCommand = new RelayCommand(ExecutePassangerChange, canExecute => true);
            _id=passenger.PassengerId;
            FullName = passenger.FullName;
            Age= passenger.Age;
            SelectedGender = passenger.Gender;
            PassportNumber= passenger.PassportNumber;
            InternPassportNumber= passenger.InternPassportNumber;
            BaggageStatus = passenger.BaggageStatus;
            PhoneNumber= passenger.PhoneNumber;
            Email = passenger.Email;
            _customsControlStatus= passenger.CustomsControlsStatus;
            _registrationStatus = passenger.RegistrationStatus;
            _flightId= passenger.FlightId;
        }

        private void ExecutePassangerChange(object parameter)
        {
          


            Passenger changePassenger = new Passenger
            {
                PassengerId = _id,
                FullName = FullName,
                Age = Age,
                Gender = SelectedGender,
                PassportNumber = PassportNumber,
                InternPassportNumber = InternPassportNumber,
                BaggageStatus = BaggageStatus,
                PhoneNumber = PhoneNumber,
                Email = Email,
                CustomsControlsStatus= _customsControlStatus,
                RegistrationStatus= _registrationStatus,
                FlightId = _flightId,

            };




            _passengerService.UpdatePassenger(changePassenger);
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
