using Airport.Command.AddDataCommands;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;


namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{  
    public class AddBaggeViewModle : INotifyPropertyChanged
    {
        IWindowService _windowService;

        private readonly BaggageService _baggageService;
        private readonly PassengerService _passengerService;


        public ICommand AddBaggageCommand { get; }
        public ObservableCollection<Passenger> Passengers { get; set; }


        public Dictionary<ObjectId, string> PassengersDictionary { get; set; }

        public List<string> TypeBaggeList { get; set; } = new List<string>
        {
            "Cтандартний",
            "Великогабаритний",
            "Тваринний"
        };

        

        private string _type;
        private string _weight;
        private string _payment;
        private ObjectId _selectedPassangerId;

        public string BaggeType
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        public string Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        public string Payment
        {
            get => _payment;
            set
            {
                _payment = value;
                OnPropertyChanged(nameof(Payment));
            }
        }

        public ObjectId SelectedPassengerId
        {
            get => _selectedPassangerId;
            set
            {
                _selectedPassangerId = value;
                OnPropertyChanged(nameof(SelectedPassengerId));
            }
        }



        public AddBaggeViewModle(IWindowService windowService)
        {
            _passengerService = new PassengerService();
            this._windowService = windowService;

            LoadData();
            CreateDictionaries();
            

            _baggageService = new BaggageService();
            AddBaggageCommand = new RelayCommand(OnAddBaggageExecuted, canExecute => true);



        }



        private void LoadData()
        {
            var PassengerList = _passengerService.GetPassengersData();
            Passengers = new ObservableCollection<Passenger>(PassengerList);


        }

        private void CreateDictionaries()
        {
            PassengersDictionary = Passengers.ToDictionary(b => b.PassengerId, b => b.ToString());


        }


        private void OnAddBaggageExecuted(object parameter)
        {
 

            var newBaggage = new Baggage
            {
               BaggageType = BaggeType,
                Weight = int.Parse(Weight),
                Payment = int.Parse(Payment),
                PassengerId = SelectedPassengerId
            };

            _baggageService.AddBaggage(newBaggage);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





    }
}