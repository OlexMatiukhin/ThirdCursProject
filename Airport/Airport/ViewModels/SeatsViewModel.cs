
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Airport.Models;
using Airport.Services;

namespace Airport.ViewModels
{
    public class SeatsViewModel
    {
        public ObservableCollection<Seat> Seats { get; set; }
        private SeatService _seatService;

        public SeatsViewModel()
        {
            _seatService = new SeatService();
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
