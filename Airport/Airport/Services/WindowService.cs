﻿using Airport.Models;
using Airport.ViewModels.DialogViewModels.AddDataViewModel;
using Airport.ViewModels.DialogViewModels.AdditionalViewModel;
using Airport.ViewModels.DialogViewModels.Change;
using Airport.ViewModels.DialogViewModels.ChangeDataViewModel;
using Airport.ViewModels.MenuViewModels;
using Airport.ViewModels.QueriesViewModel;
using Airport.ViewModels.WindowViewModels;
using Airport.Views;
using Airport.Views.Dialog;
using Airport.Views.Dialog.AddWindow;
using Airport.Views.Dialog.ChangeWindow;
using Airport.Views.MenuWindows;
using Airport.Views.QueryWindow;
using Airport.Views.Windows;
using Airport.Views.MenuWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using QueryMenuViewModel = Airport.ViewModels.MenuViewModels.QueryMenuViewModel;
using Airport.Command.AddDataCommands;
using Airport.Views.Dialog.AdditionalWindow;

namespace Airport.Services
{
    public class WindowService : IWindowService
    {
        Window modalWindow;

        Window window;
        public void OpenWindow(string windowName, object parameter=null)
        {
             window = null;

          
            switch (windowName)
            {
                case "BaggageView":
                    if (parameter is User user1)
                    {
                        window = new BaggageView();
                        window.DataContext = new BaggageViewModel(this, user1);
                    }
                    break;

                case "BrigadesView":
                    if (parameter is User user2)
                    {
                        window = new BrigadesView();
                        window.DataContext = new BrigadesViewModel(this, user2);
                    }
                    break;

                case "CanceledFlightsView":
                    if (parameter is User user3)
                    {
                        window = new CanceledFlightsView();
                        window.DataContext = new CanceledFlightsViewModel(this, user3);
                    }
                    break;

                case "CompletedFlightsView":
                    if (parameter is User user4)
                    {
                        window = new CompletedFlightsView();
                        window.DataContext = new CompletedFlightsViewModel(this, user4);
                    }
                    break;

                case "DelayedFlightsInfoView":
                    if (parameter is User user5)
                    {
                        window = new DelayedFlightsInfoView();
                        window.DataContext = new DelayedFlightsViewModel(this, user5);
                    }
                    break;

                case "DepartmentsView":
                    if (parameter is User user6)
                    {
                        window = new DepartmentsView();
                        window.DataContext = new DepartmentsViewModel(this, user6);
                    }
                    break;

                case "FlightsView":
                    if (parameter is User user7)
                    {
                        window = new FlightsView();
                        window.DataContext = new FlightsViewModel(this, user7);
                    }
                    break;

                case "PassengerCompletedFlightView":
                    if (parameter is User user8)
                    {
                        window = new PassengerCompletedFlightView();
                        window.DataContext = new PassengersCompletedFlightViewModel(this, user8);
                    }
                    break;

                case "PassengersView":
                    if (parameter is User user9)
                    {
                        window = new PassengersView();
                        window.DataContext = new PassengersViewModel(this, user9);
                    }
                    break;

                case "PilotsMedExamView":
                    if (parameter is User user10)
                    {
                        window = new PilotsMedExamView();
                        window.DataContext = new PilotsMedExamsViewModel(this, user10);
                    }
                    break;

                case "PlaneRepairView":
                    if (parameter is User user11)
                    {
                        window = new PlaneRepairView();
                        window.DataContext = new PlaneRepairsViewModel(this, user11);
                    }
                    break;

                case "PlanesView":
                    if (parameter is User user12)
                    {
                        window = new PlanesView();
                        window.DataContext = new PlanesViewModel(this, user12);
                    }
                    break;

                case "PositionsView":
                    if (parameter is User user13)
                    {
                        window = new PositionsView();
                        window.DataContext = new PositionsViewModel(this, user13);
                    }
                    break;

                case "RefundedTicketsView":
                    if (parameter is User user14)
                    {
                        window = new RefundedTicketsView();
                        window.DataContext = new RefundedTicketsViewModel(this, user14);
                    }
                    break;

                case "RoutesView":
                    if (parameter is User user15)
                    {
                        window = new RoutesView();
                        window.DataContext = new RoutesViewModel(this, user15);
                    }
                    break;

                case "SeatsView":
                    if (parameter is User user16)
                    {
                        window = new SeatsView();
                        window.DataContext = new SeatsViewModel(this, user16);
                    }
                    break;

                case "StructureUnitsView":
                    if (parameter is User user17)
                    {
                        window = new StructureUnitsView();
                        window.DataContext = new StructureUnitsViewModel(this, user17);
                    }
                    break;

                case "TicketsView":
                    if (parameter is User user18)
                    {
                        window = new TicketsView();
                        window.DataContext = new TicketsViewModel(this, user18);
                    }
                    break;

                case "WorkersView":
                    if (parameter is User user19)
                    {
                        window = new WorkersView();
                        window.DataContext = new WorkersViewModel(this, user19);
                    }
                    break;

                case "MainMenuView":
                    if (parameter is User user20)
                    {
                        window = new MainMenuView();
                        window.DataContext = new MainMenuViewModel(this, user20);
                    }
                    break;

                case "LoginView":
                    window = new LoginView();
                    window.DataContext = new LoginViewModel(this);
                    break;

                case "UserView":
                    if (parameter is User user21)
                    {
                        window = new UsersView();
                        window.DataContext = new UserViewModel(this, user21);
                    }
                    break;



                case "QueryOne":
                    if (parameter is User user22)
                    {
                        window = new QueryOne();
                        window.DataContext = new Query1ViewModel(this, user22);
                    }
                    break;


                case "Query2":
                    if (parameter is User user23)
                    {
                        window = new Query2();
                        window.DataContext = new Query2ViewModel(this, user23);
                    }
                    break;

                case "Query3":
                    if (parameter is User user24)
                    {
                        window = new Query3();
                        window.DataContext = new Query3ViewModel(this, user24);
                    }
                    break;

                case "Query4":
                    if (parameter is User user25)
                    {
                        window = new Query4();
                        window.DataContext = new Query4ViewModel(this, user25);
                    }
                    break;

                case "Query5":
                    if (parameter is User user26)
                    {
                        window = new Query5();
                        window.DataContext = new Query5ViewModel(this, user26);
                    }
                    break;

                case "Query6":
                    if (parameter is User user27)
                    {
                        window = new Query6();
                        window.DataContext = new Query6ViewModel(this, user27);
                    }
                    break;

                case "Query7":
                    if (parameter is User user28)
                    {
                        window = new Query7();
                        window.DataContext = new Query7ViewModel(this, user28);
                    }
                    break;
                case "Query8":
                    if (parameter is User user29)
                    {
                        window = new Query8();
                        window.DataContext = new Query8ViewModel(this, user29);
                    }
                    break;
                case "Query9":
                    if (parameter is User user30)
                    {
                        window = new Query9();
                        window.DataContext = new Query9ViewModel(this, user30);
                    }
                    break;
                case "Query10":
                    if (parameter is User user31)
                    {
                        window = new Query10();
                        window.DataContext = new Query10ViewModel(this, user31);
                    }
                    break;
                case "Query11":
                    if (parameter is User user32)
                    {
                        window = new Query11();
                        window.DataContext = new Query11ViewModel(this, user32);
                    }
                    break;
                case "Query12":
                    if (parameter is User user33)
                    {
                        window = new Query12();
                        window.DataContext = new Query12ViewModel(this, user33);
                    }
                    break;
                case "Query13":
                    if (parameter is User user34)
                    {
                        window = new Query13();
                        window.DataContext = new Query13ViewModel(this, user34);
                    }
                    break;

                case "QueryMenuView":
                    if (parameter is User user35)
                    {
                        window = new QueryMenuView();
                        window.DataContext = new QueryMenuViewModel(this, user35);
                    }
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

        public void OpenModalWindow(string windowName, object parameter = null, object paramet2=null)
        {
            modalWindow = null;
            switch (windowName)
            {
               
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

                case "ChangeBrigade":
                    modalWindow = new ChangeBrigade();
                    if (parameter is Brigade brigade)
                    {
                        modalWindow.DataContext = new ChangeBrigadeViewModel(brigade, this);
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
                    if (parameter is Models.AirPlane plane)
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

                case "ChangePilotPosition":
                    if (parameter is PilotMedExam pilotMedExam1 && paramet2 is Worker worker1)
                    {
                        modalWindow = new ChangePilotPositionView();
                        modalWindow.DataContext = new ChangePilotPositionViewModel(this, pilotMedExam1, worker1);


                    }
                    break;
                case "ChangeUser":
                    if (parameter is User user1)
                    {
                        modalWindow = new ChangeUser();
                        modalWindow.DataContext = new ChangeUserViewModel(this, user1);
                    }                                  
                    break;
                   
                case "AddBaggage":
                    modalWindow = new AddBaggageView();
                    modalWindow.DataContext = new AddBaggeViewModle(this);

                    break;
                case "AddBrigade":
                    modalWindow = new AddBrigadeView();
                    modalWindow.DataContext = new AddBrigadeViewModel(this);
                    break;

                case "AddDepartment":
                    modalWindow = new AddDepartmentView();
                    modalWindow.DataContext = new AddDepartmentViewModel(this);
                    break;

                case "AddFlight":

                    modalWindow = new AddFlightView();
                    modalWindow.DataContext = new AddFlightViewModel(this);
                    break;

                case "AddPassengerBuyTicket":

                    if (parameter is Models.Ticket ticket&& paramet2 is Flight flight1)
                    {
                        modalWindow = new AddPassengerView();
                        modalWindow.DataContext = new AddPassengerViewModel(this, ticket,flight1);


                    }
                   
                    break;

                case "AddPassengerBookTicket":

                    if (parameter is Models.Ticket ticket2)
                    {
                        modalWindow = new AddPassengerView();
                        modalWindow.DataContext = new AddPassangerBookingTicket(this, ticket2);


                    }

                    break;







                case "AddPlane":
                    modalWindow = new AddPlaneView();
                    modalWindow.DataContext = new AddPlaneViewModel(this);
                    break;



                case "AddPosition":
                    modalWindow = new AddPositionView();
                    modalWindow.DataContext = new AddPositionViewModel(this);
                    break;



                case "AddRoute":
                    modalWindow = new AddRouteView();
                    modalWindow.DataContext = new AddRouteViewModel(this);
                    break;


                /*case "AddSeat":
                    modalWindow = new AddSeatView();
                    modalWindow.DataContext = new AddSeatViewModel(this);
                    break;*/

                case "AddStructureUnit":
                    modalWindow = new AddStructureUnitView();
                    modalWindow.DataContext = new AddStructureUnitViewModel(this);
                    break;
                /*case "AddTicketView":
                    modalWindow = new AddBaggageView();
                    modalWindow.DataContext = new AddBaggeViewModle(this);

                    break;*/
                case "AddWorker":
                    modalWindow = new AddWorkerView();
                    modalWindow.DataContext = new AddWorkerViewModel(this);
                    break;
                case "AddCanceledFlightInfo":
                    if (parameter is Flight flightToCacnel&& paramet2 is ObservableCollection<Flight> flights)
                    {   modalWindow = new AddCanceledFlightView();
                        modalWindow.DataContext = new AddCanceledFlightViewModel(this, flightToCacnel, flights);
                    }
                break;

                case "AddDelayedFlightInfo":
                    if (parameter is Flight flightToDelay)
                    {
                        modalWindow = new AddDelayedFlightView();
                        modalWindow.DataContext = new AddDelayedFlightViewModel(this, flightToDelay);
                    }
                    break;

                case "AddUser":                   
                        modalWindow = new AddUserView();
                        modalWindow.DataContext = new AddUserViewModel(this);                   
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
