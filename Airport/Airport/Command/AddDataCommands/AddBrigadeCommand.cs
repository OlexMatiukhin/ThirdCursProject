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
    class AddBrigadeCommand : CommandBase
    {
        private AddBrigadeViewModel _addBrigadeViewModle;
        private BrigadeService _brigadeService;




        public AddBrigadeCommand(AddBrigadeViewModel _addBrigadeViewModle)
        {
            this._addBrigadeViewModle = _addBrigadeViewModle;
            _brigadeService = new BrigadeService();
        }
        public override void Execute(object parameter)
        {


            Brigade newBrigade = new Brigade
            {
                BrigadeId = _brigadeService.GetLastBrigadeId() + 1,
                BrigadeType = _addBrigadeViewModle.BrigadeType,
                StructureUnitId = _addBrigadeViewModle.StructureUnitId,

            };
            _brigadeService.AddBrigade(newBrigade);
        }
    }
}
