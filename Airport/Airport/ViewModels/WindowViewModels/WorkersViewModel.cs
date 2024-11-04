using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.Services;
using System.Windows.Input;
using Airport.Command.AddDataCommands.Airport.Commands;
using System.Reflection.Metadata;
using System.Windows;

namespace Airport.ViewModels.WindowViewModels
{
    public class WorkersViewModel
    {        
        public ObservableCollection<Worker> Workers { get; set; }
        private WorkerService _workerService;
        private BrigadeService _briagadeService;
        private PilotMedExamService _pilotMedExamService;
        public ICommand OpenEditWindowCommand { get; }
        private readonly IWindowService _windowService;

        public ICommand SendPilotToMedExam { get; }
   

        public WorkersViewModel( IWindowService windowService)
        {
            _workerService = new WorkerService();
            LoadWorkers();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            this._windowService =windowService;
            _briagadeService = new BrigadeService();
            _pilotMedExamService = new PilotMedExamService();
        }
        private void OnEdit(object parameter)
        {

            var worker = parameter as Worker;
            if (worker != null)
            {
                _windowService.OpenModalWindow("ChangeWorker", worker);
                _windowService.CloseWindow();
            }
        }

        private void OnSendPilotToMedExam(object parameter) {
            var worker = parameter as Worker;
            if (worker != null&& worker.PositionId==62)
            {
                MessageBoxResult result = MessageBox.Show(
                           "Відправити пілота на медогляд?",
                           "",
                           MessageBoxButton.YesNo,
                           MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes) {
                    _pilotMedExamService.AddPilotMedExamForWorker(worker);
                }

            }
            else
            {
                Console.WriteLine("Данна функція доступна лише для пілотів");
            }

        }
        private void LoadWorkers()
        {
            try
            {
                var workerList = _workerService.GetWorkersData();
                Workers = new ObservableCollection<Worker>(workerList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        private void OnDeleteFromBrigade(object parameter)
        {
            var worker = parameter as Worker;
            if (worker != null)
            {
                _workerService.DeleteBrigadeFromWorker(worker.WorkerId);

            }
        }
    }
}

