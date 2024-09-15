using Airport.Models;
using Airport.Services;
using Airport.ViewModels.DialogViewModels.AddDataViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Command.AddDataCommands
{
    public class AddStructureUnitViewModel
    {

        private AddStructureUnitCommand _addStructureUnitCommand;
        private readonly DepartmentService _departmentService;
        


        public AddStructureUnitCommand AddStructureUnitCommand
        {
            get => _addStructureUnitCommand;
            set
            {
                _addStructureUnitCommand = value;


            }
        }
        public List<string> StructureTypeList { get; set; } = new List<string>
        {   "Відділ",
            "Служба",
            
        };
    
        public ObservableCollection<Department> Departments { get; set; }


        public Dictionary<int, string> DepartmentsDictionary { get; set; }





        private string _structureUnitName;
        public string StructureUnitName
        {
            get => _structureUnitName;
            set
            {
                _structureUnitName = value;
                OnPropertyChanged(nameof(StructureUnitName));
            }
        }

        private string _selectedStructureUnitType;
        public string SelectedStructureUnitType
        {
            get => _selectedStructureUnitType;
            set
            {
                _selectedStructureUnitType = value;
                OnPropertyChanged(nameof(SelectedStructureUnitType));
            }
        }

        private string _selectedDepartmentId;
        public string SelectedDepartmentId
        {
            get => _selectedDepartmentId;
            set
            {
                _selectedDepartmentId = value;
                OnPropertyChanged(nameof(SelectedDepartmentId));
            }
        }



        private void LoadData()
        {
            var DepartmentsList = _departmentService.GetDepartmentsData();

            Departments = new ObservableCollection<Department>(DepartmentsList);
        }

        private void CreateDictionaries()
        {
            DepartmentsDictionary = Departments.ToDictionary(b => b.DepartmentId, b => b.ToString());

        }

        public AddStructureUnitViewModel()
        {

            _departmentService = new DepartmentService();


            LoadData();
            CreateDictionaries();
            _addStructureUnitCommand = new AddStructureUnitCommand(this);
        }




        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
