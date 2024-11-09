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
        private Flight _flight;
  
        private IWindowService _windowService;
        public ICommand ChangeFlightCommand { get; }


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
            "чартерні",
            "ванатжоперевезення",
            "спіціальний"
        };


        private string _flightNumber;
        private string _selectedCategory;
        private string _selectedPlaneNumber;
        private ObjectId _selectedFlightBrigadeId;
        private ObjectId _selectedDispatchBrigadeId;
        private ObjectId _selectedNavigationBrigadeId;
        private ObjectId _selectedTechInspectionBrigadeId;
        private string _routeNumber;
        private int _numberTickets;
        private int _numberBoughtTickets;




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



       


      


        public ChangeFlightViewModel( Flight flight, IWindowService windowService)
        {
             this._windowService=windowService;
            _brigadeService = new BrigadeService();
             this._flight= flight;
          
            _planeService = new PlaneService();
            _routeService = new RouteService();
            _flightService = new FlightService();

            FlightNumber=flight.FlightNumber;
            SelectedCategory = flight.Category;
            SelectedPlaneNumber = flight.PlaneNumber;
            SelectedFlightBrigadeId = flight.FlightBrigadeId;
            SelectedDispatchBrigadeId = flight.DispatchBrigadeId;
            SelectedNavigationBrigadeId = flight.NavigationBrigadeId;
            SelectedTechInspectionBrigadeId = flight.InspectionBrigadeId;
            RouteNumber = flight.RouteNumber;
            _numberTickets = flight.NumberTickets;

           
            
      

        ChangeFlightCommand = new RelayCommand(ExecuteChangeFlight, canExecute => true);

            LoadData();
            CreateDictionaries();



        }

        private void ExecuteChangeFlight(object parameter)
        {




            _flight.FlightNumber = FlightNumber;

            _flight.Status = "активний";
            _flight.Category = SelectedCategory;
            _flight.DateDeparture = DateDeparture;
            _flight.DateArrival = DateArrivial;
            _flight.PlaneNumber = SelectedPlaneNumber;
            _flight.DispatchBrigadeId = SelectedDispatchBrigadeId;
            _flight.NavigationBrigadeId = SelectedNavigationBrigadeId;
            _flight.FlightBrigadeId = SelectedFlightBrigadeId;
            _flight.InspectionBrigadeId = SelectedTechInspectionBrigadeId;
            _flight.RouteNumber = RouteNumber;            
            _flightService.UpdateFlight(_flight);

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

