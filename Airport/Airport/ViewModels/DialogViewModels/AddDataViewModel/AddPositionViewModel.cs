using Airport.Command.AddDataCommands;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using Airport.Views.Dialog;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddPositionViewModel : INotifyPropertyChanged
    {
        private readonly PositionService _positionService;
        private readonly StructureUnitService _structureUnitService;
        private IWindowService _windowService;
        public ICommand AddPositionComand { get; }
        public AddPositionViewModel(IWindowService windowService)
        {
             this._windowService = windowService;
            _positionService = new PositionService();
            _structureUnitService = new StructureUnitService();

            LoadData();
            CreateDictionaries();
            AddPositionComand = new RelayCommand(ExecuteAddPosition, canExecute=>true);


        }



        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(PositionName))
            {
                MessageBox.Show("Назва посади не може бути порожньою.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(Salary) || !int.TryParse(Salary, out _))
            {
                MessageBox.Show("Будь ласка, введіть коректну зарплату.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(StructureUnitName))
            {
                MessageBox.Show("Будь ласка, оберіть підрозділ.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }




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
                OnPropertyChanged(nameof(StructureUnitName));
            }
        }





        private void LoadData()
        {


            var StructureUnitsList = _structureUnitService.GetStructureUnitsData();

            StructureUnits = new ObservableCollection<StructureUnit>(StructureUnitsList);
        }
        private void ExecuteAddPosition(object parameter)
        {
            if (ValidateInputs())
            {
                var newPosition = new Position
                {
                    PositionName = PositionName,
                    Salary = int.Parse(Salary),
                    StructureUnitName = _structureUnitName

                };

                _positionService.AddPostion(newPosition);
                MessageBox.Show("Об'єкт упішно додано!");
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
