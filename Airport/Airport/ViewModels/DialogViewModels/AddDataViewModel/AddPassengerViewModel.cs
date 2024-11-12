using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddPassengerViewModel
    {
        private readonly PassengerService _passengerService;
        private IWindowService _windowService;

        private readonly TicketService _ticketService;
      



        public ICommand CloseCommand { get; }




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
        private Ticket _ticket;


        
                  

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


        public  AddPassengerViewModel(IWindowService windowService,Ticket ticket) 
        {
            _passengerService = new PassengerService();
            
            AddPassengerCommand = new RelayCommand(ExecutePassangerAdd, canExecute => true);
            this._windowService = windowService;
            this._ticketService = new TicketService();

            this._ticket = ticket;
        }

        private void ExecutePassangerAdd(object parameter)
        {
            MessageBoxResult result = MessageBox.Show(
                    "Завершити затримку?",
                    "Завершення затримки",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {

                Passenger newPassenger = new Passenger
                {

                    FullName = FullName,
                    Age = Age,
                    Gender = SelectedGender,
                    PassportNumber = PassportNumber,
                    InternPassportNumber = InternPassportNumber,
                    BaggageStatus = BaggageStatus,
                    PhoneNumber = PhoneNumber,
                    Email = Email,
                    CustomsControlStatus = "не перевірений",
                    RegistrationStatus = "не зареєстрований",
                    FlightId = _ticket.FlightId,

                };
                this._ticket.PassengerId = newPassenger.PassengerId;
                this._ticket.Status = "куплений";


                _ticketService.UpdateTicket(this._ticket);

                _passengerService.AddPassenger(newPassenger);
            }
            
        }

     
      

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}


