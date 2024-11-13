using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBService;
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
        private readonly UserService _userService;
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
        private string _login;
        private string _accessRight;


        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }


        public string AccessRight
        {
            get => _accessRight;
            set
            {
                _accessRight = value;
                OnPropertyChanged(nameof(AccessRight));
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
        private User _user;

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
        public PassengersCompletedFlightViewModel(IWindowService _windowService, User user)
        {
            _passengerService = new PassengerCompletedFlightService();
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            this._windowService = _windowService;
            DeleteWindowCommand = new RelayCommand(OnDelete);
            LoadPassengers();
            _userService = new UserService();


            Login = _user.Login;
            AccessRight = _user.AccessRight;
            this._user = user;
        }
        public List<PassengerCompletedFlight> SearchPassengers(string query)
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
                passenger.CompletedFlightId.ToString().Contains(query) // Поиск по CompletedFlightId
            ).ToList();
        }


        private void OnMainWindowOpen(object parameter)
        {
            if (_userService.IfUserCanDoCrud(_user))
            {

                _windowService.OpenWindow("MainMenuView");
                _windowService.CloseWindow();
            }

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
