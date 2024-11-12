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

namespace Airport.ViewModels.WindowViewModels
{


   

    public class PassengersCompletedFlightViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PassengerCompletedFlight> _passengers;
        public ICommand DeleteWindowCommand { get; }
        public ObservableCollection<PassengerCompletedFlight> Passengers
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

                Passengers = new ObservableCollection<PassengerCompletedFlight>(searchResult);

            }

        }

        private void OnDelete(object parameter)
        {

            var passengerCompletedFlight = parameter as PassengerCompletedFlight;
            if (passengerCompletedFlight != null)
            {

                MessageBoxResult resultOther = MessageBox.Show(
                             "Ви точно хочете видалити інформацію про завершений рейс?",
                             "Видалення інформації",
                             MessageBoxButton.YesNo,
                             MessageBoxImage.Warning);
                if (resultOther == MessageBoxResult.Yes)
                {

                    _passengerService.DeletePassengerCompletedFlight(passengerCompletedFlight.PassengerId);
                    MessageBox.Show(
                            " Інформацію упішно видалено?",
                              "Видалення інформації",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                }


            }
        
            




        }

        private PassengerCompletedFlightService _passengerService;

        private IWindowService _windowService;
        public ICommand OpenMainWindowCommand { get; }
        public PassengersCompletedFlightViewModel(IWindowService _windowService)
        {
            _passengerService = new PassengerCompletedFlightService();
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            this._windowService = _windowService;
            DeleteWindowCommand = new RelayCommand(OnDelete);
            LoadPassengers();
        }
        public List<PassengerCompletedFlight> SearchPassengers(string query)
        {
            return Passengers.Where(passenger =>
                passenger.PassengerId.ToString().Contains(query) ||                     // Поиск по PassengerId
                passenger.Age.ToString().Contains(query) ||                             // Поиск по Age
                passenger.Gender.Contains(query, StringComparison.OrdinalIgnoreCase) || // Поиск по Gender
                passenger.PassportNumber.Contains(query, StringComparison.OrdinalIgnoreCase) || // Поиск по PassportNumber
                passenger.InternPassportNumber.Contains(query, StringComparison.OrdinalIgnoreCase) || // Поиск по InternPassportNumber
                passenger.BaggageStatus.Contains(query, StringComparison.OrdinalIgnoreCase) || // Поиск по BaggageStatus
                passenger.PhoneNumber.Contains(query, StringComparison.OrdinalIgnoreCase) ||   // Поиск по PhoneNumber
                passenger.Email.Contains(query, StringComparison.OrdinalIgnoreCase) ||         // Поиск по Email
                passenger.FullName.Contains(query, StringComparison.OrdinalIgnoreCase) ||      // Поиск по FullName
                passenger.CompletedFlightId.ToString().Contains(query) // Поиск по CompletedFlightId
            ).ToList();
        }


        private void OnMainWindowOpen(object parameter)
        {

            _windowService.OpenWindow("MainMenuView");
            _windowService.CloseWindow();

        }
        private void LoadPassengers()
        {
            try
            {
                var passengerList = _passengerService.GetPassengerCompletedFlightsData();
                Passengers = new ObservableCollection<PassengerCompletedFlight>(passengerList);
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
