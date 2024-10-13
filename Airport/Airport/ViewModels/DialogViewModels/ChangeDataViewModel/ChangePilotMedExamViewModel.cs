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

namespace Airport.ViewModels.DialogViewModels.ChangeDataViewModel
{
    public class ChangePilotMedExamViewModel
    {
     
            private readonly WorkerService _workerSevice;
            private PilotMedExamService _pilotMedExamService;
           

            public ICommand ChangeMedExamCommand { get; }
           
            public ObservableCollection<Worker> Doctors { get; set; }
            public ObservableCollection<Worker> Pilots { get; set; }

            public Dictionary<int, string> DoctorsDictionary { get; set; }
            public Dictionary<int, string> PilotsDictionary { get; set; }
            

            public List<string> Result { get; set; } = new List<string>
            {
                "пройдено",
                "не пройдено",
            
            };

            private int _id;
            private string _selectectedResult;
         public DateTime _dateExamination;
            private int _selectedPilotId;
            private int _selectedDoctorId;

        public string SelectedResult
        {
            get => _selectectedResult;
            set
            {
                _selectectedResult = value;
                OnPropertyChanged(nameof(SelectedResult));
            }
        }

        public int SelectedPilotId
        {
            get => _selectedPilotId;
            set
            {
                _selectedPilotId = value;
                OnPropertyChanged(nameof(SelectedPilotId));
            }
        }

        public int SelectedDoctorId
        {
            get => _selectedDoctorId;
            set
            {
                _selectedDoctorId = value;
                OnPropertyChanged(nameof(SelectedDoctorId));
            }
        }
        public DateTime DateExamination
        {
            get => _dateExamination;
            set
            {
                _dateExamination = value;
                OnPropertyChanged(nameof(DateExamination));
            }
        }




        public ChangePilotMedExamViewModel(PilotMedExam medExam)
        {
                
                _workerSevice = new WorkerService();
                _pilotMedExamService= new PilotMedExamService();

                this._id=medExam.ExamId;
                this.SelectedResult=medExam.Result;
                this.SelectedPilotId = medExam.PilotId;
                this.DateExamination = medExam.DateExamination;
                this.SelectedDoctorId = medExam.DoctorId;
                 ChangeMedExamCommand = new RelayCommand(ExecuteChangePilotMedExam);
                LoadData();
                CreateDictionaries();
        }

            private void ExecuteChangePilotMedExam(object parameter) {
            PilotMedExam pilotMedExam = new PilotMedExam
            {
                ExamId = _id,
                Result = this.SelectedResult,
                DateExamination = DateExamination,
                PilotId = this.SelectedPilotId,
                DoctorId = this.SelectedDoctorId
            };
            _pilotMedExamService.UpdatePilotMedExam(pilotMedExam);






            }

            private void LoadData()
            {
                var PilotsList = _workerSevice.GetWorkersByPositionId(62);
                Pilots = new ObservableCollection<Worker>(PilotsList);

                var DoctorList = _workerSevice.GetWorkersByPositionId(81);
                Doctors = new ObservableCollection<Worker>(DoctorList);
            }

            private void CreateDictionaries()
            {
                PilotsDictionary = Pilots.ToDictionary(w => w.WorkerId, w => w.ToString());
                DoctorsDictionary = Doctors.ToDictionary(w => w.WorkerId, w => w.ToString());

        }

            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    }
}



