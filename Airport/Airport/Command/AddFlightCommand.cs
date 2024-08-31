using Airport.Models;
using Airport.Services;
using Airport.ViewModels.DialogViewModels;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Airport.Command
{
    public class AddFlightCommand : ComandBase
    {
        private AddFlightViewModel _addFlightViewModel;
        private FlightService _flightService;
        private SeatService _seatservice ;
        private TicketService _ticketService;

        public AddFlightCommand(AddFlightViewModel addFlightViewModel)
        {
            this._addFlightViewModel = addFlightViewModel;
            _flightService=new FlightService();
             _seatservice = new SeatService();
              _ticketService = new TicketService();
    }

        public override void Execute(object parameter)
        {
            int flightId = _flightService.GetLastFlightId() + 1;
            int firstSeatId= _seatservice.GetLastSeatId() + 1;
            int firstTicketId = _ticketService.GetLastTicketId() + 1;


            Flight newFlight = new Flight
            {
                //FlightId= _flightService.Get
                FlightNumber = _addFlightViewModel.FlightNumber,
                FlightId = flightId,
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
           
           

            for (int i=0; i< int.Parse(_addFlightViewModel.NumberTickets); i++)
            {
                Seat seat = new Seat
                {
                    SeatId = firstSeatId + i,
                    Number = i + 1,
                    Status = "Вільне",
                    FlightId = flightId

                };

                Ticket ticket = new Ticket
                {
                    TicketId = firstTicketId + i,
                    DateChanges = DateTime.Now,
                    Availability= true,
                    Status = "Доступний",
                    Price= int.Parse(_addFlightViewModel.TicketPrice),
                    FlightId = flightId,
                    SeatId = firstSeatId + i,
                    PassengerId =0

                };
                _seatservice.AddSeat(seat);
                _ticketService.AddTicket(ticket);
            }
            _flightService.AddFlight(newFlight);



        }

    }
}
