using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using MongoDB.Bson;

namespace Airport.ViewModels.DialogViewModels.AdditionalViewModel
{
     class ChangePilotPositionViewModel: INotifyPropertyChanged
    {
        private readonly PilotMedExamService _pilotMedExamService;
        private readonly PilotMedExam _pilotMedExam;

        private readonly PositionService _postitionService;
        private IWindowService _windowService;
        private Worker _worker;
        private readonly WorkerService _workerService;
        public ICommand ChangePilotPositionCommand { get; }

        public ChangePilotPositionViewModel(IWindowService windowService, PilotMedExam pilotMedExam, Worker worker)
        {
            _pilotMedExamService = new PilotMedExamService();
            _postitionService = new PositionService();
            _workerService = new WorkerService();
            this._windowService = windowService;

            LoadData();
            CreateDictionaries();

            ChangePilotPositionCommand = new RelayCommand(ExecuteChangePilotPossition, canExecute => true);
        }

        private void ExecuteChangePilotPossition(object parameter)
        {

            if (_worker != null&& SelectedPostionId!=null) {
                //_worker.PositionId = SelectedPostionId;
                _pilotMedExam.Result = "не пройдений";
                _pilotMedExam.DateExamination = DateTime.Now;
                _pilotMedExam.DoctorId = null;
                _pilotMedExamService.UpdatePilotMedExam(_pilotMedExam);
                _worker.ResultMedExam = "пройдений";
                _worker.LastMedExamDate = DateTime.Now;
            }
            else
            {
               
            }
           
           

            
        }


        public ObservableCollection<Position> Positions { get; set; }
  


        public Dictionary<ObjectId, string> PositionsDictionary { get; set; }
       


       

        private ObjectId _selectedPostionId;  
       

        public ObjectId SelectedPostionId
        {
            get => _selectedPostionId;
            set
            {
                _selectedPostionId = value;
                OnPropertyChanged(nameof(SelectedPostionId));
            }
        }
       
        private void LoadData()
        {
            

            var PositionsList = _postitionService.GetPositionsData();
            Positions = new ObservableCollection<Position>(PositionsList);


        }

        private void CreateDictionaries()
        {
           
            PositionsDictionary = Positions.ToDictionary(b => b.PositionId, b => b.ToString());

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
