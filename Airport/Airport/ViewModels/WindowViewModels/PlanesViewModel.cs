using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBService;
using Airport.Services.MongoDBSevice;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Airport.ViewModels.WindowViewModels
{

    

    public class PlanesViewModel : INotifyPropertyChanged
    {

        public ICommand DeleteWindowCommand { get; }
        private readonly UserService _userService;

        public ObservableCollection<AirPlane> _planes;
        private PlaneService _planeService;
        private PlaneRepairService _planeRepairService;
        public ICommand OpenMainWindowCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly IWindowService _windowService;
        private User _user;




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
        private string _login;
        private string _accessRight;


        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }


        public string AccessRight
        {
            get => _accessRight;
            set
            {
                _accessRight = value;
                OnPropertyChanged(nameof(AccessRight));
            }
        }


        public PlanesViewModel(IWindowService windowService, User user)
        {
            _planeService = new PlaneService();
            this._windowService = windowService;
            LoadPlanes();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            ChangeFuelStatusCommand = new RelayCommand(OnChangeFuleStatus);
            ChangeInteriorReadines = new RelayCommand(OnChangeInteriorReadines);
            ChangeTechConditionStatus = new RelayCommand(OnChangeTechConditionStatus);
            OpenAddWindowCommand = new RelayCommand(OnAdd);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            DeleteWindowCommand = new RelayCommand(OnDelete);
            _userService = new UserService();
            this._user = user;
            Login = _user.Login;
            AccessRight = _user.AccessRight;
           


        }

        public void SearchOperation(string searchLine)
        {
            LoadPlanes();
            if (!string.IsNullOrEmpty(searchLine))
            {
                var searchResult = SearchAirplanes(searchLine);
               
                Planes = new ObservableCollection<AirPlane>(searchResult); 
                
            }
         
        }


        public ObservableCollection<AirPlane> Planes
        {
            get => _planes;
            set
            {
                _planes = value;
                OnPropertyChanged(nameof(Planes));
            }
        }

        private void OnMainWindowOpen(object parameter)
        {

            _windowService.OpenWindow("MainMenuView");
            _windowService.CloseWindow();

        }
        public ICommand OpenEditWindowCommand { get; }

        public ICommand ChangeFuelStatusCommand { get; }
        public ICommand ChangeInteriorReadines { get; }
        public ICommand ChangeTechConditionStatus { get; }
        public ICommand OpenAddWindowCommand { get; }

        private void OnEdit(object parameter)
        {
            if (_userService.IfUserCanDoCrud(_user))
            {
                var plane = parameter as AirPlane;
                if (plane != null)
                {
                    _windowService.OpenModalWindow("ChangePlane", plane);


                }
            }




        }
        private void OnAdd(object parameter)
        {
            if (_userService.IfUserCanDoCrud(_user))
            {
                _windowService.OpenModalWindow("AddPlane");
            }



        }

        private void OnChangeFuleStatus(object parameter)
        {
            if (_userService.IfUserCanDoAdditionalActions(_user))
            {
            

            var plane = parameter as AirPlane;
                if (plane != null && plane.PlaneFuelStatus != "заправлений" && plane.TechCondition == "задовільний")
                {
                    MessageBoxResult result = MessageBox.Show(
                      "Заправити літак?",
                      "Заправити",
                      MessageBoxButton.YesNo,
                      MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        plane.PlaneFuelStatus = "заправлений";

                        _planeService.UpdatePlane(plane);

                        MessageBox.Show("Літак заправлено!", "Успішний результат", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }
                else
                {
                    if (plane.PlaneFuelStatus == "заправлений")
                    {
                        MessageBox.Show("Літак вже заправлено! ", " Помилка заправки", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show(" Літак має не корректний статус технічної перевірки!", "Помилка заправки", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }

            }
        }

        public List<AirPlane> SearchAirplanes(string query)
        {
            
            
                return Planes.Where(plane =>
                    plane.PlaneId.ToString().Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    plane.Type.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    plane.TechCondition.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    plane.InteriorReadiness.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    plane.PlaneFuelStatus.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    plane.PlaneNumber.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                    plane.NumberFlightsBeforeRepair.ToString().Contains(query) ||
                    plane.TechInspectionDate.ToString("dd.MM.yyyy HH:mm:ss").Contains(query) ||
                    plane.TechInspectionDate.ToString("dd/MM/yyyy HH:mm:ss").Contains(query) || 
                    plane.Assigned.ToString().Contains(query) ||
                    plane.NumberRepairs.ToString().Contains(query) ||
                    plane.ExploitationDate.ToString("dd.MM.yyyy HH:mm:ss").Contains(query) || 
                    plane.ExploitationDate.ToString("dd/MM/yyyy HH:mm:ss").Contains(query) 
                ).ToList();
            
        }

        private void OnDelete(object parameter)
        {
            if (_userService.IfUserCanDoCrud(_user))
            {
                var plane = parameter as AirPlane;
                if (plane != null && _planeService.IsPlaneInFlight(plane.PlaneNumber))
                {

                    MessageBoxResult resultOther = MessageBox.Show(
                                 "Ви точно хочете видалити літак?",
                                 "Видалення інформації",
                                 MessageBoxButton.YesNo,
                                 MessageBoxImage.Warning);
                    if (resultOther == MessageBoxResult.Yes)
                    {

                        _planeRepairService.DeletePlaneRepair(plane.PlaneId);
                        MessageBox.Show(
                                "Літак успішно видалено!",
                                  "Видалення інформації",
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






        }


        private void OnChangeInteriorReadines(object parameter)
        {
            if (_userService.IfUserCanDoAdditionalActions(_user))
            {

                var plane = parameter as AirPlane;
                if (plane != null && plane.InteriorReadiness != "готовий" && plane.TechCondition == "задовільний")
                {
                    MessageBoxResult result = MessageBox.Show(
                      "Підготувати салон?",
                      "Підготовка салону",
                      MessageBoxButton.YesNo,
                      MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        plane.InteriorReadiness = "готовий";

                        _planeService.UpdatePlane(plane);

                        MessageBox.Show("Салон готовий!", "Успішний результат", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                }
                else
                {
                    if (plane.InteriorReadiness == "готовий")
                    {
                        MessageBox.Show("Салон готовий!", "Успішний результат!", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show(" Літак має не корректний статус технічної перевірки!", "Помилка заправки", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            }

        }

        private void OnChangeTechConditionStatus(object parameter)
        {
            if(_userService.IfUserCanDoAdditionalActions(_user))
            {
                var plane = parameter as AirPlane;
                if (plane != null && plane.TechCondition != "в ремонті")
                {
                    MessageBoxResult result = MessageBox.Show(
                              "Cтан задовільний?",
                              "",
                              MessageBoxButton.YesNo,
                              MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {



                        Planes.First(p => p.PlaneId == plane.PlaneId).TechCondition = "задовільний";
                        _planeService.UpdatePlane(plane);

                        MessageBox.Show("Cтан встановлено на задовілний", "Успішний результат", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBoxResult resultRepairQuestion = MessageBox.Show(
                             "Відправити?",
                             "",
                             MessageBoxButton.YesNo,
                             MessageBoxImage.Question);
                        if (resultRepairQuestion == MessageBoxResult.Yes)
                        {
                            PlaneRepair planeRepair = new PlaneRepair();

                            planeRepair.StartDate = DateTime.Now;
                            planeRepair.Status = "активний";
                            planeRepair.NumberFlights = plane.NumberFlightsBeforeRepair;
                            _planeRepairService.Add(planeRepair);
                            plane.NumberFlightsBeforeRepair = 0;
                            plane.TechCondition = "в ремонті";
                            MessageBox.Show("Літак відправлено у ремонт!", "Успішний результат", MessageBoxButton.OK, MessageBoxImage.Information);

                        }

                    }
                }

            }
            else
            {
                
                    MessageBox.Show(" Літак знаходиться в ремонті!", "Помилка перевірки", MessageBoxButton.OK, MessageBoxImage.Error);

             }




        }

        private void LoadPlanes()
        {
            try
            {
                var planeList = _planeService.GetPlanesData();
                Planes = new ObservableCollection<AirPlane>(planeList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка завнатаження: {ex.Message}");
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}