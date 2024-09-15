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
    public class AddPositionCommand : CommandBase
    {
        private AddPositionViewModel _addPostionViewModel;
        private PositionService _postionService;


        public AddPositionCommand(AddPositionViewModel _addPostionViewModel)
        {
            this._addPostionViewModel = _addPostionViewModel;
            _postionService = new PositionService();
        }
        public override void Execute(object parameter)
        {


            Position newPosition = new Position
            {
                PositionId = _postionService.GetLastPositionId() + 1,
                PositionName = _addPostionViewModel.PositionName,
                Salary = int.Parse(_addPostionViewModel.Salary),
                StructureUnitId = _addPostionViewModel.StructureUnitId
            };
            _postionService.AddPostion(newPosition);
        }
    }
}
