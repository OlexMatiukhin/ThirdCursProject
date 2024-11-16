using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using Airport.ViewModels.DialogViewModels.AddDataViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Airport.Command.AddDataCommands
{
    public class AddStructureUnitViewModel
    {
        private IWindowService _windowService;
        private ChangeStructureUnitCommand _addStructureUnitCommand;
        private readonly DepartmentService _departmentService;
        private readonly StructureUnitService _structureUnitService;
        public ICommand AddStructureUnitCommand { get; }


        

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

        private bool ValidateInputs()
        {
         
            if (string.IsNullOrWhiteSpace(StructureUnitName))
            {
                MessageBox.Show("Назва структурного підрозділу не може бути порожньою.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(SelectedStructureUnitType))
            {
                MessageBox.Show("Оберіть тип структурного підрозділу.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrWhiteSpace(SelectedDepartmentName))
            {
                MessageBox.Show("Оберіть відділ для структурного підрозділу.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

          
            return true;
        }

        private void ExecuteAddStructureUnit(object parameter)
        {
            if (ValidateInputs())
            {
                var newStructureUnit = new StructureUnit
                {
                    StructureUnitName = StructureUnitName,
                    Type = SelectedStructureUnitType,
                    DepartmentName = SelectedDepartmentName
                };

                _structureUnitService.AddStructureUnit(newStructureUnit);
                MessageBox.Show("Об'єкт упішно додано!");
                _windowService.CloseModalWindow();
            }
         
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

        public AddStructureUnitViewModel(IWindowService windowService)
        {

            _departmentService = new DepartmentService();
            this._windowService = windowService;
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
