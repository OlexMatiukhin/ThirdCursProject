using Airport.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;
using Airport.Services.MongoDBSevice;
using Airport.Services;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows;
using Airport.Command.AddDataCommands.Airport.Commands;

namespace Airport.ViewModels.WindowViewModels
{


    public class DelayedFlightsViewModel
    {
        private readonly IWindowService _windowService;
        
        public ObservableCollection<DelayedFlightInfo> DelayedFlights { get; set; }

        private DelayedFlightsService _delayedFlightsService;
        private FlightService _flightService;

        public ICommand FinishDelayCommand { get; }

        public DelayedFlightsViewModel(IWindowService _windowService)
        {
            _delayedFlightsService = new DelayedFlightsService();
            _flightService = new FlightService();
            this._windowService = _windowService;
            FinishDelayCommand = new RelayCommand(FinishDelay);
            LoadDelayedFlights();
        }

        private void FinishDelay(object parameter)
        {
            var delayedFlightInfo = parameter as DelayedFlightInfo;
            MessageBoxResult result = MessageBox.Show(
                "Завершити затримку?",
                "Завершення затримки",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                delayedFlightInfo = parameter as DelayedFlightInfo;
                delayedFlightInfo.EndDelayDate = DateTime.Now;
                Flight flight = _flightService.GetFlightById(delayedFlightInfo.FlightId);
               
                flight.Status = "запланований";


            }
        } 
        private void LoadDelayedFlights()
        {
            try
            {
                var delayedFlightsList = _delayedFlightsService.GetDelayedFlightsData();
                DelayedFlights = new ObservableCollection<DelayedFlightInfo>(delayedFlightsList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}