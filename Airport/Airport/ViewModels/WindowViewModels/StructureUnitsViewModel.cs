using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;

namespace Airport.ViewModels.WindowViewModels
{
    public class StructureUnitsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<StructureUnit> _structureUnits;
        public ICommand DeleteWindowCommand { get; }

        public ObservableCollection<StructureUnit> StructureUnits
        {
            get => _structureUnits;
            set
            {
                if (_structureUnits != value)
                {
                    _structureUnits = value;
                    OnPropertyChanged(nameof(StructureUnits));
                }
            }
        }

        private string _searchLine;




        public string SearchLine
        {
            get => _searchLine;
            set
            {

                _searchLine = value;
                SearchOperation(_searchLine);
                OnPropertyChanged(nameof(SearchLine));


            }
        }

        public void SearchOperation(string searchLine)
        {
            LoadStructureUnits();
            if (!string.IsNullOrEmpty(searchLine))
            {
                var searchResult = SearchStructureUnits(searchLine);

                StructureUnits = new ObservableCollection<StructureUnit>(searchResult);

            }

        }





        private StructureUnitService _structureUnitService;

        public ICommand OpenMainWindowCommand { get; }
        private readonly IWindowService _windowService;
        public ICommand OpenEditWindowCommand { get; }
        public ICommand OpenAddWindowCommand { get; }
        public StructureUnitsViewModel(IWindowService _windowService)
        {
            _structureUnitService = new StructureUnitService();
            this._windowService= _windowService;
            LoadStructureUnits();
            _windowService = new WindowService();
            OpenAddWindowCommand = new RelayCommand(OnAdd);
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            DeleteWindowCommand = new RelayCommand(OnDelete);
        }


        private void OnAdd(object parameter)
        {
            _windowService.OpenModalWindow("AddStructureUnit");



        }
        public List<StructureUnit> SearchStructureUnits(string query)
        {
            return StructureUnits.Where(unit =>
                unit.StructureUnitId.ToString().Contains(query) ||                           // Поиск по StructureUnitId
                (!string.IsNullOrEmpty(unit.DepartmentName) && unit.DepartmentName.Contains(query, StringComparison.OrdinalIgnoreCase)) || // Поиск по DepartmentName
                (!string.IsNullOrEmpty(unit.StructureUnitName) && unit.StructureUnitName.Contains(query, StringComparison.OrdinalIgnoreCase)) || // Поиск по StructureUnitName
                (!string.IsNullOrEmpty(unit.Type) && unit.Type.Contains(query, StringComparison.OrdinalIgnoreCase)) // Поиск по Type
            ).ToList();
        }

        private void OnMainWindowOpen(object parameter)
        {

            _windowService.OpenWindow("MainMenuView");
            _windowService.CloseWindow();

        }

        private void OnDelete(object parameter)
        {



            var structureUnit = parameter as StructureUnit;
            List<StructureUnit> positionsList = _structureUnitService.GetStructureUnitsDataByDepartmentName(structureUnit.DepartmentName);
            if (positionsList.Count == 0)
            {
                MessageBoxResult result = MessageBox.Show(
                  "Якщо ви натисните так, cтруктурну одиницю назавжди буде видалено з бази!",
                  "Ви дійсно хочете видалити cтруктурну одиницю?",

                 MessageBoxButton.YesNo,
                 MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {

                    StructureUnits.Remove(structureUnit);
                    _structureUnitService.DeleteStructureUnit(structureUnit.StructureUnitId);

                    MessageBox.Show("Стуркутрну одиницю успішно видалено", "Успішний результат", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("В базі наявні посади , що підпорядковуються даному департаменту! Видаліть, посади даної структурної одиниці, для виконання операції видалення!", "Помилка видалення департаменту",
                 MessageBoxButton.OK,
                 MessageBoxImage.Error);
            }





        }

        private void OnEdit(object parameter)
        {

            var position = parameter as StructureUnit;
            if (position != null)
            {
                _windowService.OpenModalWindow("ChangeStructureUnit", parameter);
             

            }




        }
        private void LoadStructureUnits()
        {
            try
            {
                var structureUnitList = _structureUnitService.GetStructureUnitsData();
                StructureUnits = new ObservableCollection<StructureUnit>(structureUnitList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}