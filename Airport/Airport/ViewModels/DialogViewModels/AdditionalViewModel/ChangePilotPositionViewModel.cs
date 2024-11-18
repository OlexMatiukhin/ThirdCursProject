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
using System.Windows;

namespace Airport.ViewModels.DialogViewModels.AdditionalViewModel
{
     class ChangePilotPositionViewModel: INotifyPropertyChanged
    {
        private readonly PilotMedExamService _pilotMedExamService;
        private readonly PilotMedExam _pilotMedExam;
        private BrigadeService _brigadeService;

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
            _pilotMedExam = pilotMedExam;
            _worker = worker;
            this._windowService = windowService;

            LoadData();
            CreateDictionaries();

            ChangePilotPositionCommand = new RelayCommand(ExecuteChangePilotPossition, canExecute => true);
        }

        private void ExecuteChangePilotPossition(object parameter)
        {

            if (_worker != null&& SelectedPostionName!=null) {
                _worker.PositionName = SelectedPostionName;
                _pilotMedExam.Result = "пройдений";
                _pilotMedExam.DateExamination = DateTime.Now;
                _pilotMedExam.DoctorId = null;


                if (_worker.BrigadeId.HasValue&& _worker.BrigadeId.Value!=null && _worker.BrigadeId.Value != ObjectId.Empty)
                {
                    ObjectId brigadeId = _worker.BrigadeId.Value; 
                    var brigade = _brigadeService.GetBrigadeById(brigadeId);
                    _brigadeService.DeleteWorkerFromBrigade(brigadeId);
                    _worker.BrigadeId = null;

                }
           

                _pilotMedExamService.UpdatePilotMedExam(_pilotMedExam);
                _workerService.UpdateWorker(_worker);
                MessageBox.Show("Посаду змінено!");
                _windowService.CloseModalWindow();
                //_worker.ResultMedExam = "пройдений";
                //_worker.LastMedExamDate = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Оберіть нову посаду");               
            }
           
           

            
        }


        public ObservableCollection<Position> Positions { get; set; }
  


        public Dictionary<string, string> PositionsDictionary { get; set; }
       


       

        private string _selectedPostionName;  
       

        public string SelectedPostionName
        {
            get => _selectedPostionName;
            set
            {
                _selectedPostionName = value;
                OnPropertyChanged(nameof(SelectedPostionName));
            }
        }
       
        private void LoadData()
        {
            

            var PositionsList = _postitionService.GetPositionsData();
            Positions = new ObservableCollection<Position>(PositionsList);


        }

        private void CreateDictionaries()
        {
           
            PositionsDictionary = Positions.ToDictionary(b => b.PositionName, b => b.ToString());

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
