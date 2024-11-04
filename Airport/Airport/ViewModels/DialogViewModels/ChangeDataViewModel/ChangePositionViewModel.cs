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
            this.StructureUnitId = position.StructureUnitId;


            LoadData();
            CreateDictionaries();
            ChangePositionCommand = new RelayCommand(ExecutePostionChange, canExecute => true); }

        public ObservableCollection<StructureUnit> StructureUnits { get; set; }


        public Dictionary<int, string> StructureUnitDictionary { get; set; }


        public string _positionName;
        private string _salary;

        private int _structureUnitId;


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


        public int StructureUnitId
        {
            get => _structureUnitId;
            set
            {
                _structureUnitId = value;
                OnPropertyChanged(nameof(StructureUnitId));
            }
        }





        private void LoadData()
        {


            var StructureUnitsList = _structureUnitService.GetStructureUnitsData();

            StructureUnits = new ObservableCollection<StructureUnit>(StructureUnitsList);
        }
        private void ExecutePostionChange(object parameter)
        {

            _position.PositionName = PositionName;
            _position.Salary = int.Parse(Salary);
            _position.StructureUnitId = StructureUnitId;         

            _positionService.UpdatePostition(_position);
        }

        private void CreateDictionaries()
        {
            StructureUnitDictionary = StructureUnits.ToDictionary(b => b.StructureUnitId, b => b.ToString());

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
