using Airport.Command.AddDataCommands;
using Airport.Models;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    class AddBrigadeViewModel
    {
        private readonly StructureUnitService _structureUnitService;
        private AddBrigadeCommand _addBrigadeCommand;
        public AddBrigadeViewModel()
        {
            _structureUnitService = new StructureUnitService();


            LoadData();
            CreateDictionaries();
            _addBrigadeCommand = new AddBrigadeCommand(this);


        }

        public AddBrigadeCommand AddBrigadeCommand
        {
            get => _addBrigadeCommand;
            set
            {
                _addBrigadeCommand = value;


            }
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
