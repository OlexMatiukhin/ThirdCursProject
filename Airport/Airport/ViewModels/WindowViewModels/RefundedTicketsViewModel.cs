﻿using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Airport.Command.AddDataCommands.Airport.Commands;
using System.ComponentModel;
using System.Windows;

namespace Airport.ViewModels.WindowViewModels
{
    public class RefundedTicketsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<RefundedTicketInfo> _refundedTickets;
        public ICommand DeleteWindowCommand { get; }

        public ObservableCollection<RefundedTicketInfo> RefundedTickets
        {
            get => _refundedTickets;
            set
            {
                if (_refundedTickets != value)
                {
                    _refundedTickets = value;
                    OnPropertyChanged(nameof(RefundedTickets));
                }
            }
        }




        private string _searchLine;


        public string SearchLine
        {
            get => _searchLine;
            set
            {

                _searchLine = value;
                SearchOperation(_searchLine);
                OnPropertyChanged(nameof(SearchLine));


            }
        }

        public void SearchOperation(string searchLine)
        {
            LoadTickets();
            if (!string.IsNullOrEmpty(searchLine))
            {
                var searchResult = SearchRefundedTickets(searchLine);

                RefundedTickets = new ObservableCollection<RefundedTicketInfo>(searchResult);

            }

        }
        private RefundedTicketService _ticketService;
        private IWindowService _windowService;
        public ICommand OpenMainWindowCommand { get; }
        public RefundedTicketsViewModel(IWindowService windowService)
        {
            this._windowService = windowService;

            _ticketService = new RefundedTicketService();
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            LoadTickets();
            DeleteWindowCommand = new RelayCommand(OnDelete);

        }
        private void OnMainWindowOpen(object parameter)
        {

            _windowService.OpenWindow("MainMenuView");
            _windowService.CloseWindow();

        }
        public List<RefundedTicketInfo> SearchRefundedTickets(string query)
        {
            return RefundedTickets.Where(ticket =>
                ticket.RefundedTicketId.ToString().Contains(query) ||                         
                ticket.Date.ToString("yyyy-MM-dd").Contains(query) ||                                    
                ticket.RouteId.ToString().Contains(query) ||                                   
                ticket.Age.ToString().Contains(query) ||                                        
                ticket.Price.ToString().Contains(query) ||                                      
                (!string.IsNullOrEmpty(ticket.Gender) && ticket.Gender.Contains(query, StringComparison.OrdinalIgnoreCase)) || // Поиск по Gender
                (!string.IsNullOrEmpty(ticket.Fullname) && ticket.Fullname.Contains(query, StringComparison.OrdinalIgnoreCase)) || // Поиск по Fullname
                ticket.TicketId.ToString().Contains(query) ||                                   
                ticket.FlightId.ToString().Contains(query)                                      
            ).ToList();
        }


        private void LoadTickets()
        {
            try
            {
                var ticketList = _ticketService.GetRefundedTicketsData();
                RefundedTickets = new ObservableCollection<RefundedTicketInfo>(ticketList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }


        private void OnDelete(object parameter)
        {

            var refundedTicket = parameter as RefundedTicketInfo;
            if (refundedTicket != null)
            {

                MessageBoxResult resultOther = MessageBox.Show(
                             "Ви точно хочете видалити інформацію про повернений кивток?",
                             "Видалення інформації",
                             MessageBoxButton.YesNo,
                             MessageBoxImage.Warning);
                if (resultOther == MessageBoxResult.Yes)
                {

                    _ticketService.DeleteRefundedTicket(refundedTicket.RefundedTicketId);
                    MessageBox.Show(
                            "Інформацію успішно видалено!",
                              "Видалення інформації",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                }


            }





        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
