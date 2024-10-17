using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.ChangeDataViewModel
{
    class ChangePlaneViewModel
    {
        private readonly StructureUnitService _structureUnitService;
        private readonly PlaneService _planeService;

        public ICommand ChnagePassangerCommand { get; }
        public ChangePlaneViewModel(Models.Plane plane)
        {
            this._id = plane.PlaneId;
            _type = plane.Type;
            _techCondition = plane.TechCondition;
            _interiorReadiness = plane.InteriorReadiness;
            NumberFlightsBeforeRepair = plane.NumberFlightsBeforeRepair;
            TechInspectionDate = plane.TechInspectionDate;
            Assigned = plane.Assigned;
            NumberRepairs = plane.NumberRepairs;
            ExploitationDate = plane.ExploitationDate;
            _planeService = new PlaneService();
            ChnagePassangerCommand = new RelayCommand(ExecuteChangePlane, canExecute => true);    
        }
       




        public List<string> PlaneTypeList { get; set; } = new List<string>
        {
            "грузовий",
            "пасажирський",

        };
     
       
        private int _id;
        private string _type;
        private string _techCondition;
        private string _interiorReadiness;
        private int _numberFlightsBeforeRepair;
        private DateTime _techInspectionDate;
        private bool _assigned;
        private int _numberRepairs;
        private DateTime _exploitationDate;
      
       


       /* public string SelectedTechCondition
        {
            get => _techCondition;
            set
            {
                _techCondition = value;
                OnPropertyChanged(nameof(TechCondition));
            }
        }


        public string SelectedInteriorReadiness
        {
            get => _interiorReadiness;
            set
            {
                _interiorReadiness = value;
                OnPropertyChanged(nameof(InteriorReadiness));
            }
        }*/


        public int NumberFlightsBeforeRepair
        {
            get => _numberFlightsBeforeRepair;
            set
            {
                _numberFlightsBeforeRepair = value;
                OnPropertyChanged(nameof(NumberFlightsBeforeRepair));
            }
        }


        public DateTime TechInspectionDate
        {
            get => _techInspectionDate;
            set
            {
                _techInspectionDate = value;
                OnPropertyChanged(nameof(TechInspectionDate));
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

        
        public int NumberRepairs
        {
            get => _numberRepairs;
            set
            {
                _numberRepairs = value;
                OnPropertyChanged(nameof(NumberRepairs));
            }
        }


        public DateTime ExploitationDate
        {
            get => _exploitationDate;
            set
            {
                _exploitationDate = value;
                OnPropertyChanged(nameof(ExploitationDate));
            }
        }
        private void ExecuteChangePlane(object parameter)
        {
            var newPlane = new Models.Plane
            {
                PlaneId = _id,
                Type = _type,
                TechCondition = _techCondition,
                InteriorReadiness = _interiorReadiness,
                NumberFlightsBeforeRepair = NumberFlightsBeforeRepair,
                TechInspectionDate = TechInspectionDate,
                Assigned = Assigned,
                NumberRepairs = NumberRepairs,
                ExploitationDate = ExploitationDate,

            };

            _planeService.UpdatePlane(newPlane);
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}

