using Airport.Command.AddDataCommands;
using Airport.Models;
using Airport.Services;
using Airport.Views.Dialog;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddPositionViewModel : INotifyPropertyChanged
    {
        private readonly StructureUnitService _structureUnitService;
        private AddPositionCommand _addPositionCommand;
        public AddPositionViewModel()
        {
            _structureUnitService = new StructureUnitService();


            LoadData();
            CreateDictionaries();
            _addPositionCommand = new AddPositionCommand(this);


        }

        public AddPositionCommand AddPositionCommand
        {
            get => _addPositionCommand;
            set
            {
                _addPositionCommand = value;


            }
        }



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
