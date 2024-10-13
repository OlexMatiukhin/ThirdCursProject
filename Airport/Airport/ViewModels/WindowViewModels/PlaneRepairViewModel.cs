using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Airport.ViewModels.WindowViewModels
{
    public class PlaneRepairsViewModel
    {
        public ObservableCollection<PlaneRepair> PlaneRepairs { get; set; }
        private PlaneRepairService _planeRepairService;
        public ICommand OpenEditWindowCommand { get; }
        private readonly IWindowService _windowService;
        public PlaneRepairsViewModel()
        {
            _planeRepairService = new PlaneRepairService();
            LoadPlaneRepairs();
            _windowService = new WindowService();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
        }
        private void OnEdit(object parameter)
        {

            var planeRepair = parameter as PlaneRepair;
            if (planeRepair != null)
            {
                _windowService.OpenWindow("ChangePlaneRepair", planeRepair);
                _windowService.CloseWindow();

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
