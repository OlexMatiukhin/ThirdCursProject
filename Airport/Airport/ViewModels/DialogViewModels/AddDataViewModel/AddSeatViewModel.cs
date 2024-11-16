using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddSeatViewModel
    {
        
            private readonly BrigadeService _brigadeService;
            private readonly SeatService _seatSevice;

            private readonly SeatService _seatService;
            private readonly FlightService _flightService;


            private readonly WorkerService _workerService;
            private IWindowService windowService;
            public ICommand AddSeatCommand { get; }

            public AddSeatViewModel()
            {
               

                _flightService = new FlightService();
                _seatService = new SeatService();
                LoadData();
                CreateDictionaries();
                AddSeatCommand = new RelayCommand(ExecuteAddSeat, canExecute => true);
            }

            private void ExecuteAddSeat(object parameter)
            {
                Seat seat = new Seat
                {
                    Status = this.SelectedStatus,
                    Number= _seatSevice.GetLastSeatNumber() + 1,
                    FlightId = this.SelectedFlightId,
                   
                    

                };
      
          

            _seatSevice.AddSeat(seat);
            }

            public ObservableCollection<Flight> Flights { get; set; }
         




            public Dictionary<ObjectId, string> FlightsDictionary { get; set; }
            








            public List<string> Status { get; set; } = new List<string>
            {   "доступне",
                "зайняте",
            };



        
        public string _status;
        public ObjectId _flightId;


       

       

        public string SelectedStatus
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(SelectedStatus));
            }
        }

        public ObjectId SelectedFlightId
        {
            get => _flightId;
            set
            {
                _flightId = value;
                OnPropertyChanged(nameof(SelectedFlightId));
            }
        }



        private void LoadData()
        {             
                var FlightsList = _flightService.GetFlightsData();
                Flights = new ObservableCollection<Flight>(FlightsList);    
            

        }

            private void CreateDictionaries()
            {

              
                FlightsDictionary = Flights.ToDictionary(f => f.FlightId, f => f.ToString());

            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }





        }
    }

