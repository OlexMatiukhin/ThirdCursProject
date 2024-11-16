using Airport.Command.AddDataCommands;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
            _windowService = windowService;
            _structureUnitService = new StructureUnitService();
            LoadData();
            CreateDictionaries();
            AddBrigadeCommand = new RelayCommand(AddBrigade, canExecute=>true);
            _brigadeService =new BrigadeService();

        }
        public ObservableCollection<StructureUnit> StructureUnits { get; set; }


        public Dictionary<string, string> StructureUnitDictionary { get; set; }


        public string _brigadeType;


        private string _structureUnitName;
    


        public string BrigadeType
        {
            get => _brigadeType;
            set
            {
                _brigadeType = value;
                OnPropertyChanged(nameof(BrigadeType));
            }
        }


        public string StructureUnitName
        {
            get => _structureUnitName;
            set
            {
                _structureUnitName = value;
                OnPropertyChanged(nameof(StructureUnitName));
            }
        }





        private void LoadData()
        {


            var StructureUnitsList = _structureUnitService.GetStructureUnitsData();

            StructureUnits = new ObservableCollection<StructureUnit>(StructureUnitsList);
        }

        private void CreateDictionaries()
        {
            StructureUnitDictionary = StructureUnits.ToDictionary(b => b.StructureUnitName.ToString(), b => b.ToString());

        }
        private void AddBrigade(object parameter)
        {


            if (string.IsNullOrEmpty(BrigadeType))
            {
                MessageBox.Show("Тип бригады не може бути пустим.");
                return;
            }

            if (string.IsNullOrEmpty(StructureUnitName))
            {
                MessageBox.Show("Оберіть назву структурного підрозділу.");
                return;
            }
            Brigade newBrigade = new Brigade
            {
           
                BrigadeType = BrigadeType,
                NumberWorkers = 0,
            };
            _brigadeService.AddBrigade(newBrigade);

            MessageBox.Show("Об'єкт уcпіiно додано!");
            _windowService.CloseModalWindow();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
