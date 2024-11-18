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
using System.Windows.Media.Media3D;

namespace Airport.ViewModels.WindowViewModels
{
    
    public class PassengersViewModel : INotifyPropertyChanged
    {


        private readonly UserService _userService;
        private ObservableCollection<Passenger> _passengers;

        private FlightService _flightService;
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
        private User _user;
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


        public ICommand CheckCustomsContolCommand { get; }

        public ICommand RegistratreCommand { get; }

        private readonly IWindowService _windowService;
        public ICommand LogoutCommand { get; }
        public PassengersViewModel(IWindowService _windowService, User user)
        {
            _passengerService = new PassengerService();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            CheckCustomsContolCommand = new RelayCommand(СheckCustomsControl);
            RegistratreCommand = new RelayCommand(RegistrPassanger);
            _flightService = new FlightService();   
            _windowService = new WindowService();
            this._windowService=_windowService;
            _userService = new UserService();
            this._user = user;
            Login = _user.Login;
            AccessRight = _user.AccessRight;
            LogoutCommand = new RelayCommand(OnLogoutCommand);


            LoadPassengers();
        }


        private void OnLogoutCommand(object parameter)
        {
            _windowService.OpenWindow("LoginView", _user);
            _windowService.CloseWindow();
        }



        private void OnMainWindowOpen(object parameter)
            {

            _windowService.OpenWindow("MainMenuView", _user);
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
            if (_userService.IfUserCanDoAdditionalActions(_user))
            {
                var passenger = parameter as Passenger;
                if (passenger != null)
                {
                    Flight flight = _flightService.GetFlightById(passenger.FlightId);
                    string flightStatus = flight.Status;
                    if (flightStatus != "запланований")
                    {
                        MessageBox.Show("Рейс має бути на стадії \"запланований\" ");
                        return;
                    }
                    MessageBoxResult result = MessageBox.Show(
                      "Пасажир пройшов перевікрку?",
                      "Проходження митної перервірки",
                      MessageBoxButton.YesNo,
                      MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        passenger.CustomsControlStatus = "перевірений";
                        _passengerService.UpdatePassenger(passenger);
                        LoadPassengers();
                    }

                }
            }
        }

        private void RegistrPassanger(object parameter)
        {

            if (_userService.IfUserCanDoAdditionalActions(_user))
            {
                var passenger = parameter as Passenger;

                string flightStatus = _flightService.GetFlightById(passenger.FlightId).Status;
                if (flightStatus != "запланований")
                {
                    MessageBox.Show("Рейс має бути на стадії \"запланований\" ");
                    return;
                }
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
                        LoadPassengers();
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
                
        }
 


        private void OnEdit(object parameter)
        {

            if (_userService.IfUserCanDoCrud(_user))
            {

                var passanger = parameter as Passenger;
                if (passanger != null)
                {
                    _windowService.OpenModalWindow("ChangePilotMedExam", passanger);

                }
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
