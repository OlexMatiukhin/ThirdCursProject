using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Airport.Models;
using Airport.Services;

namespace Airport.ViewModels.WindowViewModels
{
    public class WorkersViewModel
    {
        public ObservableCollection<Worker> Workers { get; set; }
        private WorkerService _workerService;

        public WorkersViewModel()
        {
            _workerService = new WorkerService();
            LoadWorkers();
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
    }
}

