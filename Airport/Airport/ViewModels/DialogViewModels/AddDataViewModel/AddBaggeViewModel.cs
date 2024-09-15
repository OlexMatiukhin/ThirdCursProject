using Airport.Command.AddDataCommands;
using Airport.Models;
using Airport.Services;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;


namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddBaggeViewModle : INotifyPropertyChanged
    {


        private readonly PassengerService _passengerService;


        private AddBaggageCommand _addBagge;
        public ObservableCollection<Passenger> Passengers { get; set; }


        public Dictionary<int, string> PassengersDictionary { get; set; }

        public List<string> TypeBaggeList { get; set; } = new List<string>
        {
            "Cтандартний",
            "Великогабаритний",
            "Тваринний"
        };

        public AddBaggageCommand AddBaggageCommand
        {
            get => _addBagge;
            set
            {
                _addBagge = value;


            }
        }

        private string _type;
        private string _weight;
        private string _payment;
        private int _selectedPassangerId;

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

        public int SelectedPassengerId
        {
            get => _selectedPassangerId;
            set
            {
                _selectedPassangerId = value;
                OnPropertyChanged(nameof(SelectedPassengerId));
            }
        }



        public AddBaggeViewModle()
        {
            _passengerService = new PassengerService();


            LoadData();
            CreateDictionaries();

            _addBagge = new AddBaggageCommand(this);


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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





    }
}