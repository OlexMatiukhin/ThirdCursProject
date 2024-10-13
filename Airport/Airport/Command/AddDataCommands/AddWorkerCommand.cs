using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.ViewModels.DialogViewModels.AddDataViewModel;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace Airport.Command.AddDataCommands
//{
/*    public class AddWorkerCommand : CommandBase
    {
        private AddWorkerViewModel _addWorkerViewModel;
      
        private readonly WorkerService _workerService;

        // Command for adding a worker
        public ICommand AddWorkerCommand { get; }

        public AddWorkerViewModel()
        {
            _workerService = new WorkerService();
            AddWorkerCommand = new RelayCommand(ExecuteAddWorker, CanExecuteAddWorker);
        }

        private void ExecuteAddWorker(object parameter)
        {
            Worker worker = new Worker
            {
                WorkerId = _workerService.GetLastWorkerId() + 1,
                FullName = FullName,
                Age = int.Parse(Age),
                Status = SelectedStatus,
                Gender = SelectedGender,
                NumberChildrens = int.Parse(NumberChildren),
                HireDate = DateTime.Now,
                Shift = SelectedShift,
                Email = Email,
                PhoneNumber = PhoneNumber,
                BrigadeId = SelectedBrigadeId,
                PositionId = SelectedPostionId
            };

            _workerService.AddWorker(worker);
        }




        public override void Execute(object parameter)
        {
            int workerId = _workerService.GetLastWorkerId() + 1;



            Worker worker = new Worker
            {
                WorkerId = _workerService.GetLastWorkerId() + 1,


                FullName = _addWorkerViewModel.FullName,


                Age = int.Parse(_addWorkerViewModel.Age),


                Status = _addWorkerViewModel.SelectedStatus,

                Gender = _addWorkerViewModel.SelectedGender,

                NumberChildrens = int.Parse(_addWorkerViewModel.NumberChildren),

                HireDate = DateTime.Now,

                Shift = _addWorkerViewModel.SelectedShift,

                Email = _addWorkerViewModel.Email,
                PhoneNumber = _addWorkerViewModel.PhoneNumber,
                BrigadeId = _addWorkerViewModel.SelectedBrigadeId,
                PositionId = _addWorkerViewModel.SelectedPostionId

            };
            _workerService.AddWorker(worker);
        }


    };









}
*/