using Airport.Models;
using Airport.ViewModels.DialogViewModels.AddDataViewModel;
using Airport.ViewModels.DialogViewModels.Change;
using Airport.ViewModels.DialogViewModels.ChangeDataViewModel;
using Airport.Views.Dialog;
using Airport.Views.Dialog.ChangeWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Airport.Services
{
    public class WindowService : IWindowService
    {
        public void OpenWindow(string windowName, object parameter = null)
        {
            Window window = null;

            switch (windowName)
            {
                case "ChangeFlight":
                    window = new ChangeFlight();
                    if (parameter is Flight flight)
                    {
                        window.DataContext = new ChangeFlightViewModel(flight);
                    }
                    break;
                case "ChangeBaggage":
                    window = new ChangeBaggage();
                    if (parameter is Baggage baggage)
                    {
                        window.DataContext = new СhangeBaggageViewModel(baggage);
                    }
                    break;
                case "ChangeDepartment":
                window = new ChangeDepartment();
                if (parameter is Department department)
                {
                    window.DataContext = new ChangeDepartmentViewModel(department);
                }
                break;
                case "ChangePassenger":
                    window = new ChangePassenger();
                    if (parameter is Passenger passenger)
                    {
                        window.DataContext = new ChangePassengerViewModel(passenger);
                    }
                    break;
                case "ChangePlane":
                    window = new ChangePlane();
                    if (parameter is Models.Plane plane)
                    {
                        window.DataContext = new ChangePlaneViewModel(plane);
                    }
                    break;
                case "ChangePosition":
                    window = new ChangePosition();
                    if (parameter is Models.Position positon)
                    {
                        window.DataContext = new ChangePositionViewModel(positon);
                    }
                    break;
                case "СhangeRoute":
                    window = new ChangeRoute();
                    if (parameter is Models.Route route)
                    {
                        window.DataContext = new ChangeRouteViewModel(route);
                    }
                    break;
                case "ChangeStructureUnit":
                    window = new ChangeStructureUnit();
                    if (parameter is Models.StructureUnit structureUnit)
                    {
                        window.DataContext = new ChangeStructureUnitViewModel(structureUnit);
                    }
                    break;
                case "ChangeWorker":
                    window = new ChangeWorker();
                    if (parameter is Models.Worker worker) 
                    {
                        window.DataContext = new ChangeWorkerViewModel(worker);
                    }
                    break;
                case "ChangePilotMedExam":
                    window = new ChangePilotMedExam();
                    if (parameter is Models.PilotMedExam pilotMedExam)
                    {
                        window.DataContext = new ChangePilotMedExamViewModel(pilotMedExam);
                    }
                    break;
                case "ChangePlaneRepair":
                    window = new ChangePlaneRepair();
                    if (parameter is Models.PlaneRepair planeRepair)
                    {
                        window.DataContext = new ChangePlaneRepairViewModel(planeRepair);
                    }
                    break;





                    /*case "ChangeDepartment":
                    window = new ChangeBaggage();
                    if (parameter is Baggage baggage)
                    {
                        window.DataContext = new СhangeBaggageViewModel(baggage);
                    }
                    break;*/
                    /*case "ChangeDepartment":
                    window = new ChangeBaggage();
                    if (parameter is Baggage baggage)
                    {
                        window.DataContext = new СhangeBaggageViewModel(baggage);
                    }
                    break;*/
                    /*case "ChangeDepartment":
                    window = new ChangeBaggage();
                    if (parameter is Baggage baggage)
                    {
                        window.DataContext = new СhangeBaggageViewModel(baggage);
                    }
                    break;*/
                    /*case "ChangeDepartment":
                    window = new ChangeBaggage();
                    if (parameter is Baggage baggage)
                    {
                        window.DataContext = new СhangeBaggageViewModel(baggage);
                    }
                    break;*/
                    /*case "ChangeDepartment":
                    window = new ChangeBaggage();
                    if (parameter is Baggage baggage)
                    {
                        window.DataContext = new СhangeBaggageViewModel(baggage);
                    }
                    break;*/
                    /*case "ChangeDepartment":
                    window = new ChangeBaggage();
                    if (parameter is Baggage baggage)
                    {
                        window.DataContext = new СhangeBaggageViewModel(baggage);
                    }
                    break;*/

            }

            if (window != null)
            {
                window.Show();
            }
        }

        public void CloseWindow()
        {
            App.Current.Windows[0]?.Close();
        }
    }
}
