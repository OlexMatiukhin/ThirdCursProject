﻿using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using Airport.ViewModels.DialogViewModels.AddDataViewModel;
using Airport.Views.Dialog.ChangeWindow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace Airport.ViewModels.WindowViewModels
{
    
    public class FlightsViewModel
    {
        public ObservableCollection<Flight> Flights { get; set; }
        private FlightService _flightService;
        private PassengerService _passengerService;
        private BaggageService _baggageService;
        private TicketService _ticketService;
        private SeatService _seatService;
        private PassengerCompletedFlightService _passangerCompletedFlightService;
        private CompletedFlightService _completedFlightService;


        public ICommand OpenEditWindowCommand { get; }
        public ICommand EndCustomsControlCommand { get; }
        public ICommand EndRegistrationPassengersCommand { get; }
        public ICommand ActivateFlightCommand { get; }
        public ICommand FinishFlightCommand { get; }
        public ICommand CancelFlightCommand { get; }
        public ICommand DelayFlightCommand { get; }

        private readonly IWindowService _windowService;
        public FlightsViewModel(IWindowService windowService)
        {
             this._windowService = windowService;
            _flightService = new FlightService();

           _passengerService= new PassengerService();
            _baggageService= new BaggageService();
            _ticketService= new TicketService();
            _seatService= new SeatService();
            _passangerCompletedFlightService  = new PassengerCompletedFlightService();
            _completedFlightService = new CompletedFlightService();

            OpenEditWindowCommand = new RelayCommand(OnEdit);
            EndCustomsControlCommand = new RelayCommand(EndCustomsControl);
            EndRegistrationPassengersCommand = new RelayCommand(EndRegistration);
            FinishFlightCommand = new RelayCommand(FinishFlight);   
            ActivateFlightCommand = new RelayCommand(ActivateFlight);
            CancelFlightCommand = new RelayCommand(CancelFlight);
            DelayFlightCommand = new RelayCommand(DelayFlight);
            LoadFlights();
        }


        private Flight _selectedFlight;

        public Flight SelectedFlight
        {
            get => _selectedFlight;
            set
            {
                _selectedFlight = value;
                OnPropertyChanged(nameof(SelectedFlight));
                
            }
        }
        private void OnEdit(object parameter)
        {
            
            var flight = parameter as Flight;
            if (flight != null)
            {
                _windowService.OpenModalWindow("ChangeFlight", flight);
               

            }
            



        }

        private void EndCustomsControl(object parameter)
        {

            var flight = parameter as Flight;
            if (flight != null&& flight.Status=="запланований" && (flight.Category=="чартений"|| flight.Category=="міжнародний" ||flight.Category=="внутрішний") )
            {
                MessageBoxResult result = MessageBox.Show(
                  "Митний контроль завершено?",
                  "Завершення митного контролю",
                  MessageBoxButton.YesNo,
                  MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes) {
                    flight.CustomsControl = "завершений";
                    _flightService.UpdateFlight(flight);
                }
               

       

            }
        }

        private void EndRegistration(object parameter)
        {


            var flight = parameter as Flight;
            if (flight != null && flight.Status == "запланований" && (flight.Category == "чартений" || flight.Category == "міжнародний" || flight.Category == "внутрішний"))
            {
                
                   
                    MessageBoxResult result = MessageBox.Show(
                     "Реєстрацію пасажирів на рейс завершено?",
                     "Завершення реєстрації пасажирів",
                     MessageBoxButton.YesNo,
                     MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        flight.PassengerRegistration = "завершена";
                        _flightService.UpdateFlight(flight);
                    }
            }
              


         }   
        
        private void ActivateFlight(object parameter)
        {


            var flight = parameter as Flight;

            switch (flight.Category)
            {
                case "міжнародний":
                case "пасажирський":
                    float boughtTicketPercent = flight.NumberTickets > 0
                    ? (float)flight.NumberBoughtTickets / flight.NumberTickets * 100
                    : 0;

                    if (flight != null && flight.CustomsControl == "завершений" && flight.PassengerRegistration == "завершена" && boughtTicketPercent >= 50)
                    {
                        MessageBoxResult result = MessageBox.Show(
                          "Активувати рейс?",
                          "Активація рейсу",
                          MessageBoxButton.YesNo,
                          MessageBoxImage.Warning);
                        if (result == MessageBoxResult.Yes)
                        {
                            flight.Status = "активний";
                            _flightService.UpdateFlight(flight); 
                        }



                    }
                break;
                case "чартерний":

                    if (flight != null && flight.CustomsControl == "завершений" && flight.PassengerRegistration == "завершена")
                    {
                        MessageBoxResult resultCharter = MessageBox.Show(
                          "Активувати рейс?",
                          "Активація рейсу",
                          MessageBoxButton.YesNo,
                          MessageBoxImage.Warning);
                        if (resultCharter == MessageBoxResult.Yes)
                        {
                            flight.Status = "активний";
                            _flightService.UpdateFlight(flight);
                        }
                    }

                    break;
                default:

                    MessageBoxResult resultOther = MessageBox.Show(
                      "Активувати рейс?",
                      "Активація рейсу",
                      MessageBoxButton.YesNo,
                      MessageBoxImage.Warning);
                    if (resultOther == MessageBoxResult.Yes)
                    {
                        flight.Status = "активний";
                        _flightService.UpdateFlight(flight);
                    }
                    break;
            }

          
        }
        private void FinishFlight(object parameter)
        {


            var flight = parameter as Flight;



            if(flight!=null&& flight.Status == "активний")
            {


                MessageBoxResult result = MessageBox.Show(
                 "Завершети рейс?",
                 "Завершення рейсу",
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Warning);
                if (flight.Category =="внутрішній" || flight.Category == "міжнародний")
                {

                    _passangerCompletedFlightService.AddPassengersToCompletedFlight(_passengerService.GetPassengersByFlightId(flight.FlightId));
                    _baggageService.DeleteBaggageByPassanger(_passengerService.GetPassengersByFlightId(flight.FlightId));
                    _passengerService.DeletePassangersByFlightId(flight.FlightId);
                    _ticketService.DeleteTicketsByFlightId(flight.FlightId);
                    _seatService.DeleteSeatsByFlightId(flight.FlightId);
                    _completedFlightService.AddCompletedFlightFromFlight(flight);
                    _flightService.DeleteFlight(flight.FlightId);
                    Flights.Remove(flight);




                }
                else
                {
                    _completedFlightService.AddCompletedFlightFromFlight(flight);
                    _flightService.DeleteFlight(flight.FlightId);
                }

            }
        }

     
        private void CancelFlight(object parameter)
        {

            MessageBoxResult result = MessageBox.Show(
                "Cкасувати рейс?",
                "Скасування рейсу",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes) {
                var flight = parameter as Flight;
                _windowService.OpenModalWindow("AddCanceledFlightInfoView", parameter, Flights);
            }
     
            
        }


        private void DelayFlight(object parameter)
        {
            var flight = parameter as Flight;
            if (flight !=null && flight.Status=="запланований"&& flight.Category!="спеціальний")
            {
                _windowService.OpenModalWindow("AddDelayedFlightInfoView", flight);
            }

        }

        private void LoadFlights()
        {
            try
            {
                var flightList = _flightService.GetFlightsData();
                Flights = new ObservableCollection<Flight>(flightList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}