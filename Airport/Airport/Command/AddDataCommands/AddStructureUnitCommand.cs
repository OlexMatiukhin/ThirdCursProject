using Airport.Models;
using Airport.Services;
using Airport.ViewModels.DialogViewModels.AddDataViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Command.AddDataCommands
{
    public class AddStructureUnitCommand
    {
        private AddStructureUnitViewModel _addStructureUnitViewModel;
        private StructureUnitService _structureUnitService;


        public AddStructureUnitCommand(AddStructureUnitViewModel addStructureUnitViewModel)
        {
            this._addStructureUnitViewModel = addStructureUnitViewModel;
            _structureUnitService = new StructureUnitService();
        }
       /* public override void Execute(object parameter)
        {

            StructureUnit newStructureUnit = new StructureUnit
            {
              

            };
            _structureUnitService.AddStructureUnit(newStructureUnit);
        }*/
    }
}
