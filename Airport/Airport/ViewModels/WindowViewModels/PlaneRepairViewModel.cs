using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Plane = Airport.Models.Plane;

namespace Airport.ViewModels.WindowViewModels
{
    public class PlaneRepairsViewModel
    {
        public ObservableCollection<PlaneRepair> PlaneRepairs { get; set; }
        private PlaneRepairService _planeRepairService;
        private PlaneService _planeService;
        public ICommand OpenEditWindowCommand { get; }
        private readonly IWindowService _windowService;
        public PlaneRepairsViewModel()
        {
            _planeRepairService = new PlaneRepairService();
            _planeService = new PlaneService();
            LoadPlaneRepairs();
            _windowService = new WindowService();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
        }
        private void OnEdit(object parameter)
        {            var planeRepair = parameter as PlaneRepair;
            if (planeRepair != null)
            {
                _windowService.OpenWindow("ChangePlaneRepair", planeRepair);
                _windowService.CloseWindow();
            }

        }


        private void OnRepairFinish(object parameter)
        {

            var planeRepair = parameter as PlaneRepair;
            if (planeRepair != null)
            {
                MessageBoxResult result = MessageBox.Show(
                  "Завершити ремонт?",
                  "Завершення ремонту",
                  MessageBoxButton.YesNo,
                  MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {                  
                     MessageBoxResult resultQuesion = MessageBox.Show(
                    "Результат успішний?",
                    "Так",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                    Plane plane = _planeService.GetPlaneById(planeRepair.PlaneId);
                    if (resultQuesion == MessageBoxResult.Yes)
                    {                     
                        plane.TechCondition = "задовільний";
                        plane.TechInspectionDate = DateTime.Now;
                        _planeService.UpdatePlane(plane);
                        planeRepair.Status = "завершений";
                        planeRepair.Result = "успіх";
                    }
                    else
                    {
                        plane.TechCondition = "списання";
                        plane.TechInspectionDate = DateTime.Now;
                        _planeService.UpdatePlane(plane);
                        planeRepair.Status = "завершений";
                        planeRepair.Result = "ремонту не підлягає";
                    }

                }


            }




        }
        private void LoadPlaneRepairs()
        {
            try
            {
                var planeRepairList = _planeRepairService.GetPlaneRepairsData();
                PlaneRepairs = new ObservableCollection<PlaneRepair>(planeRepairList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
