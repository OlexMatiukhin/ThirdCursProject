using Airport.Command.AddDataCommands;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddPlaneViewModel
    {

        private readonly StructureUnitService _structureUnitService;
        private readonly PlaneService _planeService;
        public ICommand AddPlaneCommand { get; }
        public AddPlaneViewModel()
        {

            _planeService = new PlaneService();
            AddPlaneCommand = new RelayCommand(ExecuteAddPlane, canExecute=>true);


        }
        private void ExecuteAddPlane(object parameter)
        {
            var newPlane = new Plane
            {
                PlaneId = _planeService.GetLastPlaneId() + 1,
                Type = SelectedPlaneType,
                TechCondition = "задовільний",
                InteriorReadiness = "готовий",
                NumberFlightsBeforeRepair = 0,
                TechInspectionDate = DateTime.Now,
                Assigned = Assigned,
                NumberRepairs = 0,
                ExploitationDate = DateTime.Now
            };

            _planeService.AddPlane(newPlane);
        }

        


        public List<string> PlaneTypeList { get; set; } = new List<string>
        {
            "грузовий",
            "пасажирський",
           
        };

        public string _planeType;


        private bool _assigned;


        public string SelectedPlaneType
        {
            get => _planeType;
            set
            {
                _planeType = value;
                OnPropertyChanged(nameof(SelectedPlaneType));
            }
        }


        public bool Assigned
        {
            get => _assigned;
            set
            {
                _assigned = value;
                OnPropertyChanged(nameof(Assigned));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
