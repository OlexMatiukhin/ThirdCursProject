using Airport.Command.AddDataCommands;
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

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
 

    class AddBrigadeViewModel
    {
        private readonly StructureUnitService _structureUnitService;
        public ICommand AddBrigadeCommand { get; }
        private BrigadeService _brigadeService;
        private IWindowService _windowService;
        public AddBrigadeViewModel(IWindowService windowService)
        {
            _structureUnitService = new StructureUnitService();
            LoadData();
            CreateDictionaries();
            AddBrigadeCommand = new RelayCommand(AddBrigade, canExecute=>true);
            _brigadeService =new BrigadeService();

        }
        public ObservableCollection<StructureUnit> StructureUnits { get; set; }


        public Dictionary<int, string> StructureUnitDictionary { get; set; }


        public string _brigadeType;


        private int _structureUnitId;
    


        public string BrigadeType
        {
            get => _brigadeType;
            set
            {
                _brigadeType = value;
                OnPropertyChanged(nameof(BrigadeType));
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
        private void AddBrigade(object parameter)
        {
            Brigade newBrigade = new Brigade
            {
                BrigadeId = _brigadeService.GetLastBrigadeId() + 1,
                BrigadeType = BrigadeType,
                StructureUnitId = StructureUnitId,
                NumberWorkers = 0,
            };
            _brigadeService.AddBrigade(newBrigade);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
