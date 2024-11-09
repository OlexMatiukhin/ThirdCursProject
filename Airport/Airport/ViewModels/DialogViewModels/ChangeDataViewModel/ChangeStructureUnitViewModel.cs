using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Command.AddDataCommands;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Airport.Services;

namespace Airport.ViewModels.DialogViewModels.ChangeDataViewModel
{
    class ChangeStructureUnitViewModel
    {

 
        private readonly DepartmentService _departmentService;
        private readonly StructureUnitService _structureUnitService;
        private readonly StructureUnit _structureUnit;
        private IWindowService _windowService;
        public ICommand ChangeStructureUnitCommand { get; }




        public List<string> StructureTypeList { get; set; } = new List<string>
        {   "відділ",
            "служба",

        };

        public ObservableCollection<Department> Departments { get; set; }


        public Dictionary<string, string> DepartmentsDictionary { get; set; }




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

        private string _selectedDepartmentName;
        public string SelectedDepartmentName
        {
            get => _selectedDepartmentName;
            set
            {
                _selectedDepartmentName = value;
                OnPropertyChanged(nameof(SelectedDepartmentName));
            }
        }

        private void ExecuteAddStructureUnit(object parameter)
        {
            _structureUnit.StructureUnitName = StructureUnitName;
            _structureUnit.Type = SelectedStructureUnitType;
            _structureUnit.DepartmentName = SelectedDepartmentName;
            _structureUnitService.UpdateStructureUnit(_structureUnit);
        }


        private void LoadData()
        {
            var DepartmentsList = _departmentService.GetDepartmentsData();

            Departments = new ObservableCollection<Department>(DepartmentsList);
        }

        private void CreateDictionaries()
        {
            DepartmentsDictionary = Departments.ToDictionary(b => b.DepartmentName, b => b.ToString());
        }

        public ChangeStructureUnitViewModel(StructureUnit structureUnit, IWindowService windowService)
        {
            this._windowService = windowService;
            this._structureUnit = structureUnit;
            _departmentService = new DepartmentService();
            _structureUnitService = new StructureUnitService();
            ChangeStructureUnitCommand = new RelayCommand(ExecuteAddStructureUnit, canExecute => true);
            StructureUnitName = structureUnit.StructureUnitName;
            SelectedStructureUnitType = structureUnit.Type;
            SelectedDepartmentName = structureUnit.DepartmentName;
            LoadData();
            CreateDictionaries();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
