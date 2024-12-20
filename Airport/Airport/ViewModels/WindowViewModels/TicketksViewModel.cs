﻿using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBService;
using Airport.Services.MongoDBSevice;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Airport.ViewModels.WindowViewModels
{
    public class TicketsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Ticket> _tickets;

        private User _user;
        private readonly UserService _userService;
        private RefundedTicketService _refundedTicketService;


        public ICommand LogoutCommand { get; }
      
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

        public ICommand ReturnTicketCommmand { get; }

        public TicketsViewModel(IWindowService windowService, User user)
        {
            this._windowService = windowService;
            _flightService = new FlightService();
            BuyTicketCommand = new RelayCommand(OnBuyingTicket);
            BookTicketCommand = new RelayCommand(OnBookingTicket);
            ReturnTicketCommmand = new RelayCommand(OnTicketReturn);
            _ticketService = new TicketService();
            _refundedTicketService = new RefundedTicketService();   
            OpenAddWindowCommand = new RelayCommand(OnAdd);
            _passengerService =new PassengerService();
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            LoadTickets();
            _userService = new UserService();
            this._user = user;
            Login = _user.Login;
            AccessRight = _user.AccessRight;
            LogoutCommand = new RelayCommand(OnLogoutCommand);

        }
        private void OnLogoutCommand(object parameter)
        {
            _windowService.OpenWindow("LoginView", _user);
            _windowService.CloseWindow();
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
            _windowService.OpenWindow("MainMenuView", _user);
            _windowService.CloseWindow();

        }
        public List<Ticket> SearchTickets(string query)
        {
            return Tickets.Where(ticket =>
                ticket.TicketId.ToString().Contains(query) ||                           
                (!string.IsNullOrEmpty(ticket.Status) && ticket.Status.Contains(query, StringComparison.OrdinalIgnoreCase)) || 
                ticket.Availability.ToString().Contains(query) ||                      
                ticket.DateChanges.ToString("d").Contains(query) ||                   
                ticket.Price.ToString().Contains(query) ||                             
                ticket.FlightId.ToString().Contains(query) ||                         
                ticket.SeatId.ToString().Contains(query) ||                           
                (ticket.PassengerId.HasValue && ticket.PassengerId.Value.ToString().Contains(query)) 
            ).ToList();
        }


        private void OnBuyingTicket(object parameter)
        {
            if (_userService.IfUserCanDoAdditionalActions(_user))
            {
                var ticket = parameter as Ticket;

                Flight flight = new Flight();
                 flight = _flightService.GetFlightById(ticket.FlightId);

                if (ticket != null && ticket.Status != "куплений")
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
                            flight.NumberBoughtTickets++;
                            _flightService.UpdateFlight(flight);
                        }
                        
                    }
                    else
                    {
                        //ticket.Status = "куплений";
                        _windowService.OpenModalWindow("AddPassengerBuyTicket", ticket, flight);


                    }
                }

            }
        }

        private void OnBookingTicket(object parameter)
        {

            var ticket = parameter as Ticket;



            Flight flight = new Flight();
            

            if (ticket != null && ticket.Status != "куплений" && ticket.Status != "заброньований")
            {
                //ticket.Status = "заброньований";



                flight = _flightService.GetFlightById(ticket.FlightId);
                _windowService.OpenModalWindow("AddPassengerBookTicket", ticket);
;
            }
          


        }


        private void OnTicketReturn(object parameter)
        {

            if (_userService.IfUserCanDoAdditionalActions(_user))
            {
                var ticket = parameter as Ticket;
                Flight flight = _flightService.GetFlightById(ticket.FlightId);

                if (flight.Status == "активний")
                {
                    MessageBox.Show("Повернути квиток, на активований рейс неможливо!");
                }


                if (ticket != null && ticket.Status == "куплений" || ticket.Status == "заброньований")
                {
                    MessageBoxResult result = MessageBox.Show(
                        $"Ви точно хочете повернути білет",
                        "Повернення білету",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {

                        if (ticket.Status == "куплений")
                        {
                           
                            flight.NumberBoughtTickets--;
                        }

                        ticket.Status = "доступний";
                        _passengerService.DeletePassenger(ticket.PassengerId);
                        ticket.PassengerId = null;
                        _ticketService.UpdateTicket(ticket);
                        _flightService.UpdateFlight(flight);
                        
                        LoadTickets();



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