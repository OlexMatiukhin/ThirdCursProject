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

namespace Airport.ViewModels.DialogViewModels.ChangeDataViewModel
{
    class ChangePositionViewModel
    {
        private readonly PositionService _positionService;
        private readonly StructureUnitService _structureUnitService;
        private Position _position;
        private IWindowService _windowService;
        public ICommand ChangePositionCommand { get; }
        public ChangePositionViewModel(Position position, IWindowService windowService)
        {

            this._windowService = windowService;
            _positionService = new PositionService();
            _structureUnitService = new StructureUnitService();
            this.PositionName = position.PositionName;
            this.Salary = position.Salary.ToString();
            this.StructureUnitName = position.StructureUnitName;
            this._position = position;


            LoadData();
            CreateDictionaries();
            ChangePositionCommand = new RelayCommand(ExecutePostionChange, canExecute => true); }

        public ObservableCollection<StructureUnit> StructureUnits { get; set; }


        public Dictionary<string, string> StructureUnitDictionary { get; set; }


        public string _positionName;
        private string _salary;

        private string _structureUnitName;


        public string PositionName
        {
            get => _positionName;
            set
            {
                _positionName = value;
                OnPropertyChanged(nameof(PositionName));
            }
        }
        public string Salary
        {
            get => _salary;
            set
            {
                _salary = value;
                OnPropertyChanged(nameof(Salary));
            }
        }


        public string StructureUnitName
        {
            get => _structureUnitName;
            set
            {
                _structureUnitName = value;
                OnPropertyChanged(nameof(_structureUnitName));
            }
        }
        private bool ValidateInputs()
        {
           
            if (string.IsNullOrWhiteSpace(PositionName))
            {
                return false;
            }

          
            if (!int.TryParse(Salary, out int salary) || salary <= 0)
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(StructureUnitName) || !StructureUnitDictionary.ContainsKey(StructureUnitName))
            {
                return false;
            }

            return true;
        }





        private void LoadData()
        {


            var StructureUnitsList = _structureUnitService.GetStructureUnitsData();

            StructureUnits = new ObservableCollection<StructureUnit>(StructureUnitsList);
        }
        private void ExecutePostionChange(object parameter)
        {
            if (ValidateInputs())
            {
                _position.PositionName = PositionName;
                _position.Salary = int.Parse(Salary);


                _positionService.UpdatePostition(_position);
                System.Windows.MessageBox.Show("Об'єкт успішно змінено!");
                _windowService.CloseModalWindow();

            }
          
        }

        private void CreateDictionaries()
        {
           StructureUnitDictionary = StructureUnits.ToDictionary(b => b.StructureUnitName, b => b.ToString());

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
