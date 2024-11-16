using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBService;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AirPlane = Airport.Models.AirPlane;

namespace Airport.ViewModels.WindowViewModels
{
    public class PlaneRepairsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PlaneRepair> _planeRepairs;
        private readonly UserService _userService;
        public ICommand DeleteWindowCommand { get; }
        private User _user;

        public ObservableCollection<PlaneRepair> PlaneRepairs
        {
            get => _planeRepairs;
            set
            {
                if (_planeRepairs != value)
                {
                    _planeRepairs = value;
                    OnPropertyChanged(nameof(PlaneRepairs));
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



        public void SearchOperation(string searchLine)
        {
            LoadPlaneRepairs();
            if (!string.IsNullOrEmpty(searchLine))
            {
                var searchResult = SearchRepairs(searchLine);

                PlaneRepairs = new ObservableCollection<PlaneRepair>(searchResult);

            }

        }

        private PlaneRepairService _planeRepairService;
        private PlaneService _planeService;
        public ICommand OpenMainWindowCommand { get; }
        public ICommand OpenEditWindowCommand { get; }
        private readonly IWindowService _windowService;
        public ICommand FinishRepairCommand { get; }
        public PlaneRepairsViewModel(IWindowService windowService, User user)
        {
            _planeRepairService = new PlaneRepairService();
            _planeService = new PlaneService();
            this._windowService = windowService;
            LoadPlaneRepairs();
            _windowService = new WindowService();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            FinishRepairCommand = new RelayCommand(OnRepairFinish);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            DeleteWindowCommand = new RelayCommand(OnDelete);
            _userService = new UserService();
            this._user = user;
            Login = _user.Login;
            AccessRight = _user.AccessRight;
        }

        public List<PlaneRepair> SearchRepairs(string query)
        {
            return PlaneRepairs.Where(repair =>
                repair.PlaneRepairId.ToString().Contains(query) ||                        
                repair.StartDate.ToString("yyyy-MM-dd").Contains(query) ||                
                (!string.IsNullOrEmpty(repair.Status) && repair.Status.Contains(query, StringComparison.OrdinalIgnoreCase)) || 
                repair.NumberFlights.ToString().Contains(query) ||                     
                (repair.EndDate.HasValue && repair.EndDate.Value.ToString("yyyy-MM-dd").Contains(query)) || 
                (!string.IsNullOrEmpty(repair.Reason) && repair.Reason.Contains(query, StringComparison.OrdinalIgnoreCase)) || 
                (!string.IsNullOrEmpty(repair.Result) && repair.Result.Contains(query, StringComparison.OrdinalIgnoreCase)) || 
                repair.BrigadeId.ToString().Contains(query) ||                           
                repair.PlaneId.ToString().Contains(query)                                 
            ).ToList();
        }

        private void OnDelete(object parameter)
        {
            if (_userService.IfUserCanDoCrud(_user))
            {


                var planeRepair = parameter as PlaneRepair;
                if (planeRepair != null && planeRepair.Result == "завершений")
                {

                    MessageBoxResult resultOther = MessageBox.Show(
                                 "Ви точно хочете видалити інформацію про ремонт",
                                 "Видалення інформації",
                                 MessageBoxButton.YesNo,
                                 MessageBoxImage.Warning);
                    if (resultOther == MessageBoxResult.Yes)
                    {

                        _planeRepairService.DeletePlaneRepair(planeRepair.PlaneRepairId);
                        MessageBox.Show(
                                " Інформацію упішно видалено!",
                                  "Видалення інформації",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);

                        LoadPlaneRepairs();
                    }


                }
                else
                {
                    MessageBox.Show(
                                "Видалення інформації неможливе!",
                                  "Видалення інформації",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);

                }

            }






        }

        private void OnMainWindowOpen(object parameter)
        {

            _windowService.OpenWindow("MainMenuView", _user);
            _windowService.CloseWindow();

        }

        private void OnEdit(object parameter)
        {   var planeRepair = parameter as PlaneRepair;
            if (planeRepair != null)
            {
                _windowService.OpenModalWindow("ChangePlaneRepair", planeRepair);
              
            }

        }


        private void OnRepairFinish(object parameter)
        {
            if (_userService.IfUserCanDoCrud(_user))
            {
                var planeRepair = parameter as PlaneRepair;
                if (planeRepair != null && planeRepair.Status != "завершений")
                {
                    MessageBoxResult result = MessageBox.Show(
                      "Завершити ремонт?",
                      "Завершення ремонту",
                      MessageBoxButton.YesNo,
                      MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                    {
                        MessageBoxResult resultQuesion = MessageBox.Show(
                       "Результат успішний?",
                       "Так",
                       MessageBoxButton.YesNo,
                       MessageBoxImage.Warning);
                        AirPlane plane = _planeService.GetPlaneById(planeRepair.PlaneId);
                        if (resultQuesion == MessageBoxResult.Yes)
                        {
                            plane.TechCondition = "задовільний";
                            plane.TechInspectionDate = DateTime.Now;
                            planeRepair.EndDate = DateTime.Now;
                            _planeService.UpdatePlane(plane);
                            planeRepair.Status = "завершений";
                            planeRepair.Result = "успіх";
                        }
                        else
                        {
                            plane.TechCondition = "списання";
                            plane.TechInspectionDate = DateTime.Now;
                            _planeService.UpdatePlane(plane);
                            planeRepair.EndDate = DateTime.Now;
                            planeRepair.Status = "завершений";
                            planeRepair.Result = "ремонту не підлягає";
                        }
                        LoadPlaneRepairs();


                    }


                }
            }




        }
        private void LoadPlaneRepairs()
        {
            try
            {
                var planeRepairList = _planeRepairService.GetPlaneRepairsData();
                PlaneRepairs = new ObservableCollection<PlaneRepair>(planeRepairList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($": {ex.Message}");
            }
        }



    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}
}
