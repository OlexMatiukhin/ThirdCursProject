using Airport.Command.AddDataCommands;
using Airport.Models;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddDepartmentViewModel
    {


        private AddDepartmentCommand _addDepartmentCommand;
        public AddDepartmentViewModel()
        {

            _addDepartmentCommand = new AddDepartmentCommand(this);


        }

        public AddDepartmentCommand AddDepartmentCommand
        {
            get => _addDepartmentCommand;
            set
            {
                _addDepartmentCommand = value;


            }
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






        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
