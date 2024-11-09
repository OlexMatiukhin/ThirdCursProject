using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.ViewModels.DialogViewModels.AddDataViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Command.AddDataCommands
{
    public class AddDepartmentCommand : CommandBase
    {
        private AddDepartmentViewModel _addDepartmentViewModel;
        private DepartmentService _departmentService;

        public AddDepartmentCommand(AddDepartmentViewModel addDepartmentViewModel)
        {
            _addDepartmentViewModel = addDepartmentViewModel;
            _departmentService = new DepartmentService();

        }

        public override void Execute(object parameter)
        {


            Department newDepartment = new Department
            {
               
                DepartmentName = _addDepartmentViewModel.DepartmentName,
            };
            _departmentService.AddDepartment(newDepartment);
        }
    }
}
