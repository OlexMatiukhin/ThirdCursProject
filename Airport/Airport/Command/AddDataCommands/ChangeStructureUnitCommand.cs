using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.ViewModels.DialogViewModels.AddDataViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Command.AddDataCommands
{
    public class ChangeStructureUnitCommand
    {
        private AddStructureUnitViewModel _addStructureUnitViewModel;
        private StructureUnitService _structureUnitService;


        public ChangeStructureUnitCommand(AddStructureUnitViewModel addStructureUnitViewModel)
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
