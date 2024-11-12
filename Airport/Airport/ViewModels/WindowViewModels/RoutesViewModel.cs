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
using System.ComponentModel;
using System.Windows;

namespace Airport.ViewModels.WindowViewModels
{
    public class RoutesViewModel : INotifyPropertyChanged
    {




        public ICommand OpenMainWindowCommand { get; }
        public ICommand DeleteWindowCommand { get; }

        private ObservableCollection<Route> _routes;


        public ObservableCollection<Route> Routes
        {
            get => _routes;
            set
            {
                if (_routes != value)
                {
                    _routes = value;
                    OnPropertyChanged(nameof(Routes));
                }
            }
        }


        private string _searchLine;


        public string SearchLine
        {
            get => _searchLine;
            set
            {

                _searchLine = value;
                SearchOperation(_searchLine);
                OnPropertyChanged(nameof(SearchLine));


            }
        }

        public void SearchOperation(string searchLine)
        {
            LoadRoutes();
            if (!string.IsNullOrEmpty(searchLine))
            {
                var searchResult = SearchRoutes(searchLine);

                Routes = new ObservableCollection<Route>(searchResult);

            }

        }

        private RouteService _routeService;
        public ICommand OpenEditWindowCommand { get; }
        private readonly IWindowService _windowService;
        private readonly PlaneRepairService _planeService;
        public ICommand OpenAddWindowCommand { get; }
        public RoutesViewModel(IWindowService windowService)
        {
            _routeService = new RouteService();
            this._windowService = windowService;
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            _windowService= new WindowService();
            OpenAddWindowCommand = new RelayCommand(OnAdd);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            DeleteWindowCommand = new RelayCommand(OnDelete);

            LoadRoutes();
        }
        private void OnMainWindowOpen(object parameter)
        {

            _windowService.OpenWindow("MainMenuView");
            _windowService.CloseWindow();

        }


        private void OnAdd(object parameter)
        {
            _windowService.OpenModalWindow("AddRoute");



        }
        private void OnEdit(object parameter)
        {

            var route = parameter as Route;
            if (route != null)
            {
                _windowService.OpenModalWindow("СhangeRoute", route);
                

            }




        }

        public List<Route> SearchRoutes(string query)
        {
            return Routes.Where(route =>
                route.RouteId.ToString().Contains(query) ||                                      // Поиск по RouteId
                (!string.IsNullOrEmpty(route.Number) && route.Number.Contains(query, StringComparison.OrdinalIgnoreCase)) || // Поиск по Number
                (!string.IsNullOrEmpty(route.DeparturePoint) && route.DeparturePoint.Contains(query, StringComparison.OrdinalIgnoreCase)) || // Поиск по DeparturePoint
                (!string.IsNullOrEmpty(route.ArrivalPoint) && route.ArrivalPoint.Contains(query, StringComparison.OrdinalIgnoreCase)) || // Поиск по ArrivalPoint
                (!string.IsNullOrEmpty(route.TransitAirport) && route.TransitAirport.Contains(query, StringComparison.OrdinalIgnoreCase)) || // Поиск по TransitAirport
                (!string.IsNullOrEmpty(route.FlightDirection) && route.FlightDirection.Contains(query, StringComparison.OrdinalIgnoreCase))  // Поиск по FlightDirection
            ).ToList();
        }

        private void LoadRoutes()
        {
            try
            {
                var routeList = _routeService.GetRoutes(); 
                Routes = new ObservableCollection<Route>(routeList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
        private void OnDelete(object parameter)
        {

            var route = parameter as Route;
            if (route != null && !_routeService.HasFlightsWithRoute(route.RouteId))
            {

                MessageBoxResult resultOther = MessageBox.Show(
                             "Ви точно хочете видалити маршрут?",
                             "Видалення маршруту",
                             MessageBoxButton.YesNo,
                             MessageBoxImage.Warning);
                if (resultOther == MessageBoxResult.Yes)
                {

                    _routeService.DeleteRoute(route.RouteId);
                    MessageBox.Show(
                            "Маршрут успішно видалено!",
                            "Видалення інформації про маршрут",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                }


            }
            else
            {
                MessageBox.Show(
                            "Видалення літака неможливо, з ним заплановано рейси!",
                              "Видалення інформації",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);

            }






        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
