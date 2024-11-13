using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBService;
using Airport.Services.MongoDBSevice;

namespace Airport.ViewModels.WindowViewModels
{
    public class TicketsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Ticket> _tickets;

        private User _user;
        private readonly UserService _userService;


        public ObservableCollection<Ticket> Tickets
        {
            get => _tickets;
            set
            {
                if (_tickets != value)
                {
                    _tickets = value;
                    OnPropertyChanged(nameof(Tickets));
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
            LoadTickets();
            if (!string.IsNullOrEmpty(searchLine))
            {
                var searchResult = SearchTickets(searchLine);

                Tickets = new ObservableCollection<Ticket>(searchResult);

            }

        }
        private TicketService _ticketService;
        private PassengerService _passengerService;
        private FlightService _flightService;



        private IWindowService _windowService;
        public ICommand OpenMainWindowCommand { get; }

        public ICommand OpenAddWindowCommand { get; }
        public ICommand BuyTicketCommand { get; }
        public ICommand BookTicketCommand { get; }

        public TicketsViewModel(IWindowService windowService, User user)
        {
            this._windowService = windowService;
            BuyTicketCommand = new RelayCommand(OnBuyingTicket);
            BookTicketCommand = new RelayCommand(OnBookingTicket);
            _ticketService = new TicketService();
            OpenAddWindowCommand = new RelayCommand(OnAdd);
            _passengerService =new PassengerService();
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            LoadTickets();
            _userService = new UserService();
            this._user = user;
            Login = _user.Login;
            AccessRight = _user.AccessRight;

        }

        private void OnAdd(object parameter)
        {

            if (_userService.IfUserCanDoCrud(_user))
            {
                _windowService.OpenModalWindow("AddTicket");
            }



        }
        private void OnMainWindowOpen(object parameter)
        {

            _windowService.OpenWindow("MainMenuView");
            _windowService.CloseWindow();

        }
        public List<Ticket> SearchTickets(string query)
        {
            return Tickets.Where(ticket =>
                ticket.TicketId.ToString().Contains(query) ||                           // Поиск по TicketId
                (!string.IsNullOrEmpty(ticket.Status) && ticket.Status.Contains(query, StringComparison.OrdinalIgnoreCase)) || // Поиск по Status
                ticket.Availability.ToString().Contains(query) ||                      // Поиск по Availability
                ticket.DateChanges.ToString("d").Contains(query) ||                    // Поиск по DateChanges
                ticket.Price.ToString().Contains(query) ||                              // Поиск по Price
                ticket.FlightId.ToString().Contains(query) ||                          // Поиск по FlightId
                ticket.SeatId.ToString().Contains(query) ||                            // Поиск по SeatId
                (ticket.PassengerId.HasValue && ticket.PassengerId.Value.ToString().Contains(query)) // Поиск по PassengerId
            ).ToList();
        }


        private void OnBuyingTicket(object parameter)
        {
            if (_userService.IfUserCanDoAdditionalActions(_user))
            {
                var ticket = parameter as Ticket;
                Flight flight = _flightService.GetFlightById(ticket.FlightId);

                if (ticket != null && ticket.Status != "проданий")
                {
                    if (ticket.Status == "заброньований")
                    {

                        MessageBoxResult result = MessageBox.Show(
                        $"Данний білет заброньований за пасажиром з id:{ticket.PassengerId}. Він бажає купити білет.",
                        "Покупка заброньованого білету",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);
                        if (result == MessageBoxResult.Yes)
                        {
                            ticket.Status = "куплений";
                            _ticketService.UpdateTicket(ticket);
                            flight.NumberBoughtTickets--;
                            _flightService.UpdateFlight(flight);
                        }
                    }
                    else
                    {
                        //ticket.Status = "куплений";
                        _windowService.OpenModalWindow("AddPassangerViewModel", ticket);


                    }
                }

            }
        }

        private void OnBookingTicket(object parameter)
        {

            var ticket = parameter as Ticket;

            if (ticket != null && ticket.Status != "проданий" && ticket.Status != "заброньований")
            {
                //ticket.Status = "заброньований";
                _windowService.OpenModalWindow("AddPassangerViewModel", ticket);
;
            }
          


        }


        private void OnTicketReturn(object parameter)
        {

            if (_userService.IfUserCanDoAdditionalActions(_user))
            {
                var ticket = parameter as Ticket;
                Flight flight = _flightService.GetFlightById(ticket.FlightId);

                if (ticket != null && ticket.Status == "проданий" && ticket.Status == "заброньований")
                {
                    MessageBoxResult result = MessageBox.Show(
                        $"Ви точно хочете повернути білет",
                        "Повернення білету",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        ticket.Status = "доступний";
                        _passengerService.DeletePassenger(ticket.PassengerId);
                        ticket.PassengerId = null;
                        flight.NumberBoughtTickets--;


                    }


                }
            }



        }
        private void LoadTickets()
        {
            try
            {
                var ticketList = _ticketService.GetTicketsData();
                Tickets = new ObservableCollection<Ticket>(ticketList);
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