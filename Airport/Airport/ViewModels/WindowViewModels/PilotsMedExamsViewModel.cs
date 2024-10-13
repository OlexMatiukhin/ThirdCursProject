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
        public PilotsMedExamsViewModel()
        {
            _pilotMedExamService = new PilotMedExamService();
            LoadPilotMedExams();
            _windowService = new WindowService();
            OpenEditWindowCommand = new RelayCommand(OnEdit);

        }

        private void OnEdit(object parameter)
        {

            var passanger = parameter as PilotMedExam;
            if (passanger != null)
            {
                _windowService.OpenWindow("ChangePilotMedExam", passanger);
                _windowService.CloseWindow();

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

