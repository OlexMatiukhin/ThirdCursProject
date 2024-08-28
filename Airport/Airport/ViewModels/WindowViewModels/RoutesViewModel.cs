using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.Models;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Airport.ViewModels.WindowViewModels
{
    public class RoutesViewModel
    {
        public ObservableCollection<Route> Routes { get; set; }
        private RouteService _routeService;

        public RoutesViewModel()
        {
            _routeService = new RouteService();
            LoadRoutes();
        }

        private void LoadRoutes()
        {
            try
            {
                var routeList = _routeService.GetRoutes(); // Обновите метод на подходящий для RouteService
                Routes = new ObservableCollection<Route>(routeList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
