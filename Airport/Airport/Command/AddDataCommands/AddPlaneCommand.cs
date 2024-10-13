using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.ViewModels.DialogViewModels.AddDataViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Plane = Airport.Models.Plane;

namespace Airport.Command.AddDataCommands
{
    public class AddPlaneCommand : CommandBase
    {
        private AddPlaneViewModel _addPlaneViewModel;
        private PlaneService _planeService;


        public AddPlaneCommand(AddPlaneViewModel addPlaneViewModel)
        {
            _addPlaneViewModel = addPlaneViewModel;
            _planeService = new PlaneService();

        }



        public override void Execute(object parameter)
        {



            Plane newPlane = new Plane
            {
                PlaneId = _planeService.GetLastPlaneId() + 1,  
                Type = _addPlaneViewModel.SelectedPlaneType,
                TechCondition = "Задовільний",
                InteriorReadiness = "Готовий",
                NumberFlightsBeforeRepair = 0,
                TechInspectionDate = DateTime.Now,
                Assigned = _addPlaneViewModel.Assigned,
                NumberRepairs = 0,
                ExploitationDate = DateTime.Now,

            };

            _planeService.AddPlane(newPlane);


        }
    }
}
