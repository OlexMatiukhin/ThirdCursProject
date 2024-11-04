using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System.ComponentModel;
using System.Numerics;
using System.Windows.Input;



namespace Airport.ViewModels.DialogViewModels.ChangeDataViewModel
{
    class ChangePlaneViewModel
    {
        private readonly StructureUnitService _structureUnitService;
        private readonly PlaneService _planeService;
        private IWindowService _windowService;
        private AirPlane _plane;
        public ICommand ChnagePassangerCommand { get; }
        public ChangePlaneViewModel(AirPlane plane, IWindowService windowService)
        {
            this._windowService = windowService;
            this._plane = plane;
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
     
       
       
        private string _type;
        private string _techCondition;
        private bool _assigned;
        private int _numberRepairs;
        private DateTime _exploitationDate;
      
       


      

        


        

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
            _plane.TechCondition = _techCondition;
            _plane.Assigned = Assigned;
            _plane.NumberRepairs = NumberRepairs;
            _plane.ExploitationDate = ExploitationDate;

            

            _planeService.UpdatePlane(_plane);
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}

