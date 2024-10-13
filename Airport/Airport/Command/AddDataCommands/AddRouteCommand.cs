using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.ViewModels.DialogViewModels.AddDataViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Command.AddDataCommands
{
    public class AddRouteCommand:CommandBase
    {
        private AddRouteViewModel _addRouteViewModel;
        private RouteService _routeService;


        public AddRouteCommand(AddBaggeViewModle _addBaggeViewModle)
        {
            this._addRouteViewModel = _addRouteViewModel;
            _routeService = new RouteService();
        }
        public override void Execute(object parameter)
        {
            int baggadeId = _routeService.GetLastRouteId() + 1;

            Route newRoute = new Route
            {
                RouteId = _routeService.GetLastRouteId() + 1,
                Number = _addRouteViewModel.Number,
                DeparturePoint = _addRouteViewModel.DeparturePoint,
                ArrivalPoint = _addRouteViewModel.ArrivalPoint,
                TransitAirport = _addRouteViewModel.TransitAirport,
                FlightDirection = _addRouteViewModel.FlightDirection
            };
            _routeService.AddRoute(newRoute);
        }
    
        public AddRouteCommand(AddRouteViewModel addRouteViewModel) 
        {
            this._addRouteViewModel = addRouteViewModel;
            _routeService = new RouteService();
        }
    }
}
