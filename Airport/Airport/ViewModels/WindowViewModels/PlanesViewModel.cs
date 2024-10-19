using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Airport.ViewModels.WindowViewModels
{



    public class PlanesViewModel
    {
        public ObservableCollection<Plane> Planes { get; set; }
        private PlaneService _planeService;
        private PlaneRepairService _planeRepairService;


        private readonly IWindowService _windowService;
     


        public PlanesViewModel(IWindowService windowService)
        {
            _planeService = new PlaneService();
            this._windowService = windowService;
            LoadPlanes();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            ChangeFuelStatusCommand = new RelayCommand(OnChangeFuleStatus);
            ChangeInteriorReadines = new RelayCommand(OnChangeInteriorReadines);
            ChangeTechConditionStatus = new RelayCommand(OnChangeTechConditionStatus);

        }
        public ICommand OpenEditWindowCommand { get; }

        public ICommand ChangeFuelStatusCommand { get; }
        public ICommand ChangeInteriorReadines { get; }
        public ICommand ChangeTechConditionStatus { get; }

        private void OnEdit(object parameter)
        {

            var plane = parameter as Plane;
            if (plane != null)
            {
                _windowService.OpenModalWindow("ChangePlane", plane);
             

            }




        }

        private void OnChangeFuleStatus(object parameter)
        {

            var plane = parameter as Plane;
            if (plane != null && plane.PlaneFuelStatus != "заправлений" && plane.TechCondition == "задовільний")
            {
                MessageBoxResult result = MessageBox.Show(
                  "Заправити літак?",
                  "Заправити",
                  MessageBoxButton.YesNo,
                  MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    plane.PlaneFuelStatus = "заправлений";

                    _planeService.UpdatePlane(plane);

                    MessageBox.Show("Літак заправлено!", "Успішний результат", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            else
            {
                if (plane.PlaneFuelStatus == "заправлений")
                {
                    MessageBox.Show("Літак вже заправлено! ", " Помилка заправки", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show(" Літак має не корректний статус технічної перевірки!", "Помилка заправки", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }


        private void OnChangeInteriorReadines(object parameter)
        {

            var plane = parameter as Plane;
            if (plane != null && plane.InteriorReadiness != "готовий" && plane.TechCondition == "задовільний")
            {
                MessageBoxResult result = MessageBox.Show(
                  "Підготувати салон?",
                  "Підготовка салону",
                  MessageBoxButton.YesNo,
                  MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    plane.InteriorReadiness = "готовий";

                    _planeService.UpdatePlane(plane);

                    MessageBox.Show("Салон готовий!", "Успішний результат", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            else
            {
                if (plane.InteriorReadiness == "готовий")
                {
                    MessageBox.Show("Салон готовий!", "Успішний результат!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(" Літак має не корректний статус технічної перевірки!", "Помилка заправки", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }

        private void OnChangeTechConditionStatus(object parameter)
        {

            var plane = parameter as Plane;
            if (plane != null&& plane.TechCondition!="в ремонті")
            {
                MessageBoxResult result = MessageBox.Show(
                          "Cтан задовільний?",
                          "",
                          MessageBoxButton.YesNo,
                          MessageBoxImage.Question); 
                if (result == MessageBoxResult.Yes)
                {
                   


                    Planes.First(p => p.PlaneId == plane.PlaneId).TechCondition = "задовільний";
                    _planeService.UpdatePlane(plane);

                    MessageBox.Show("Cтан встановлено на задовілний", "Успішний результат", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBoxResult resultRepairQuestion = MessageBox.Show(
                         "Відправити?",
                         "",
                         MessageBoxButton.YesNo,
                         MessageBoxImage.Question);
                    if (resultRepairQuestion == MessageBoxResult.Yes)
                    {
                        PlaneRepair planeRepair = new PlaneRepair();
                       
                        planeRepair.StartDate = DateTime.Now;
                        planeRepair.Status = "активний";
                        planeRepair.NumberFlights = plane.NumberFlightsBeforeRepair;
                        _planeRepairService.Add(planeRepair);
                        plane.NumberFlightsBeforeRepair = 0;
                        plane.TechCondition = "в ремонті";
                        MessageBox.Show("Літак відправлено у ремонт!", "Успішний результат", MessageBoxButton.OK, MessageBoxImage.Information);

                    }

                }

            }
            else
            {
                
                    MessageBox.Show(" Літак знаходиться в ремонті!", "Помилка перевірки", MessageBoxButton.OK, MessageBoxImage.Error);

             }




        }

        private void LoadPlanes()
        {
            try
            {
                var planeList = _planeService.GetPlanesData();
                Planes = new ObservableCollection<Plane>(planeList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка завнатаження: {ex.Message}");
            }
        }

    }
}