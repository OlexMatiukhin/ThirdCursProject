using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
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
    class CanceledFlightsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CanceledFlightInfo> _canceledFlights;
        public ICommand DeleteWindowCommand { get; }
        private readonly UserService _userService;
        private User _user;
        public ObservableCollection<CanceledFlightInfo> CanceledFlights
        {
            get => _canceledFlights;
            set
            {
                if (_canceledFlights != value)
                {
                    _canceledFlights = value;
                    OnPropertyChanged(nameof(CanceledFlights));
                }
            }
        }
        private CanceledFlightsService _canceledeFlightsService;
        public ICommand OpenMainWindowCommand { get; }
        private readonly IWindowService _windowService;
        public event PropertyChangedEventHandler PropertyChanged;


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


        public CanceledFlightsViewModel(IWindowService _windowService, User user)
        {
            _canceledeFlightsService = new CanceledFlightsService();
            this._windowService = _windowService;
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            DeleteWindowCommand = new RelayCommand(OnDelete);
            LoadCanceledFlights();
            this._user = user;
            _userService = new UserService();
            Login = _user.Login;
            AccessRight = _user.AccessRight;
        }

        public void SearchOperation(string searchLine)
        {
            LoadCanceledFlights();
            if (!string.IsNullOrEmpty(searchLine))
            {
                var searchResult = SearchCanceledFlightInfo(searchLine);

                CanceledFlights = new ObservableCollection<CanceledFlightInfo>(searchResult);

            }

        }




        private void OnDelete(object parameter)
        {
            if (_userService.IfUserCanDoCrud(_user))
            {


                var canceledFlight = parameter as CanceledFlightInfo;
                if (canceledFlight != null)
                {

                    MessageBoxResult resultOther = MessageBox.Show(
                                 "Ви точно хочете видалити інформацію про скасований рейс?",
                                 "Видалення інформації",
                                 MessageBoxButton.YesNo,
                                 MessageBoxImage.Warning);
                    if (resultOther == MessageBoxResult.Yes)
                    {

                        _canceledeFlightsService.DeleteCanceledFlight(canceledFlight.CanceledFlightInfoId);
                        MessageBox.Show(
                                " Інформацію упішно видалено!",
                                  "Видалення інформації",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
                        LoadCanceledFlights();

                    }


                }
            }





        }

       
        private void OnMainWindowOpen(object parameter)
        {
            _windowService.OpenWindow("MainMenuView", _user);
            _windowService.CloseWindow();

        }
        public List<CanceledFlightInfo> SearchCanceledFlightInfo(string query)
        {
            return CanceledFlights.Where(flight =>
                flight.CanceledFlightInfoId.ToString().Contains(query, StringComparison.OrdinalIgnoreCase) ||
                flight.FlightNumber.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                flight.Status.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                flight.Category.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                flight.DispatchBrigadeId.ToString().Contains(query) ||
                flight.NavigationBrigadeId.ToString().Contains(query) ||
                flight.FlightBrigadeId.ToString().Contains(query) ||
                flight.UnoccupiedSeatNumber.ToString().Contains(query) ||
                flight.SeatNumber.ToString().Contains(query) ||
                flight.InspectionBrigadeId.ToString().Contains(query) ||
                flight.RouteNumber.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                flight.WorkerId.ToString().Contains(query) ||
                flight.Reason.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                flight.Description.Contains(query, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void LoadCanceledFlights()
        {
            try
            {
                var canceldFlightsList = _canceledeFlightsService.GetCanceledFlightsData();
                CanceledFlights = new ObservableCollection<CanceledFlightInfo>(canceldFlightsList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}