using Airport.Command.AddDataCommands;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddFlightViewModel : INotifyPropertyChanged
    {
        private readonly BrigadeService _brigadeService;
        private readonly PlaneService _planeService;
        private readonly RouteService _routeService;
        private FlightService _flightService;
        private SeatService _seatService;
        private TicketService _ticketService;
  
        public ICommand AddFlightCommand { get; }

        public ObservableCollection<Brigade> FlightBrigades { get; set; }
        public ObservableCollection<Brigade> DispatchBrigades { get; set; }
        public ObservableCollection<Brigade> NavigationBrigades { get; set; }
        public ObservableCollection<Brigade> TechInspectionBrigades { get; set; }
        public ObservableCollection<Plane> Planes { get; set; }
        public ObservableCollection<Route> Routes { get; set; }

        public Dictionary<int, string> FlightBrigadesDictionary { get; set; }
        public Dictionary<int, string> DispatchBrigadesDictionary { get; set; }
        public Dictionary<int, string> NavigationBrigadesDictionary { get; set; }
        public Dictionary<int, string> TechInspectionBrigadesDictionary { get; set; }
        public Dictionary<int, string> PlanesDictionary { get; set; }
        public Dictionary<int, string> RoutesDictionary { get; set; }

        public List<string> Category { get; set; } = new List<string>
        {
            "Внутрішній",
            "Міжнародний",
            "Чартерні",
            "Ванатжоперевезення",
            "Спіціальний"
        };

        private string _flightNumber;
        private string _selectedCategory;
        private int _selectedPlaneId;
        private int _selectedFlightBrigadeId;
        private int _selectedDispatchBrigadeId;
        private int _selectedNavigationBrigadeId;
        private int _selectedTechInspectionBrigadeId;
        private int _routeId;
        private string _numberTickets;
        private string _ticketPrice;

        private DateTime _dateDeparture;
        public DateTime DateDeparture
        {
            get => _dateDeparture;
            set
            {
                _dateDeparture = value;
                OnPropertyChanged(nameof(DateDeparture));
            }
        }

        private DateTime _dateArrivial;
        public DateTime DateArrivial
        {
            get => _dateArrivial;
            set
            {
                _dateArrivial = value;
                OnPropertyChanged(nameof(DateArrivial));
            }
        }
        public string FlightNumber
        {
            get { return _flightNumber; }
            set
            {
                _flightNumber = value;
                OnPropertyChanged(nameof(FlightNumber));
            }
        }
        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        public int SelectedPlaneId
        {
            get => _selectedPlaneId;
            set
            {
                _selectedPlaneId = value;
                OnPropertyChanged(nameof(SelectedPlaneId));
            }
        }

        public int SelectedFlightBrigadeId
        {
            get => _selectedFlightBrigadeId;
            set
            {
                _selectedFlightBrigadeId = value;
                OnPropertyChanged(nameof(SelectedFlightBrigadeId));
            }
        }

        public int SelectedDispatchBrigadeId
        {
            get => _selectedDispatchBrigadeId;
            set
            {
                _selectedDispatchBrigadeId = value;
                OnPropertyChanged(nameof(SelectedDispatchBrigadeId));
            }
        }

        public int SelectedNavigationBrigadeId
        {
            get => _selectedNavigationBrigadeId;
            set
            {
                _selectedNavigationBrigadeId = value;
                OnPropertyChanged(nameof(SelectedNavigationBrigadeId));
            }
        }

        public int SelectedTechInspectionBrigadeId
        {
            get => _selectedTechInspectionBrigadeId;
            set
            {
                _selectedTechInspectionBrigadeId = value;
                OnPropertyChanged(nameof(SelectedTechInspectionBrigadeId));
            }
        }

        public int RouteId
        {
            get => _routeId;
            set
            {
                _routeId = value;
                OnPropertyChanged(nameof(RouteId));
            }
        }



        public string TicketPrice
        {
            get => _ticketPrice;
            set
            {
                _ticketPrice = value;
                OnPropertyChanged(nameof(TicketPrice));
            }
        }


        public string NumberTickets
        {
            get => _numberTickets;
            set
            {
                _numberTickets = value;
                OnPropertyChanged(nameof(NumberTickets));
            }
        }



      private bool CanExecuteAddCommanrd()
        {
            Plane plane = Planes.First(p => p.PlaneId == SelectedPlaneId);
            if (plane ==null && plane.InteriorReadiness == "готовий" && plane.PlaneFuelStatus == "заправлений" && plane.TechCondition == "задовільний")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Літак не готовий до польоту", "Літак", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;

            }
        }


        public AddFlightViewModel()
        {
            _brigadeService = new BrigadeService();
            _planeService = new PlaneService();
            _routeService = new RouteService();
            _seatService = new SeatService();
            _flightService = new FlightService();
            _ticketService = new TicketService();
            AddFlightCommand = new RelayCommand(ExecuteAddFlight,canExecute=>true);

            LoadData();
            CreateDictionaries();
          


        }

        private void ExecuteAddFlight(object parameter)
        {

            if (CanExecuteAddCommanrd())
            {
                int flightId = _flightService.GetLastFlightId() + 1;
                int firstSeatId = _seatService.GetLastSeatId() + 1;
                int firstTicketId = _ticketService.GetLastTicketId() + 1;

                Flight newFlight = new Flight
                {

                    FlightNumber = FlightNumber,
                    FlightId = flightId,
                    Status = "запланований",
                    Category = SelectedCategory,
                    DateDeparture = DateDeparture,
                    DateArrival = DateArrivial,
                    PlaneId = SelectedPlaneId,
                    DispatchBrigadeId = SelectedDispatchBrigadeId,
                    NavigationBrigadeId = SelectedNavigationBrigadeId,
                    FlightBrigadeId = SelectedFlightBrigadeId,
                    InspectionBrigadeId = SelectedTechInspectionBrigadeId,
                    RouteId = RouteId,
                    CustomsControl=false,
                    PassengerRegistration=false
                };


                for (int i = 0; i < int.Parse(NumberTickets); i++)
                {
                    Seat seat = new Seat
                    {
                        SeatId = firstSeatId + i,
                        Number = i + 1,
                        Status = "вільне",
                        FlightId = flightId
                    };

                    Ticket ticket = new Ticket
                    {
                        TicketId = firstTicketId + i,
                        DateChanges = DateTime.Now,
                        Availability = true,
                        Status = "доступний",
                        Price = int.Parse(TicketPrice),
                        FlightId = flightId,
                        SeatId = firstSeatId + i,
                        PassengerId = 0
                    };

                    _seatService.AddSeat(seat);
                    _ticketService.AddTicket(ticket);
                }

                _flightService.AddFlight(newFlight);
            }
        }

        private void LoadData()
        {
            var FlightBrigadesList = _brigadeService.GetBrigadesByType("Льотна бригада");
            FlightBrigades = new ObservableCollection<Brigade>(FlightBrigadesList);

            var DispatchBrigadeList = _brigadeService.GetBrigadesByType("Навігаційна бригада");
            DispatchBrigades = new ObservableCollection<Brigade>(DispatchBrigadeList);

            var NavigationBrigadesList = _brigadeService.GetBrigadesByType("Бригада технічного обслуговування літаків");
            NavigationBrigades = new ObservableCollection<Brigade>(NavigationBrigadesList);

            var TechInspectionBrigadesList = _brigadeService.GetBrigadesByType("Диспетчерська бригада");
            TechInspectionBrigades = new ObservableCollection<Brigade>(TechInspectionBrigadesList);
            Planes = new ObservableCollection<Plane>(_planeService.GetPlanesData());
            Routes = new ObservableCollection<Route>(_routeService.GetRoutes());
        }

        private void CreateDictionaries()
        {
            FlightBrigadesDictionary = FlightBrigades.ToDictionary(b => b.BrigadeId, b => b.ToString());
            DispatchBrigadesDictionary = DispatchBrigades.ToDictionary(b => b.BrigadeId, b => b.ToString());
            NavigationBrigadesDictionary = NavigationBrigades.ToDictionary(b => b.BrigadeId, b => b.ToString());
            TechInspectionBrigadesDictionary = TechInspectionBrigades.ToDictionary(b => b.BrigadeId, b => b.ToString());
            PlanesDictionary = Planes.ToDictionary(b => b.PlaneId, b => b.ToString());
            RoutesDictionary = Routes.ToDictionary(b => b.RouteId, b => b.ToString());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}