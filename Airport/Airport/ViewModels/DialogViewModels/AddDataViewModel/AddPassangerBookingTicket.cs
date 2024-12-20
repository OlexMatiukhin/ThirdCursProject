﻿using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    internal class AddPassangerBookingTicket:INotifyPropertyChanged
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


        public AddPassangerBookingTicket(IWindowService windowService, Ticket ticket)
        {

            _passengerService = new PassengerService();


            AddPassengerCommand = new RelayCommand(ExecutePassangerAdd, canExecute => true);
            this._windowService = windowService;
            this._ticketService = new TicketService();
           this._ticket = ticket;



        }

        private void ExecutePassangerAdd(object parameter)
        {
            if (ValidateInputs())
            {
                MessageBoxResult result = MessageBox.Show(
                    "Забронювати  квиток?",
                    "Бронювання квитка",
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

                  
                    this._ticket.Status = "заброньований";


                    _ticketService.UpdateTicket(_ticket);


                    MessageBox.Show("Об'єкт упішно додано!");
                    _windowService.CloseModalWindow();

                    _ticketService.UpdateTicket(this._ticket);


                    _passengerService.AddPassenger(newPassenger);
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




