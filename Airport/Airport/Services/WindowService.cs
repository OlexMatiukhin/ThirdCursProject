using Airport.Models;
using Airport.ViewModels.DialogViewModels.AddDataViewModel;
using Airport.ViewModels.DialogViewModels.Change;
using Airport.ViewModels.DialogViewModels.ChangeDataViewModel;
using Airport.ViewModels.MenuViewModels;
using Airport.ViewModels.WindowViewModels;
using Airport.Views.Dialog;
using Airport.Views.Dialog.AddWindow;
using Airport.Views.Dialog.ChangeWindow;
using Airport.Views.MenuWindows;
using Airport.Views.Windows;
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
        Window modalWindow;

        Window window;
        public void OpenWindow(string windowName)
        {
             window = null;

            switch (windowName)
            {


                case "BaggageView":
                    window = new BaggageView();
                    window.DataContext = new BaggageViewModel(this);
                    break;
                case "BrigadesView":
                    window = new BrigadesView();
                    window.DataContext = new BrigadesViewModel(this);
                    break;
                case "CanceledFlightsView":
                    window = new CanceledFlightsView();
                    window.DataContext = new CanceledFligthsViewModel(this);
                    break;
                case "CompletedFlightsView":
                    window = new CompletedFlightsView();
                    window.DataContext = new CompletedFlightsViewModel(this);
                    break;
                case "DelayedFlightsInfoView":
                    window = new DelayedFlightsInfoView();
                    window.DataContext = new DelayedFlightsViewModel(this);
                    break;
                case "DepartmentsView":
                    window = new DepartmentsView();
                    window.DataContext = new DepartmentsViewModel(this);
                    break;
                case "FlightsView":
                    window = new FlightsView();
                    window.DataContext = new FlightsViewModel(this);
                    break;
                case "PassengerCompletedFlightView":
                    window = new BaggageView();
                    window.DataContext = new BaggageViewModel(this);
                    break;
                case "PassengersView":
                    window = new BaggageView();
                    window.DataContext = new BaggageViewModel(this);
                    break;
                case "PilotsMedExamView":
                    window = new PilotsMedExamView();
                    window.DataContext = new PilotsMedExamsViewModel(this);
                    break;
                case "PlaneRepairView":
                    window = new planeRepairView();
                    window.DataContext = new PlaneRepairsViewModel(this);
                    break;

                case "PlanesView":
                    window = new BaggageView();
                    window.DataContext = new BaggageViewModel(this);
                    break;
                case "PositionsView":
                    window = new BaggageView();
                    window.DataContext = new BaggageViewModel(this);
                    break;
                case "RefundedTicketsView":
                    window = new BaggageView();
                    window.DataContext = new BaggageViewModel(this);
                    break;
                case "RoutesView":
                    window = new BaggageView();
                    window.DataContext = new BaggageViewModel(this);
                    break;
                case "SeatsView":
                    window = new BaggageView();
                    window.DataContext = new BaggageViewModel(this);
                    break;
                case "StructureUnitsView":
                    window = new BaggageView();
                    window.DataContext = new BaggageViewModel(this);
                    break;
                case "TicketsView":
                    window = new BaggageView();
                    window.DataContext = new BaggageViewModel(this);
                    break;
                case "WorkersView":
                    window = new BaggageView();
                    window.DataContext = new BaggageViewModel(this);
                    break;
                case "MainMenuView":
                    window = new MainMenuView();
                    window.DataContext = new MainMenuViewModel(this);
                    break;

















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

        public void OpenModalWindow(string windowName, object parameter = null)
        {
            modalWindow = null;
            switch (windowName)
            {
                // ChangeWindows
                case "ChangeFlight":
                    modalWindow = new ChangeFlight();
                    if (parameter is Flight flight)
                    {
                        modalWindow.DataContext = new ChangeFlightViewModel(flight, this);
                    }
                    break;
                case "ChangeBaggage":
                    modalWindow = new ChangeBaggage();
                    if (parameter is Baggage baggage)
                    {
                        modalWindow.DataContext = new СhangeBaggageViewModel(baggage, this);
                    }
                    break;
                case "ChangeDepartment":
                    modalWindow = new ChangeDepartment();
                    if (parameter is Department department)
                    {
                        modalWindow.DataContext = new ChangeDepartmentViewModel(department, this);
                    }
                    break;
                case "ChangePassenger":
                    modalWindow = new ChangePassenger();
                    if (parameter is Passenger passenger)
                    {
                        modalWindow.DataContext = new ChangePassengerViewModel(passenger, this);
                    }
                    break;
                case "ChangePlane":
                    modalWindow = new ChangePlane();
                    if (parameter is Models.Plane plane)
                    {
                        modalWindow.DataContext = new ChangePlaneViewModel(plane, this);
                    }
                    break;
                case "ChangePosition":
                    modalWindow = new ChangePosition();
                    if (parameter is Models.Position positon)
                    {
                        modalWindow.DataContext = new ChangePositionViewModel(positon, this);
                    }
                    break;
                case "СhangeRoute":
                    modalWindow = new ChangeRoute();
                    if (parameter is Models.Route route)
                    {
                        modalWindow.DataContext = new ChangeRouteViewModel(route, this);
                    }
                    break;
                case "ChangeStructureUnit":
                    modalWindow = new ChangeStructureUnit();
                    if (parameter is Models.StructureUnit structureUnit)
                    {
                        modalWindow.DataContext = new ChangeStructureUnitViewModel(structureUnit, this);
                    }
                    break;
                case "ChangeWorker":
                    modalWindow = new ChangeWorker();
                    if (parameter is Models.Worker worker)
                    {
                        modalWindow.DataContext = new ChangeWorkerViewModel(worker, this);
                    }
                    break;
                case "ChangePilotMedExam":
                    modalWindow = new ChangePilotMedExam();
                    if (parameter is Models.PilotMedExam pilotMedExam)
                    {
                        modalWindow.DataContext = new ChangePilotMedExamViewModel(pilotMedExam, this);
                    }
                    break;
                case "ChangePlaneRepair":
                    modalWindow = new ChangePlaneRepair();
                    if (parameter is Models.PlaneRepair planeRepair)
                    {
                        modalWindow.DataContext = new ChangePlaneRepairViewModel(planeRepair, this);
                    }
                    break;


                //AddWindows
                case "AddBaggeViewModel":
                    modalWindow = new AddBaggageView();
                    modalWindow.DataContext = new AddBaggeViewModle(this);

                    break;
                case "AddBrigadeViewModel":
                    modalWindow = new AddBaggageView();
                    modalWindow.DataContext = new AddBaggeViewModle(this);
                    break;
                case "AddDepartmetnViewModel":
                    modalWindow = new AddBaggageView();
                    modalWindow.DataContext = new AddBaggeViewModle(this);
                    break;
                case "AddFlightViewModel":

                    modalWindow = new AddBaggageView();
                    modalWindow.DataContext = new AddBaggeViewModle(this);
                    break;
                case "AddPassengerViewModel.cs":
                    modalWindow = new AddBaggageView();
                    modalWindow.DataContext = new AddBaggeViewModle(this);
                    break;
                case "AddPlaneViewModel.cs":
                    modalWindow = new AddBaggageView();
                    modalWindow.DataContext = new AddBaggeViewModle(this);
                    break;
                case "AddPositionViewModel.cs":
                    modalWindow = new AddBaggageView();
                    modalWindow.DataContext = new AddBaggeViewModle(this);
                    break;
                case "AddRouteViewModel.cs":
                    modalWindow = new AddBaggageView();
                    modalWindow.DataContext = new AddBaggeViewModle(this);
                    break;
                case "AddSeatViewModel.cs":
                    modalWindow = new AddBaggageView();
                    modalWindow.DataContext = new AddBaggeViewModle(this);
                    break;

                case "AddStructureUnitViewModel.cs":
                    modalWindow = new AddBaggageView();
                    modalWindow.DataContext = new AddBaggeViewModle(this);
                    break;
                case "AddTicketViewModel.cs":
                    modalWindow = new AddBaggageView();
                    modalWindow.DataContext = new AddBaggeViewModle(this);
                    break;
                case "AddWorkerViewModel.cs":
                    modalWindow = new AddBaggageView();
                    modalWindow.DataContext = new AddBaggeViewModle(this);
                    break;
            }
            if (modalWindow != null)
            {
                modalWindow.ShowDialog();
            }
        }      
        public void CloseModalWindow()
        {
            modalWindow.Close();
        }
    }
}
