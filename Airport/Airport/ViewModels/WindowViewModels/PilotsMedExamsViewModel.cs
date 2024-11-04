using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;



namespace Airport.ViewModels.WindowViewModels
{
    
    public class PilotsMedExamsViewModel
    {
        public ObservableCollection<PilotMedExam> PilotMedExams { get; set; }
        private PilotMedExamService _pilotMedExamService;
    
        private readonly IWindowService _windowService;
        private ICommand EndExamCommand;
        private Worker _worker;
        private WorkerService _workerService;
        public PilotsMedExamsViewModel(IWindowService windowService)
        {
            _pilotMedExamService = new PilotMedExamService();
            LoadPilotMedExams();
            this._windowService = windowService;
            _workerService = new WorkerService();
            EndExamCommand = new RelayCommand(OnEndExam);
            _windowService = new WindowService();
          

        }

        private void OnEndExam(object parameter)
        {

            var pilotMedExam = parameter as PilotMedExam;
            if (pilotMedExam != null)
            {
                MessageBoxResult result = MessageBox.Show(
                       "Стан здоров`я задовільний?",
                       "",
                       MessageBoxButton.YesNo,
                       MessageBoxImage.Question);
                _worker = _workerService.GetWorkerById(pilotMedExam.PilotId);
                if (result == MessageBoxResult.Yes)
                {
                    pilotMedExam.Result = "пройдений";
                    pilotMedExam.DateExamination = DateTime.Now;
                    pilotMedExam.DoctorId = 0;
                    _pilotMedExamService.UpdatePilotMedExam(pilotMedExam);
                    _worker.ResultMedExam = "задовільний";
                    _worker.LastMedExamDate = DateTime.Now;
                }
                else
                {
                    _windowService.OpenModalWindow("ChangePilotPositionViewModel", pilotMedExam, _worker);
                }



            }




        }

        private void LoadPilotMedExams()
        {
            try
            {
                var pilotMedExamList = _pilotMedExamService.GetPilotMedExamsData();
                PilotMedExams = new ObservableCollection<PilotMedExam>(pilotMedExamList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }

}

