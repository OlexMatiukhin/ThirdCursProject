using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace Airport.ViewModels.DialogViewModels.ChangeDataViewModel
{
    public class СhangeBaggageViewModel : INotifyPropertyChanged
    {



            private readonly BaggageService _baggageService;
            private readonly PassengerService _passengerService;
             private Baggage _baggage;

            private IWindowService _windowService;
            public ICommand ChangeBaggageCommand { get; }
            public ObservableCollection<Passenger> Passengers { get; set; }


            public Dictionary<int, string> PassengersDictionary { get; set; }

            public List<string> TypeBaggeList { get; set; } = new List<string>
            {
            "стандартний багаж",
            "великогабаритний багаж",
            "тваринний багаж"
            };



            private string _type;
            private string _weight;
            private string _payment;
          
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
        
            
            public СhangeBaggageViewModel(Baggage baggage, IWindowService windowService)
            {
               this._windowService=windowService;
                _passengerService = new PassengerService();
                 this._baggage = baggage;
                BaggeType=baggage.BaggageType;
                Weight = baggage.Weight.ToString();
                Payment = baggage.Payment.ToString();
                LoadData();
                CreateDictionaries();

                _baggageService = new BaggageService();
                ChangeBaggageCommand = new RelayCommand(OnCahngeBaggageExecuted, canExecute => true);



            }



            private void LoadData()
            {
                var PassengerList = _passengerService.GetPassengersData();
                Passengers = new ObservableCollection<Passenger>(PassengerList);


            }

            private void CreateDictionaries()
            {
                //PassengersDictionary = Passengers.ToDictionary(b => b.PassengerId, b => b.ToString());
            }


            private void OnCahngeBaggageExecuted(object parameter)
            {
                _baggage.BaggageType = BaggeType;
                _baggage.Weight = double.Parse(Weight);
                _baggage.Payment = decimal.Parse(Payment);
         
                

                _baggageService.UpdateBaggage(_baggage);
       
            }

            public void CloseModalWindow()
            {
                _windowService.CloseModalWindow();
                
            }
            
        
        
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        
    }
}

