using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.Airport.Services;
using Airport.Services.MongoDBService;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace Airport.ViewModels.WindowViewModels
{
    public class CompletedFlightsViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<CompletedFlight> _completedFlights;
        public event PropertyChangedEventHandler PropertyChanged;
        private User _user;

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

        public ICommand DeleteWindowCommand { get; }
        private readonly UserService _userService;
        public ObservableCollection<CompletedFlight> CompletedFlights
        {
            get => _completedFlights;
            set
            {
                if (_completedFlights != value)
                {
                    _completedFlights = value;
                    OnPropertyChanged(nameof(CompletedFlights));
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
        public CompletedFlightsViewModel(IWindowService _windowService, User user)
        {
            _completedFlightService = new CompletedFlightService();
            LoadCompletedFlights();
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            this._windowService = _windowService;
            DeleteWindowCommand = new RelayCommand(OnDelete);
            _userService = new UserService();
            this._user = user;
            Login = _user.Login;
            AccessRight = _user.AccessRight;
        }
        public void SearchOperation(string searchLine)
        {
            LoadCompletedFlights();
            if (!string.IsNullOrEmpty(searchLine))
            {
                var searchResult = SearchCompletedFlight(searchLine);

                CompletedFlights = new ObservableCollection<CompletedFlight>(searchResult);

            }

        }

        private CompletedFlightService _completedFlightService;
        private readonly IWindowService _windowService;



        private void OnDelete(object parameter)
        {
            if (_userService.IfUserCanDoCrud(_user))
            {
                var completedFlight = parameter as CompletedFlight;
                if (completedFlight != null)
                {

                    MessageBoxResult resultOther = MessageBox.Show(
                                 "Ви точно хочете видалити інформацію про завершений рейс?",
                                 "Видалення інформації",
                                 MessageBoxButton.YesNo,
                                 MessageBoxImage.Warning);
                    if (resultOther == MessageBoxResult.Yes)
                    {

                        _completedFlightService.DeleteCompletedFlight(completedFlight.CompletedFlightId);
                        MessageBox.Show(
                                " Інформацію упішно видалено!",
                                  "Видалення інформації",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                    }


                }
            }





        }

        public ICommand OpenMainWindowCommand { get; }
        public List<CompletedFlight> SearchCompletedFlight(string query)
        {
            return CompletedFlights.Where(flight =>
                flight.CompletedFlightId.ToString().Contains(query) ||
                flight.FlightNumber.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                flight.Status.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                flight.Category.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                flight.DispatchBrigadeId.ToString().Contains(query) ||
                flight.NavigationBrigadeId.ToString().Contains(query) ||
                flight.DateDeparture.ToString("yyyy-MM-dd").Contains(query) ||
                flight.DateArrival.ToString("yyyy-MM-dd").Contains(query) ||
                flight.FlightBrigadeId.ToString().Contains(query) ||
                flight.InspectionBrigadeId.ToString().Contains(query) ||
                flight.RouteNumber.Contains(query, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

       
        private void OnMainWindowOpen(object parameter)
        {

            _windowService.OpenWindow("MainMenuView");
            _windowService.CloseWindow();

        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private void LoadCompletedFlights()
        {
            try
            {
                var completedFlightList = _completedFlightService.GetCompletedFlightsData();
                CompletedFlights = new ObservableCollection<CompletedFlight>(completedFlightList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}