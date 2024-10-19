using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Airport.Models;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Services.MongoDBSevice;
using Airport.Services;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class ChangeFlightViewModel : INotifyPropertyChanged
    {
        private readonly BrigadeService _brigadeService;
        private readonly PlaneService _planeService;
        private readonly RouteService _routeService;
        private FlightService _flightService;
        private int flightId = 0;
        private IWindowService _windowService;


        public ICommand ChangeFlightCommand { get; }

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
            "внутрішній",
            "міжнародний",
            "чартерні",
            "ванатжоперевезення",
            "спіціальний"
        };


        private string _flightNumber;
        private string _selectedCategory;
        private int _selectedPlaneId;
        private int _selectedFlightBrigadeId;
        private int _selectedDispatchBrigadeId;
        private int _selectedNavigationBrigadeId;
        private int _selectedTechInspectionBrigadeId;
        private int _routeId;
        private int _ticketPrice;
        private int _numberTickets;



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



        public int TicketPrice
        {
            get => _ticketPrice;
            set
            {
                _ticketPrice = value;
                
            }
        }


        public int NumberTickets
        {
            get => _numberTickets;
            set
            {
                _numberTickets = value;
                
            }
        }


        public ChangeFlightViewModel( Flight flight, IWindowService windowService)
        {
             this._windowService=windowService;
            _brigadeService = new BrigadeService();
            flightId = flight.FlightId;
            _planeService = new PlaneService();
            _routeService = new RouteService();
            _flightService = new FlightService();

            FlightNumber=flight.FlightNumber;
            SelectedCategory = flight.Category;
            SelectedPlaneId = flight.PlaneId;
            SelectedFlightBrigadeId = flight.FlightBrigadeId;
            SelectedDispatchBrigadeId = flight.DispatchBrigadeId;
            SelectedNavigationBrigadeId = flight.NavigationBrigadeId;
            SelectedTechInspectionBrigadeId = flight.InspectionBrigadeId;
            RouteId = flight.RouteId;
            
      

        ChangeFlightCommand = new RelayCommand(ExecuteChangeFlight, canExecute => true);

            LoadData();
            CreateDictionaries();



        }

        private void ExecuteChangeFlight(object parameter)
        {
           


            Flight newFlight = new Flight
            {
                FlightNumber = FlightNumber,
                FlightId = flightId,
                Status = "активний",
                Category = SelectedCategory,
                DateDeparture = DateDeparture,
                DateArrival = DateArrivial,
                PlaneId = SelectedPlaneId,
                DispatchBrigadeId = SelectedDispatchBrigadeId,
                NavigationBrigadeId = SelectedNavigationBrigadeId,
                FlightBrigadeId = SelectedFlightBrigadeId,
                InspectionBrigadeId = SelectedTechInspectionBrigadeId,
                RouteId = RouteId
            };
            _flightService.UpdateFlight(newFlight.FlightId, newFlight);

        }

        private void LoadData()
        {
            var FlightBrigadesList = _brigadeService.GetBrigadesByType("Льотна бригада");
            FlightBrigades = new ObservableCollection<Brigade>(FlightBrigadesList);

            var DispatchBrigadeList = _brigadeService.GetBrigadesByType("Диспетчерська бригада");
            DispatchBrigades = new ObservableCollection<Brigade>(DispatchBrigadeList);

            var NavigationBrigadesList = _brigadeService.GetBrigadesByType("Навігаційна бригада");
            NavigationBrigades = new ObservableCollection<Brigade>(NavigationBrigadesList);

            var TechInspectionBrigadesList = _brigadeService.GetBrigadesByType("Бригада технічного огляду літаків");
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

