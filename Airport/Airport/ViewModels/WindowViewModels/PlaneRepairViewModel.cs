﻿using Airport.Command.AddDataCommands.Airport.Commands;
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
using AirPlane = Airport.Models.AirPlane;

namespace Airport.ViewModels.WindowViewModels
{
    public class PlaneRepairsViewModel
    {
        public ObservableCollection<PlaneRepair> PlaneRepairs { get; set; }
        private PlaneRepairService _planeRepairService;
        private PlaneService _planeService;
        public ICommand OpenEditWindowCommand { get; }
        private readonly IWindowService _windowService;
        public ICommand FinishRepairCommand { get; }
        public PlaneRepairsViewModel(IWindowService windowService)
        {
            _planeRepairService = new PlaneRepairService();
            _planeService = new PlaneService();
            this._windowService = windowService;
            LoadPlaneRepairs();
            _windowService = new WindowService();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            //FinishRepairCommand = new RelayCommand(OnRepairFinish);
        }
        private void OnEdit(object parameter)
        {   var planeRepair = parameter as PlaneRepair;
            if (planeRepair != null)
            {
                _windowService.OpenModalWindow("ChangePlaneRepair", planeRepair);
              
            }

        }


        private void OnRepairFinish(object parameter)
        {

            var planeRepair = parameter as PlaneRepair;
            if (planeRepair != null&& planeRepair.Status!="завершений")
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
                    AirPlane plane = _planeService.GetPlaneById(planeRepair.PlaneId);
                    if (resultQuesion == MessageBoxResult.Yes)
                    {                     
                        plane.TechCondition = "задовільний";
                        plane.TechInspectionDate = DateTime.Now;
                        planeRepair.EndDate = DateTime.Now;
                        _planeService.UpdatePlane(plane);
                        planeRepair.Status = "завершений";
                        planeRepair.Result = "успіх";
                    }
                    else
                    {
                        plane.TechCondition = "списання";
                        plane.TechInspectionDate = DateTime.Now;
                        _planeService.UpdatePlane(plane);
                        planeRepair.EndDate = DateTime.Now;
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
                Console.WriteLine($": {ex.Message}");
            }
        }
    }
}
