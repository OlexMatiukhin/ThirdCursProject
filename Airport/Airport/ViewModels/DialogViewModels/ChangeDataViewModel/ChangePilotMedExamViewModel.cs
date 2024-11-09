using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.ChangeDataViewModel
{
    public class ChangePilotMedExamViewModel
    {
     
            private readonly WorkerService _workerSevice;
            private PilotMedExamService _pilotMedExamService;
        private PilotMedExam _pilotMedExam;
            private IWindowService _windowService;

            public ICommand ChangeMedExamCommand { get; }
           
            public ObservableCollection<Worker> Doctors { get; set; }
            public ObservableCollection<Worker> Pilots { get; set; }

            public Dictionary<ObjectId, string> DoctorsDictionary { get; set; }
            public Dictionary<ObjectId, string> PilotsDictionary { get; set; }
            

            public List<string> Result { get; set; } = new List<string>
            {
                "пройдено",
                "не пройдено",
            
            };

          
            private string _selectectedResult;
         public DateTime? _dateExamination;
            private ObjectId _selectedPilotId;
            private ObjectId? _selectedDoctorId;

        public string SelectedResult
        {
            get => _selectectedResult;
            set
            {
                _selectectedResult = value;
                OnPropertyChanged(nameof(SelectedResult));
            }
        }

       

        public ObjectId? SelectedDoctorId
        {
            get => _selectedDoctorId;
            set
            {
                _selectedDoctorId = value;
                OnPropertyChanged(nameof(SelectedDoctorId));
            }
        }
        public DateTime? DateExamination
        {
            get => _dateExamination;
            set
            {
                _dateExamination = value;
                OnPropertyChanged(nameof(DateExamination));
            }
        }




        public ChangePilotMedExamViewModel(PilotMedExam medExam, IWindowService windowService)
        {
                
                _workerSevice = new WorkerService();
                _pilotMedExamService= new PilotMedExamService();
                this._pilotMedExam = medExam;
                this._windowService= windowService;

              
                this.SelectedResult=medExam.Result;
                this.DateExamination = medExam.DateExamination;
                this.SelectedDoctorId = medExam.DoctorId;
                 ChangeMedExamCommand = new RelayCommand(ExecuteChangePilotMedExam);
                LoadData();
                CreateDictionaries();
        }

            private void ExecuteChangePilotMedExam(object parameter)
            {
               _pilotMedExam.Result = this.SelectedResult;
               _pilotMedExam.DateExamination = DateExamination;
               _pilotMedExam.DoctorId = this.SelectedDoctorId;
               _pilotMedExamService.UpdatePilotMedExam(_pilotMedExam);
            }

            private void LoadData()
            {
                var PilotsList = _workerSevice.GetWorkersByPositionName("Пілот");
                Pilots = new ObservableCollection<Worker>(PilotsList);

                var DoctorList = _workerSevice.GetWorkersByPositionName("Пілот");
                Doctors = new ObservableCollection<Worker>(DoctorList);
            }

            private void CreateDictionaries()
            {
               /* PilotsDictionary = Pilots.ToDictionary(w => w.WorkerId, w => w.ToString());
                DoctorsDictionary = Doctors.ToDictionary(w => w.WorkerId, w => w.ToString());*/
            }

            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    }
}



