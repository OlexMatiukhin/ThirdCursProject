using Airport.Models;
using Airport.Services;
using Airport.ViewModels.DialogViewModels;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Airport.Command
{
    public class AddFlightCommand : ComandBase
    {
        private AddFlightViewModel _addFlightViewModel;
        private FlightService _flightService;

        public AddFlightCommand(AddFlightViewModel addFlightViewModel)
        {
            this._addFlightViewModel = addFlightViewModel;
            _flightService=new FlightService();
        }

        public override void Execute(object parameter)
        {

            Flight newFlight = new Flight
            {
                //FlightId= _flightService.Get
                FlightNumber = _addFlightViewModel.FlightNumber,
                FlightId = _flightService.GetLastFlightId()+1,
                Status = "Активний",
                Category = _addFlightViewModel.SelectedCategory,
                DateDeparture = _addFlightViewModel.DateDeparture,
                DateArrival = _addFlightViewModel.DateArrivial,
                PlaneId = _addFlightViewModel.SelectedPlaneId,
                DispatchBrigadeId = _addFlightViewModel.SelectedDispatchBrigadeId,
                NavigationBrigadeId = _addFlightViewModel.SelectedNavigationBrigadeId,
                FlightBrigadeId = _addFlightViewModel.SelectedFlightBrigadeId,
                InspectionBrigadeId = _addFlightViewModel.SelectedTechInspectionBrigadeId,
                RouteId = _addFlightViewModel.RouteId 
        
            };
            _flightService.AddFlight(newFlight);
        }

    }
}
