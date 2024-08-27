using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Airport.Models; 
using Airport.Services;

namespace Airport.ViewModels
{
    public class StructureUnitsViewModel
    {
        public ObservableCollection<StructureUnit> StructureUnits { get; set; }
        private StructureUnitService _structureUnitService;

        public StructureUnitsViewModel()
        {
            _structureUnitService = new StructureUnitService();
            LoadStructureUnits();
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