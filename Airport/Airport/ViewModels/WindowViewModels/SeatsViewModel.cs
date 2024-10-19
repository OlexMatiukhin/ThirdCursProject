
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;

namespace Airport.ViewModels.WindowViewModels
{
    public class SeatsViewModel
    {
        public ObservableCollection<Seat> Seats { get; set; }
        private SeatService _seatService;
        private IWindowService _windowService;
        public SeatsViewModel(IWindowService _windowService)
        {
            _seatService = new SeatService();
            this._windowService = _windowService;
            LoadSeats();
        }

        private void LoadSeats()
        {
            try
            {
                var seatList = _seatService.GetSeatsData();
                Seats = new ObservableCollection<Seat>(seatList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
