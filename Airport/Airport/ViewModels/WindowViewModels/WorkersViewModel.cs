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

namespace Airport.ViewModels.WindowViewModels
{
    public class WorkersViewModel
    {
        public ObservableCollection<Worker> Workers { get; set; }
        private WorkerService _workerService;
        private BrigadeService _briagadeService;
        public ICommand OpenEditWindowCommand { get; }
        private readonly IWindowService _windowService;
        public WorkersViewModel()
        {
            _workerService = new WorkerService();
            LoadWorkers();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            _windowService = new WindowService();
            _briagadeService = new BrigadeService();
        }
        private void OnEdit(object parameter)
        {

            var worker = parameter as Worker;
            if (worker != null)
            {
                _windowService.OpenWindow("ChangeWorker", worker);
                _windowService.CloseWindow();

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

