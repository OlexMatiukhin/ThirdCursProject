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
using System.Windows.Input;



namespace Airport.ViewModels.WindowViewModels
{
    
    public class PilotsMedExamsViewModel
    {
        public ObservableCollection<PilotMedExam> PilotMedExams { get; set; }
        private PilotMedExamService _pilotMedExamService;
        public ICommand OpenEditWindowCommand { get; }
        private readonly IWindowService _windowService;
        public PilotsMedExamsViewModel(IWindowService windowService)
        {
            _pilotMedExamService = new PilotMedExamService();
            LoadPilotMedExams();
            this._windowService = windowService;
            _windowService = new WindowService();
            OpenEditWindowCommand = new RelayCommand(OnEdit);

        }

        private void OnEdit(object parameter)
        {

            var passanger = parameter as PilotMedExam;
            if (passanger != null)
            {
                _windowService.OpenModalWindow("ChangePilotMedExam", passanger);
            

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

