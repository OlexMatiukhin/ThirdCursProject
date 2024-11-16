using Airport.Command.AddDataCommands;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Xceed.Wpf.Toolkit.Core.Input;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddFlightViewModel : INotifyPropertyChanged
    {
        private readonly BrigadeService _brigadeService;
        private readonly PlaneService _planeService;
        private IWindowService _windowService;
        private readonly RouteService _routeService;
        private FlightService _flightService;
        private SeatService _seatService;
        private TicketService _ticketService;
  
        public ICommand AddFlightCommand { get; }

        public ObservableCollection<Brigade> FlightBrigades { get; set; }
        public ObservableCollection<Brigade> DispatchBrigades { get; set; }
        public ObservableCollection<Brigade> NavigationBrigades { get; set; }
        public ObservableCollection<Brigade> TechInspectionBrigades { get; set; }
        public ObservableCollection<AirPlane> Planes { get; set; }
        public ObservableCollection<Route> Routes { get; set; }

        public Dictionary<ObjectId, string> FlightBrigadesDictionary { get; set; }
        public Dictionary<ObjectId, string> DispatchBrigadesDictionary { get; set; }
        public Dictionary<ObjectId, string> NavigationBrigadesDictionary { get; set; }
        public Dictionary<ObjectId, string> TechInspectionBrigadesDictionary { get; set; }
        public Dictionary<string, string> PlanesDictionary { get; set; }
        public Dictionary<string, string> RoutesDictionary { get; set; }

        public List<string> Category { get; set; } = new List<string>
        {
            "внутрішній",
            "міжнародний",
            "чартерний",
            "вантажоперевезний",
            "спеціальний"
        };

        private string _flightNumber;
        private string _selectedCategory;
        private string _selectedPlaneNumber;
        private ObjectId _selectedFlightBrigadeId;
        private ObjectId _selectedDispatchBrigadeId;
        private ObjectId _selectedNavigationBrigadeId;
        private ObjectId _selectedTechInspectionBrigadeId;
        private string _routeNumber;
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

        public string SelectedPlaneNumber
        {
            get => _selectedPlaneNumber;
            set
            {
                _selectedPlaneNumber = value;
                OnPropertyChanged(nameof(SelectedPlaneNumber));
            }
        }

        public ObjectId SelectedFlightBrigadeId
        {
            get => _selectedFlightBrigadeId;
            set
            {
                _selectedFlightBrigadeId = value;
                OnPropertyChanged(nameof(SelectedFlightBrigadeId));
            }
        }

        public ObjectId SelectedDispatchBrigadeId
        {
            get => _selectedDispatchBrigadeId;
            set
            {
                _selectedDispatchBrigadeId = value;
                OnPropertyChanged(nameof(SelectedDispatchBrigadeId));
            }
        }

        public ObjectId SelectedNavigationBrigadeId
        {
            get => _selectedNavigationBrigadeId;
            set
            {
                _selectedNavigationBrigadeId = value;
                OnPropertyChanged(nameof(SelectedNavigationBrigadeId));
            }
        }

        public ObjectId SelectedTechInspectionBrigadeId
        {
            get => _selectedTechInspectionBrigadeId;
            set
            {
                _selectedTechInspectionBrigadeId = value;
                OnPropertyChanged(nameof(SelectedTechInspectionBrigadeId));
            }
        }

        public string RouteNumber
        {
            get => _routeNumber;
            set
            {
                _routeNumber = value;
                OnPropertyChanged(nameof(RouteNumber));
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



        private bool CanExecuteAddCommand()
        {
            if (string.IsNullOrWhiteSpace(FlightNumber))
            {
                MessageBox.Show("Номер рейсу не може бути порожнім.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(SelectedCategory))
            {
                MessageBox.Show("Категорію рейсу не обрано.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(SelectedPlaneNumber))
            {
                MessageBox.Show("Літак не обрано.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Planes.Any(p => p.PlaneNumber == SelectedPlaneNumber))
            {
                MessageBox.Show("Обраного літака не існує.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            var selectedPlane = Planes.First(p => p.PlaneNumber == SelectedPlaneNumber);
            if (selectedPlane.TechCondition == "в ремонті")
            {
                MessageBox.Show("Обраний літак знаходиться в ремонті.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (SelectedFlightBrigadeId == ObjectId.Empty)
            {
                MessageBox.Show("Льотну бригаду не обрано.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (SelectedDispatchBrigadeId == ObjectId.Empty)
            {
                MessageBox.Show("Диспетчерську бригаду не обрано.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (SelectedNavigationBrigadeId == ObjectId.Empty)
            {
                MessageBox.Show("Навігаційну бригаду не обрано.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (SelectedTechInspectionBrigadeId == ObjectId.Empty)
            {
                MessageBox.Show("Бригаду технічного обслуговування не обрано.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (DateDeparture >= DateArrivial)
            {
                MessageBox.Show("Дата прибуття повинна бути пізнішою за дату відправлення.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!int.TryParse(NumberTickets, out int ticketCount) || ticketCount <= 0)
            {
                MessageBox.Show("Кількість квитків повинна бути додатним числом.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!int.TryParse(TicketPrice, out int price) || price <= 0)
            {
                MessageBox.Show("Ціна квитка повинна бути додатним числом.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }


        public AddFlightViewModel(IWindowService windowService)
        {
            _brigadeService = new BrigadeService();
            _planeService = new PlaneService();
            this._windowService = windowService;
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

            if (CanExecuteAddCommand())
            {
               
               

                Flight newFlight = new Flight
                {
                    FlightNumber = this.FlightNumber,
               
                    Status = "запланований",
                    Category = this.SelectedCategory,
                    DateDeparture = this.DateDeparture,
                    DateArrival = this.DateArrivial,
                    DispatchBrigadeId = this.SelectedDispatchBrigadeId,
                    NavigationBrigadeId = this.SelectedNavigationBrigadeId,
                    FlightBrigadeId = this.SelectedFlightBrigadeId,
                    InspectionBrigadeId = this.SelectedTechInspectionBrigadeId,
                    RouteNumber = this.RouteNumber,
                    PlaneNumber = this.SelectedPlaneNumber,
                    CustomsControl = "не завершений",
                    PassengerRegistration = "не завершена",
                    NumberTickets = int.Parse(_numberTickets),
                    NumberBoughtTickets = 0
                };
                _flightService.AddFlight(newFlight);


                for (int i = 0; i < int.Parse(NumberTickets); i++)
                {
                    Seat seat = new Seat
                    {
                       
                        Number = i + 1,
                        Status = "вільне",
                        FlightId = _flightService.GetLastFlightId(),
                    };
                    _seatService.AddSeat(seat);
                    Ticket ticket = new Ticket
                    {

                        DateChanges = DateTime.Now,
                        Availability = true,
                        Status = "доступний",
                        Price = int.Parse(TicketPrice),
                        FlightId = _flightService.GetLastFlightId(),
                        SeatId = _seatService.GetLastSeatId(),
                        PassengerId = null
                    };

                   
                    _ticketService.AddTicket(ticket);
                }


                MessageBox.Show("Об'єкти упіщно додано!");
                _windowService.CloseModalWindow();
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
            Planes = new ObservableCollection<AirPlane>(_planeService.GetPlanesData());
            Routes = new ObservableCollection<Route>(_routeService.GetRoutes());
        }

        private void CreateDictionaries()
        {
           FlightBrigadesDictionary = FlightBrigades.ToDictionary(b => b.BrigadeId, b => b.ToString());
            DispatchBrigadesDictionary = DispatchBrigades.ToDictionary(b => b.BrigadeId, b => b.ToString());
            NavigationBrigadesDictionary = NavigationBrigades.ToDictionary(b => b.BrigadeId, b => b.ToString());
            TechInspectionBrigadesDictionary = TechInspectionBrigades.ToDictionary(b => b.BrigadeId, b => b.ToString());
            PlanesDictionary = Planes.ToDictionary(b => b.PlaneNumber, b => b.ToString());
            RoutesDictionary = Routes.ToDictionary(b => b.Number, b => b.ToString());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}