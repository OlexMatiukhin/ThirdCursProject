using Airport.Models; 
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Airport.ViewModels
{
    public class PositionsViewModel
    {
        public ObservableCollection<Position> Positions { get; set; }
        private PositionService _positionService;

        public PositionsViewModel()
        {
            _positionService = new PositionService();
            LoadPositions();
        }

        private void LoadPositions()
        {
            try
            {
                var positionList = _positionService.GetPositionsData();
                Positions = new ObservableCollection<Position>(positionList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
