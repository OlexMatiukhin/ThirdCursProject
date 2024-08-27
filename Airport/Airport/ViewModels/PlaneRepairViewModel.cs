using Airport.Models;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.ViewModels
{
    public class PlaneRepairsViewModel
    {
        public ObservableCollection<PlaneRepair> PlaneRepairs { get; set; }
        private PlaneRepairService _planeRepairService;

        public PlaneRepairsViewModel()
        {
            _planeRepairService = new PlaneRepairService();
            LoadPlaneRepairs();
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
