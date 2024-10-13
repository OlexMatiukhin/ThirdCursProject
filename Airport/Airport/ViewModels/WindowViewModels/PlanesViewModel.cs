using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Airport.ViewModels.WindowViewModels
{
    public class PlanesViewModel
    {
        public ObservableCollection<Plane> Planes { get; set; }
        private PlaneService _planeService;
        private readonly IWindowService _windowService;

        public PlanesViewModel()
        {
            _planeService = new PlaneService();
            _windowService= new WindowService();
            LoadPlanes();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
        }
        public ICommand OpenEditWindowCommand { get; }
        private void OnEdit(object parameter)
        {

            var passanger = parameter as Plane;
            if (passanger != null)
            {
                _windowService.OpenWindow("ChangePlane", passanger);
                _windowService.CloseWindow();

            }




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