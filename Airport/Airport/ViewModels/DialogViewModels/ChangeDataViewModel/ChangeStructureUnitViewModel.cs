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
using System.Windows;

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
        private bool ValidateInputs()
        {
            
            if (string.IsNullOrWhiteSpace(StructureUnitName))
            {
                MessageBox.Show("Назва структурного підрозділу не може бути порожньою.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

           
            if (string.IsNullOrWhiteSpace(SelectedStructureUnitType) || !StructureTypeList.Contains(SelectedStructureUnitType))
            {
                MessageBox.Show("Тип структурного підрозділу не вибрано або неправильний вибір.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

          
            if (string.IsNullOrWhiteSpace(SelectedDepartmentName))
            {
                MessageBox.Show("Виберіть департамент для структурного підрозділу.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        public ChangeStructureUnitViewModel(StructureUnit structureUnit, IWindowService windowService)
        {
            if (ValidateInputs())
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
                System.Windows.MessageBox.Show("Об'єкт успішно змінено!");
                _windowService.CloseModalWindow();
            }
           
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
