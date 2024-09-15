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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Airport.Command.AddDataCommands
{
    public class AddWorkerCommand : CommandBase
    {
        private AddWorkerViewModel _addWorkerViewModel;
        private WorkerService _workerService;

        public AddWorkerCommand(AddWorkerViewModel _addWorkerViewModel)
        {
            this._addWorkerViewModel = _addWorkerViewModel;
            _workerService = new WorkerService();


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
