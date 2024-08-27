using Airport.Models;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Airport.ViewModels
    {
        public class PilotsMedExamsViewModel
        {
            public ObservableCollection<PilotMedExam> PilotMedExams { get; set; }
            private PilotMedExamService _pilotMedExamService;

            public PilotsMedExamsViewModel()
            {
                _pilotMedExamService = new PilotMedExamService();
                LoadPilotMedExams();
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

