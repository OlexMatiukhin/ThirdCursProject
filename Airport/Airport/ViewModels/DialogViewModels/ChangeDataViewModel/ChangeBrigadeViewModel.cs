using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;

namespace Airport.ViewModels.DialogViewModels.ChangeDataViewModel
{
    public class ChangeBrigadeViewModel : INotifyPropertyChanged
    {

        private readonly StructureUnitService _structureUnitService;
        public ICommand ChangeBrigadeCommand { get; }
        private BrigadeService _brigadeService;
        private IWindowService _windowService;

        public ChangeBrigadeViewModel(Brigade brigade, IWindowService windowService)
        {
            _structureUnitService = new StructureUnitService();
            LoadData();
            CreateDictionaries();
            ChangeBrigadeCommand = new RelayCommand(ChangeBrigade, canExecute => true);
            _brigadeService = new BrigadeService();
            this._brigade = brigade;
            BrigadeType = brigade.BrigadeType;
            StructureUnitName = brigade.StructureUnitName;
            

        }



       



        public ObservableCollection<StructureUnit> StructureUnits { get; set; }

        public Dictionary<string, string> StructureUnitDictionary { get; set; }

        private Brigade _brigade;

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
            StructureUnitDictionary = StructureUnits.ToDictionary(b => b.StructureUnitName, b => b.ToString());

        }


        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(BrigadeType))
            {
                MessageBox.Show("Будь ласка, виберіть тип бригади.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrEmpty(StructureUnitName))
            {
                MessageBox.Show("Будь ласка, виберіть одиницю структури.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
        private void ChangeBrigade(object parameter)
        {
            _brigade.BrigadeType = this.BrigadeType;
            _brigade.StructureUnitName = this.StructureUnitName;

            _brigadeService.UpdateBrigade(_brigade);
            MessageBox.Show("Об'єкт успішно змінено!");
            _windowService.CloseModalWindow();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
