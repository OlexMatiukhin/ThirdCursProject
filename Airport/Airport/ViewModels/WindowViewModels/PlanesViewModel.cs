using Airport.Models;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Airport.ViewModels.WindowViewModels
{
    public class PlanesViewModel
    {
        public ObservableCollection<Plane> Planes { get; set; }
        private PlaneService _planeService;

        public PlanesViewModel()
        {
            _planeService = new PlaneService();
            LoadPlanes();
        }

        private void LoadPlanes()
        {
            try
            {
                var planeList = _planeService.GetPlanesData(); // Обновите метод на подходящий для PlaneService
                Planes = new ObservableCollection<Plane>(planeList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}