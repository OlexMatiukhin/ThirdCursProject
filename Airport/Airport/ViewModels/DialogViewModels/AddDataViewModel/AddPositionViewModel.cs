using Airport.Command.AddDataCommands;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.Views.Dialog;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddPositionViewModel : INotifyPropertyChanged
    {
        private readonly PositionService _positionService;
        private readonly StructureUnitService _structureUnitService;
        public ICommand AddPositionCommand { get; }
        public AddPositionViewModel()
        {
    

            _positionService = new PositionService();
            _structureUnitService = new StructureUnitService();

            LoadData();
            CreateDictionaries();
            AddPositionCommand = new RelayCommand(ExecuteAddPosition, canExecute=>true);


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
        private void ExecuteAddPosition(object parameter)
        {
            var newPosition = new Position
            {
                PositionId = _positionService.GetLastPositionId() + 1,
                PositionName = PositionName,
                Salary = int.Parse(Salary),
                StructureUnitId = StructureUnitId
            };

            _positionService.AddPostion(newPosition);
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
