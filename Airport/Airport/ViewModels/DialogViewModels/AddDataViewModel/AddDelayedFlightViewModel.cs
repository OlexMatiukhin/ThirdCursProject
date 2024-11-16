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
using Airport.ViewModels.WindowViewModels;
using System.Windows;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    class AddDelayedFlightViewModel : INotifyPropertyChanged
    {

        public ICommand AddDelayedFlightCommand { get; }

        private FlightService _flightService;
        private DelayedFlightsService _delayedFlightsService;
        private IWindowService _windowService;
        private Flight _flight;
     
        public AddDelayedFlightViewModel(IWindowService windowService, Flight flight)
        {
            this._windowService = windowService;
            this._flight = flight;                      
            _delayedFlightsService = new DelayedFlightsService();

            AddDelayedFlightCommand = new RelayCommand(AddDelayedFlight, canExecute => true);



        }
        public ObservableCollection<StructureUnit> StructureUnits { get; set; }
        public Dictionary<int, string> StructureUnitDictionary { get; set; }

        public string _selectedDelayReason;
        private string _delayDescription;

        public List<string> DelayReason { get; set; } = new List<string>
        {
            "Технічні проблеми",
            "Погодні умови"
        };

        public string SelectedDelayReason
        {
            get => _selectedDelayReason;
            set
            {
                _selectedDelayReason = value;
                OnPropertyChanged(nameof(SelectedDelayReason));
            }
        }

        public string DelayDescription
        {
            get => _delayDescription;
            set
            {
                _delayDescription = value;
                OnPropertyChanged(nameof(DelayDescription));
            }
        }




        private void AddDelayedFlight(object parameter)
        {

            if (_flight != null && _flight.Category!="спеціальний"&& _flight.Status!="активний" && DelayDescription != "" && SelectedDelayReason != "")
            {
                
                    _delayedFlightsService.AddDelayedFlightInfoFromFlight(_flight, SelectedDelayReason, DelayDescription);
                     _flight.Status = "затриманий";
                MessageBox.Show("Рейс затримано!");
                _windowService.CloseModalWindow();




            }
            else
            {
                MessageBox.Show("Рейс не було затирмано!", "Помилка затримки рейсу!", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}