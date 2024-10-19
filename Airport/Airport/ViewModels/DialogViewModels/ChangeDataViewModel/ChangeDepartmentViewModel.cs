using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Command.AddDataCommands;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Airport.Services.MongoDBSevice;
using Airport.Services;

namespace Airport.ViewModels.DialogViewModels.ChangeDataViewModel
{
    public class ChangeDepartmentViewModel
    {
        
        private DepartmentService _departmentService;
        private IWindowService _windowService;

        public ICommand ChangeDepartmentCommand { get; }
        public ChangeDepartmentViewModel(Department department, IWindowService windowService)
        {
            _departmentId = department.DepartmentId;
            DepartmentName= department.DepartmentName;
            this._windowService = windowService;

            ChangeDepartmentCommand = new RelayCommand(ChangeDepartment, canExecute => true);
            _departmentService = new DepartmentService();


        }




        public int _departmentId;
        public string _departmentName;





        public string DepartmentName
        {
            get => _departmentName;
            set
            {
                _departmentName = value;
                OnPropertyChanged(nameof(DepartmentName));
            }
        }
        private void ChangeDepartment(object parameter)
        {
            Department newDepartment = new Department
            {
                DepartmentId = _departmentId,
                DepartmentName = DepartmentName,
            };
            _departmentService.UpdateDepartment(newDepartment);
        }






        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


    


        
