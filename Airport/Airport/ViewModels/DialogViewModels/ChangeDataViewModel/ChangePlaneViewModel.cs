using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System.ComponentModel;
using System.Numerics;
using System.Windows;
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
               
            PlaneNumber = plane.PlaneNumber;
            _planeService = new PlaneService();
            ChnagePassangerCommand = new RelayCommand(ExecuteChangePlane, canExecute => true);    
        }
       




        public List<string> PlaneTypeList { get; set; } = new List<string>
        {
            "грузовий",
            "пасажирський",

        };
     
       
       
        private string _type;
          private bool _assigned;
     
        private string _planeNumber;
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

        
      
      
      
        public string PlaneNumber
        {
            get => _planeNumber;
            set
            {
                _planeNumber = value;
                OnPropertyChanged(nameof(PlaneNumber));
            }

        }
        private bool ValidateInputs()
        {
            
            if (string.IsNullOrEmpty(PlaneNumber))
            {
                MessageBox.Show("Будь ласка, введіть номер літака.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

      
           

            return true; 
        }


        private void ExecuteChangePlane(object parameter)
        {
         if(ValidateInputs())
         {
                _plane.Assigned = Assigned;
                _plane.PlaneNumber = PlaneNumber;

                _planeService.UpdatePlane(_plane);
                System.Windows.MessageBox.Show("Об'єкт успішно змінено!");
                _windowService.CloseModalWindow();

            }
            

            

           
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}

