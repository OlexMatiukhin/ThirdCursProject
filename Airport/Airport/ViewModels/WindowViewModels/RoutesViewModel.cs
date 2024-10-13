using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Airport.Services.MongoDBSevice;
using System.Windows.Input;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Services;

namespace Airport.ViewModels.WindowViewModels
{
    public class RoutesViewModel
    {
        public ObservableCollection<Route> Routes { get; set; }
        private RouteService _routeService;
        public ICommand OpenEditWindowCommand { get; }
        private readonly IWindowService _windowService;
        public RoutesViewModel()
        {
            _routeService = new RouteService();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            _windowService= new WindowService();

            LoadRoutes();
        }
        private void OnEdit(object parameter)
        {

            var route = parameter as Route;
            if (route != null)
            {
                _windowService.OpenWindow("СhangeRoute", route);
                _windowService.CloseWindow();

            }




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
