using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.ViewModels.DialogViewModels.AddDataViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Airport.Command.AddDataCommands
{
    public class AddStructureUnitViewModel
    {

        private ChangeStructureUnitCommand _addStructureUnitCommand;
        private readonly DepartmentService _departmentService;
        private readonly StructureUnitService _structureUnitService;
        public ICommand AddStructureUnitCommand { get; }




        public List<string> StructureTypeList { get; set; } = new List<string>
        {   "відділ",
            "служба",
            
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

        private void ExecuteAddStructureUnit(object parameter)
        {
            var newStructureUnit = new StructureUnit
            {
                StructureUnitId = _structureUnitService.GetLastStructureUnitd() + 1,
                StructureUnitName = StructureUnitName,
                Type = SelectedStructureUnitType,
                DepartmentId = int.Parse(SelectedDepartmentId)
            };

            _structureUnitService.AddStructureUnit(newStructureUnit);
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
            _structureUnitService = new StructureUnitService();
            AddStructureUnitCommand = new RelayCommand(ExecuteAddStructureUnit, canExecute=>true);

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
