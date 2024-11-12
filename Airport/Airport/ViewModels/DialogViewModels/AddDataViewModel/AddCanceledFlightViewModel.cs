using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Media.Media3D;
using Airport.Services.Airport.Services;
using SharpCompress.Compressors.Deflate;
using System.Windows;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    class AddCanceledFlightViewModel:INotifyPropertyChanged
    {
    
        public ICommand AddCanceledFlightCommand { get; }

        private FlightService _flightService;
        private PassengerService _passengerService;
        private BaggageService _baggageService;
        private TicketService _ticketService;
        private SeatService _seatService;
        private CanceledFlightsService _canceledFlightsService;
        private IWindowService _windowService;
        private Flight _flight;
        private ObservableCollection<Flight> _flights;
        public AddCanceledFlightViewModel(IWindowService windowService, Flight flight, ObservableCollection<Flight> flights)
        {
            this._windowService= windowService;
            this._flight = flight;
            this._flights = flights;
            _flightService = new FlightService();
            _passengerService = new PassengerService();
            _baggageService = new BaggageService();
            _ticketService = new TicketService();
            _seatService = new SeatService();
            _canceledFlightsService = new CanceledFlightsService();
            AddCanceledFlightCommand = new RelayCommand(AddCanceledFlight, canExecute => true);

         

        }
        public ObservableCollection<StructureUnit> StructureUnits { get; set; }
        public Dictionary<int, string> StructureUnitDictionary { get; set; }

        public string _selectedCancelingReason;
        private string _cancelingDescription;

        public List<string> CancelingReason { get; set; } = new List<string>
        {
            "Технічні проблеми",
            "Кількість куплений білетів"
        };

        public string SelectedCancelingReason
        {
            get => _selectedCancelingReason;
            set
            {
                _selectedCancelingReason = value;
                OnPropertyChanged(nameof(SelectedCancelingReason));
            }
        }

        public string CancelingDescription
        {
            get => _cancelingDescription;
            set
            {
                _cancelingDescription = value;
                OnPropertyChanged(nameof(CancelingDescription));
            }
        }




        private void AddCanceledFlight(object parameter)
        {    
           
            if (_flight != null && CancelingDescription!=""&& SelectedCancelingReason!="")
            {
                if (_flight.Category == "внутрішній" || _flight.Category == "міжнародний")
                {
                    _baggageService.DeleteBaggageByPassanger(_passengerService.GetPassengersByFlightId(_flight.FlightId));
                    _passengerService.DeletePassangersByFlightId(_flight.FlightId);
                    _ticketService.DeleteTicketsByFlightId(_flight.FlightId);
                    _seatService.DeleteSeatsByFlightId(_flight.FlightId);
                    _canceledFlightsService.AddCanceledFlight(_flight, SelectedCancelingReason, CancelingDescription);                  
                    _flightService.DeleteFlight(_flight.FlightId);
                    _flights.Remove(_flight);

                }
                else
                {
                    _canceledFlightsService.AddCanceledFlight(_flight, SelectedCancelingReason, CancelingDescription);
                    _flightService.DeleteFlight(_flight.FlightId);
                    _flights.Remove(_flight);

                }

            }
            else
            {
                MessageBox.Show("Рейс не було відмінено! При відміні сталася помилка!", "Помилка скасування рейсу!",MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
