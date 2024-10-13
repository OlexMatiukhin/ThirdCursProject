﻿using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Media3D;
namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddTicketViewModel : INotifyPropertyChanged
    {
        private readonly  BrigadeService _brigadeService;
        private readonly TicketService _tickietSevice;
        
        private readonly SeatService    _seatService;
        private readonly FlightService _flightService;


        private readonly WorkerService _workerService;
        public ICommand AddTicketCommand { get; }

        public AddTicketViewModel()
        {
            _brigadeService = new BrigadeService();
            _tickietSevice = new TicketService();
       
            _flightService = new FlightService();
            _seatService =  new SeatService();
            LoadData();
            CreateDictionaries();
            AddTicketCommand = new RelayCommand(ExecuteAddTicket, canExecute => true);
        }

        private void ExecuteAddTicket(object parameter)
        {
            Ticket ticket  = new Ticket 
            {
                TicketId = _tickietSevice.GetLastTicketId() + 1,
                Status=this.SelectedStatus,
                Availability=this.Availability,
                DateChanges=this.DateChanges,
                Price=decimal.Parse(this.Price),
                FlightId=this.SelectedFlightId,
                SeatId= this.SelectedSeatId,
                PassengerId= 0

    };

           _tickietSevice.AddTicket(ticket);
        }

        public ObservableCollection<Flight> Flights { get; set; }
        public ObservableCollection<Seat> Seats { get; set; }
        public ObservableCollection<Passenger> Pasengers { get; set; }
    
      


        public Dictionary<int, string> FlightsDictionary { get; set; }
        public Dictionary<int, string> SeatsDictionary { get; set; }
        public Dictionary<int, string> PasengersDictionary { get; set; }

    

      



       
        public List<string> Status { get; set; } = new List<string>
        {   "доступний",
            "проданий",
            "заброньований",
        };

       

        public string _status;
        public bool _availability;
        public DateTime _dateChanges;
        public string _price;
        public int _flightId;
        public int _seatId;
    

        
     

        public string SelectedStatus
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(SelectedStatus));
            }
        }

        public bool Availability
        {
            get => _availability;
            set
            {
                _availability = value;
                OnPropertyChanged(nameof(Availability));
            }
        }

        public DateTime DateChanges
        {
            get => _dateChanges;
            set
            {
                _dateChanges = value;
                OnPropertyChanged(nameof(DateChanges));
            }
        }

        public string Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public int SelectedFlightId
        {
            get => _flightId;
            set
            {
                _flightId = value;
                OnPropertyChanged(nameof(SelectedFlightId));
            }
        }

        public int SelectedSeatId
        {
            get => _seatId;
            set
            {
                _seatId = value;
                OnPropertyChanged(nameof(SelectedSeatId));
            }
        }

      
        private void LoadData()
        {
       
            var SeatsList = _seatService.GetSeatsData();
            Seats = new ObservableCollection<Seat>(SeatsList);
            var FlightsList = _flightService.GetFlightsData();
            Flights = new ObservableCollection<Flight>(FlightsList);
            var BrigadesList = _brigadeService.GetBrigadesData();
         
        }

        private void CreateDictionaries()
        {
          
            SeatsDictionary = Seats.ToDictionary(s => s.SeatId, s => s.ToString());
            FlightsDictionary = Flights.ToDictionary(f => f.FlightId, f => f.ToString());

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





    }

}