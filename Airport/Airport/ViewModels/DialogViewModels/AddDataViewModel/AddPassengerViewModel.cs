using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddPassengerViewModel
    {
        private readonly PassengerService _passengerService;
      
   

        public ICommand AddPassengerCommand { get; }

        public List<string> Gender { get; set; } = new List<string>
        {   "чоловік",
            "жінка"
        };

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
                OnPropertyChanged(nameof(BaggageStatus));
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


        public  AddPassengerViewModel()
        {
            _passengerService = new PassengerService();
            
            AddPassengerCommand = new RelayCommand(ExecutePassangerAdd, canExecute => true);

          



        }

        private void ExecutePassangerAdd(object parameter)
        {
            int passangerId = _passengerService.GetLastPassengerId()+ 1;


            Passenger newPassenger = new Passenger
            {
                PassengerId = passangerId,           
                FullName = FullName,                 
                Age = Age,                          
                Gender = SelectedGender,                    
                PassportNumber = PassportNumber,    
                InternPassportNumber = InternPassportNumber,
                BaggageStatus = BaggageStatus,    
                PhoneNumber = PhoneNumber,           
                Email = Email,                       
            };




            _passengerService.AddPassenger(newPassenger);
        }

     
      

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}


