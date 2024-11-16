using Airport.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;
using Airport.Services.MongoDBSevice;
using Airport.Services;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows;
using Airport.Command.AddDataCommands.Airport.Commands;
using System.ComponentModel;
using Airport.Services.MongoDBService;

namespace Airport.ViewModels.WindowViewModels
{


    public class DelayedFlightsViewModel: INotifyPropertyChanged
    {
        private readonly IWindowService _windowService;

     
        public ICommand OpenMainWindowCommand { get; }
        private readonly UserService _userService;
        public ICommand DeleteWindowCommand { get; }

        private ObservableCollection<DelayedFlightInfo> _delayedFlights;



        public ObservableCollection<DelayedFlightInfo> DelayedFlights
        {
            get => _delayedFlights;
            set
            {
                if (_delayedFlights != value)
                {
                    _delayedFlights = value;
                    OnPropertyChanged(nameof(DelayedFlights));
                }
            }
        }

        private User _user;

        private string _searchLine;


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
            LoadDelayedFlights();
            if (!string.IsNullOrEmpty(searchLine))
            {
                var searchResult = SearchDelayedFlightInfo(searchLine);

                DelayedFlights = new ObservableCollection<DelayedFlightInfo>(searchResult);

            }

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private DelayedFlightsService _delayedFlightsService;
        private FlightService _flightService;

        public ICommand FinishDelayCommand { get; }

        public DelayedFlightsViewModel(IWindowService _windowService, User user)
        {
            _delayedFlightsService = new DelayedFlightsService();
            _flightService = new FlightService();
            this._windowService = _windowService;
            FinishDelayCommand = new RelayCommand(FinishDelay);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            DeleteWindowCommand = new RelayCommand(OnDelete);
            _userService = new UserService();
            this._user = user;
            LoadDelayedFlights();

            Login = _user.Login;
            AccessRight = _user.AccessRight;
        }
        private void OnMainWindowOpen(object parameter)
        {
            _windowService.OpenWindow("MainMenuView", _user);
            _windowService.CloseWindow();

        }

        private void FinishDelay(object parameter)
        {
            if (_userService.IfUserCanDoAdditionalActions(_user))
            {


                var delayedFlightInfo = parameter as DelayedFlightInfo;
                if (delayedFlightInfo != null && delayedFlightInfo.EndDelayDate != null)
                {
                    MessageBoxResult result = MessageBox.Show(
                        "Завершити затримку?",
                        "Завершення затримки",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        delayedFlightInfo = parameter as DelayedFlightInfo;
                        delayedFlightInfo.EndDelayDate = DateTime.Now;
                        Flight flight = _flightService.GetFlightById(delayedFlightInfo.FlightId);

                        flight.Status = "запланований";
               

                    }
                }
            }
        }
        private void OnDelete(object parameter)
        {
            if (_userService.IfUserCanDoCrud(_user))
            {


                var delayedFlight = parameter as DelayedFlightInfo;
                if (delayedFlight != null && delayedFlight.EndDelayDate != null)
                {

                    MessageBoxResult resultOther = MessageBox.Show(
                                 "Ви точно хочете видалити інформацію про завершений рейс?",
                                 "Видалення інформації",
                                 MessageBoxButton.YesNo,
                                 MessageBoxImage.Warning);
                    if (resultOther == MessageBoxResult.Yes)
                    {

                        _delayedFlightsService.DeleteDelayedFlight(delayedFlight.DelayedFlightInfoId);
                        MessageBox.Show(
                                " Інформацію упішно видалено!",
                                  "Видалення інформації",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                        LoadDelayedFlights();
                    }


                }
                else
                {
                    MessageBox.Show(
                                " Неможливо видалити рейс, який відкладенний у даний момент!",
                                  "Видалення інформації",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);

                }
            }





        }



        public List<DelayedFlightInfo> SearchDelayedFlightInfo(string query)
        {
            return DelayedFlights.Where(flight =>
                flight.DelayedFlightInfoId.ToString().Contains(query) ||
                flight.FlightNumber.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                flight.Category.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                flight.DispatchBrigadeId.ToString().Contains(query) ||
                flight.NavigationBrigadeId.ToString().Contains(query) ||
                flight.FlightBrigadeId.ToString().Contains(query) ||
                flight.StartDelayDate.ToString("yyyy-MM-dd").Contains(query) ||
                (flight.EndDelayDate.HasValue && flight.EndDelayDate.Value.ToString("yyyy-MM-dd").Contains(query)) ||
                flight.InspectionBrigadeId.ToString().Contains(query) ||
                flight.Reason.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                flight.Description.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                flight.FlightId.ToString().Contains(query) ||
                flight.RouteNumber.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                (flight.WorkerId.HasValue && flight.WorkerId.Value.ToString().Contains(query))
            ).ToList();
        }

        private void LoadDelayedFlights()
        {
            try
            {
                var delayedFlightsList = _delayedFlightsService.GetDelayedFlightsData();
                DelayedFlights = new ObservableCollection<DelayedFlightInfo>(delayedFlightsList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}