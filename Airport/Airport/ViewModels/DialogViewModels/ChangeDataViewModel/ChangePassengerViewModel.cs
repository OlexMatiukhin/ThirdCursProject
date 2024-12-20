﻿using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.ChangeDataViewModel
{
    public class ChangePassengerViewModel
    {
        private readonly PassengerService _passengerService;
        private IWindowService _windowService;
        private Passenger _passenger;
        


        public ICommand ChangePassengerCommand { get; }

        public List<string> Gender { get; set; } = new List<string>
        {   "чоловік",
            "жінка"
        };


       
   
        private string _passportNumber;
        private string _internPassportNumber;
        private string _selectedGender;
        private string _phoneNumber;
        private string _email;
        private string _fullName;
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

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(FullName))
            {
                MessageBox.Show("Будь ласка, введіть повне ім'я пасажира.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (Age <= 0)
            {
                MessageBox.Show("Будь ласка, введіть правильний вік пасажира.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrEmpty(SelectedGender))
            {
                MessageBox.Show("Будь ласка, виберіть стать пасажира.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrEmpty(PassportNumber))
            {
                MessageBox.Show("Будь ласка, введіть номер паспорта.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrEmpty(InternPassportNumber))
            {
                MessageBox.Show("Будь ласка, введіть номер міжнародного паспорта.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrEmpty(PhoneNumber))
            {
                MessageBox.Show("Будь ласка, введіть номер телефону.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrEmpty(Email) || !Email.Contains("@"))
            {
                MessageBox.Show("Будь ласка, введіть коректну електронну адресу.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;  // Return true if all fields are valid
        }


        public ChangePassengerViewModel(Passenger passenger, IWindowService windowService)
        {

            if (ValidateInputs())
            {
                this._passenger = passenger;
                _passengerService = new PassengerService();
                this._windowService = windowService;
                ChangePassengerCommand = new RelayCommand(ExecutePassangerChange, canExecute => true);

                FullName = passenger.FullName;
                Age = passenger.Age;
                SelectedGender = passenger.Gender;

                PassportNumber = passenger.PassportNumber;
                InternPassportNumber = passenger.InternPassportNumber;
                PhoneNumber = passenger.PhoneNumber;
                Email = passenger.Email;
            }
          
          
         
        }

        private void ExecutePassangerChange(object parameter)
        {
            _passenger.FullName = FullName;
            _passenger.Age = Age;
            _passenger.Gender = SelectedGender;
            _passenger.PassportNumber = PassportNumber;
            _passenger.InternPassportNumber = InternPassportNumber;
            _passenger.PhoneNumber = PhoneNumber;
            _passenger.Email = Email;
            _passengerService.UpdatePassenger(_passenger);
            System.Windows.MessageBox.Show("Об'єкт успішно змінено!");
            _windowService.CloseModalWindow();
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
