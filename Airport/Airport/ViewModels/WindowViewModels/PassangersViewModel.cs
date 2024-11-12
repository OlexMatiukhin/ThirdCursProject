using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace Airport.ViewModels.WindowViewModels
{
    
    public class PassengersViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Passenger> _passengers;

        public ObservableCollection<Passenger> Passengers
        {
            get => _passengers;
            set
            {
                if (_passengers != value)
                {
                    _passengers = value;
                    OnPropertyChanged(nameof(Passengers));
                }
            }
        }


        private string _searchLine;



        public string SearchLine
        {
            get => _searchLine;
            set
            {

                _searchLine = value;
                SearchOperation(_searchLine);
                OnPropertyChanged(nameof(SearchLine));


            }
        }

        public void SearchOperation(string searchLine)
        {
            LoadPassengers();
            if (!string.IsNullOrEmpty(searchLine))
            {
                var searchResult = SearchPassengers(searchLine);

                Passengers = new ObservableCollection<Passenger>(searchResult);

            }

        }
        private PassengerService _passengerService;
        private TicketService _ticlService;

        public ICommand OpenEditWindowCommand { get; }

        public ICommand OpenMainWindowCommand { get; }
        
        private readonly IWindowService _windowService;

        public PassengersViewModel(IWindowService _windowService)
        {
            _passengerService = new PassengerService();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            _windowService = new WindowService();
            this._windowService=_windowService;
            LoadPassengers();
        }

        

             private void OnMainWindowOpen(object parameter)
            {

                _windowService.OpenWindow("MainMenuView");
                _windowService.CloseWindow();

                }
        public List<Passenger> SearchPassengers(string query)
        {
            return Passengers.Where(passenger =>
                passenger.PassengerId.ToString().Contains(query) ||                     
                passenger.Age.ToString().Contains(query) ||                             
                passenger.Gender.Contains(query, StringComparison.OrdinalIgnoreCase) || 
                passenger.PassportNumber.Contains(query, StringComparison.OrdinalIgnoreCase) || 
                passenger.InternPassportNumber.Contains(query, StringComparison.OrdinalIgnoreCase) || 
                passenger.BaggageStatus.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                passenger.PhoneNumber.Contains(query, StringComparison.OrdinalIgnoreCase) ||   
                passenger.Email.Contains(query, StringComparison.OrdinalIgnoreCase) ||         
                passenger.FullName.Contains(query, StringComparison.OrdinalIgnoreCase) ||     
                passenger.CustomsControlStatus.Contains(query, StringComparison.OrdinalIgnoreCase) || 
                passenger.RegistrationStatus.Contains(query, StringComparison.OrdinalIgnoreCase) ||  
                (passenger.FlightId!=null && passenger.FlightId.ToString().Contains(query)) 
            ).ToList();
        }


        private void СheckCustomsControl(object parameter)
        {

            var passenger = parameter as Passenger;
            if (passenger != null)
            {
                MessageBoxResult result = MessageBox.Show(
                  "Пасажир пройшов перевікрку?",
                  "Проходження митної перервірки",
                  MessageBoxButton.YesNo,
                  MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    passenger.CustomsControlStatus = "перевірений";
                    _passengerService.UpdatePassenger(passenger);
                }

            }
        }

        private void PasangerRegistration(object parameter)
        {

            var passenger = parameter as Passenger;
            if (passenger != null && passenger.CustomsControlStatus == "перевірений")
            {
                MessageBoxResult result = MessageBox.Show(
                  "Пасажир підходить?",
                  "Реєстрація пасажира",
                  MessageBoxButton.YesNo,
                  MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    passenger.RegistrationStatus = "зареєстрований";
                    _passengerService.UpdatePassenger(passenger);
                }

            }
            else
            {
                MessageBox.Show(
                      "Спершу пасжир має пройти митний контроль!",
                      "",
                      MessageBoxButton.OK,
                      MessageBoxImage.Error);
            }
                
        }
 


        private void OnEdit(object parameter)
        {

            var passanger = parameter as Passenger;
            if (passanger != null)
            {
                _windowService.OpenModalWindow("ChangePilotMedExam", passanger);         

            }

        }
        private void LoadPassengers()
        {
            try
            {
                var passengerList = _passengerService.GetPassengersData();
                Passengers = new ObservableCollection<Passenger>(passengerList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }





        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


}
