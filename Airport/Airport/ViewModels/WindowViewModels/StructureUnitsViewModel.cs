using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;

namespace Airport.ViewModels.WindowViewModels
{
    public class StructureUnitsViewModel
    {
        public ObservableCollection<StructureUnit> StructureUnits { get; set; }
        private StructureUnitService _structureUnitService;
     

        private readonly IWindowService _windowService;
        public ICommand OpenEditWindowCommand { get; }
        public StructureUnitsViewModel(IWindowService _windowService)
        {
            _structureUnitService = new StructureUnitService();
            this._windowService= _windowService;
            LoadStructureUnits();
            _windowService = new WindowService();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
        }

        private void OnDelete(object parameter)
        {



            var structureUnit = parameter as StructureUnit;
            List<StructureUnit> positionsList = _structureUnitService.GetStructureUnitsDataByDepartmentId(structureUnit.DepartmentId);
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
                    _structureUnitService.DeleteStructureUnit(structureUnit.DepartmentId);

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
    }
}