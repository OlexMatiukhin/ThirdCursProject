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
using System.Windows.Media.Media3D;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddPassengerViewModel
    {
        private readonly PassengerService _passengerService;
        private IWindowService _windowService;

        private readonly TicketService _ticketService;
        private readonly FlightService _flightService;
        




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
        private Flight _flight;


        
                  

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



        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(FullName) ||
                string.IsNullOrWhiteSpace(PassportNumber) ||
                string.IsNullOrWhiteSpace(SelectedGender) ||
                Age <= 0)
            {
                MessageBox.Show("Будь ласка, заповніть усі обов'язкові поля правильно.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }


        public  AddPassengerViewModel(IWindowService windowService,Ticket ticket, Flight flight) 
        {
           
                _passengerService = new PassengerService();


                AddPassengerCommand = new RelayCommand(ExecutePassangerAdd, canExecute => true);
                this._windowService = windowService;
                this._ticketService = new TicketService();
                _flight = flight;
            _flightService = new FlightService();
                this._ticket = ticket;

            
            
        }

        private void ExecutePassangerAdd(object parameter)
        {
            if (ValidateInputs())
            {
                MessageBoxResult result = MessageBox.Show(
                    "Купити  квиток?",
                    "Купівля квитка",
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

                    _passengerService.AddPassenger(newPassenger);
                    this._ticket.PassengerId = newPassenger.PassengerId;
                    this._ticket.Status = "куплений";
                   

                    _ticketService.UpdateTicket(_ticket);
                    _flight.NumberBoughtTickets++;
                    _flightService.UpdateFlight(_flight);

                    MessageBox.Show("Об'єкт упішно додано!");
                    _windowService.CloseModalWindow();

                    _ticketService.UpdateTicket(this._ticket);
                    

                 
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


