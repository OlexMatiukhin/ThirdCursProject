
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBService;
using Airport.Services.MongoDBSevice;

namespace Airport.ViewModels.WindowViewModels
{
    public class SeatsViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<Seat> _seats;
        private readonly UserService _userService;

        public ObservableCollection<Seat> Seats
        {
            get => _seats;
            set
            {
                if (_seats != value)
                {
                    _seats = value;
                    OnPropertyChanged(nameof(Seats));
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
        public ICommand LogoutCommand { get; }

        public void SearchOperation(string searchLine)
        {
            LoadSeats();
            if (!string.IsNullOrEmpty(searchLine))
            {
                var searchResult = SearchSeats(searchLine);

                Seats = new ObservableCollection<Seat>(searchResult);

            }

        }

        private SeatService _seatService;
        private IWindowService _windowService;
        public ICommand OpenMainWindowCommand { get; }
        public ICommand OpenAddWindowCommand { get; }

        private User _user;
        private void OnLogoutCommand(object parameter)
        {
            _windowService.OpenWindow("LoginView", _user);
            _windowService.CloseWindow();
        }

        public SeatsViewModel(IWindowService _windowService, User user)
        {
            _seatService = new SeatService();
            this._windowService = _windowService;
            OpenAddWindowCommand = new RelayCommand(OnAdd);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            LoadSeats();
            _userService = new UserService();
            this._user = user;
            LogoutCommand = new RelayCommand(OnLogoutCommand);

            Login = _user.Login;
            AccessRight = _user.AccessRight;

        }
        private void OnMainWindowOpen(object parameter)
        {
            _windowService.OpenWindow("MainMenuView", _user);
            _windowService.CloseWindow();

        }

        public List<Seat> SearchSeats(string query)
        {
            return Seats.Where(seat =>
                seat.SeatId.ToString().Contains(query) ||                                        
                seat.Number.ToString().Contains(query) ||                                      
                (!string.IsNullOrEmpty(seat.Status) && seat.Status.Contains(query, StringComparison.OrdinalIgnoreCase)) || 
                seat.FlightId.ToString().Contains(query)                                       
            ).ToList();
        }


        private void OnAdd(object parameter)
        {
            _windowService.OpenModalWindow("AddSeat");
            LoadSeats();



        }

        private void LoadSeats()
        {
            try
            {
                var seatList = _seatService.GetSeatsData();
                Seats = new ObservableCollection<Seat>(seatList);
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
