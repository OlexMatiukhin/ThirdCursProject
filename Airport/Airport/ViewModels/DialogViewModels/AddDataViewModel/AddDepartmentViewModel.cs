using Airport.Command.AddDataCommands;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddDepartmentViewModel
    {


        private AddDepartmentCommand _addDepartmentCommand;
        private DepartmentService _departmentService;
        private IWindowService _windowService;
        public ICommand AddDepartmentCommand { get; }
        public AddDepartmentViewModel(IWindowService windowService)
        {
            this._windowService = windowService;
            _addDepartmentCommand = new AddDepartmentCommand(this);
            AddDepartmentCommand = new RelayCommand(AddDepartment, canExecute => true);
            _departmentService = new DepartmentService();


        }
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
        private void AddDepartment(object parameter)
        {
            Department newDepartment = new Department
            {
                DepartmentName = DepartmentName,
            };
            _departmentService.AddDepartment(newDepartment);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
