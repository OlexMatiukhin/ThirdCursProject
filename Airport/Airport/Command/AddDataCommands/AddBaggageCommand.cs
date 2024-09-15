using Airport.Models;
using Airport.Services;
using Airport.ViewModels.DialogViewModels.AddDataViewModel;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Airport.Command.AddDataCommands
{
    public class AddBaggageCommand : CommandBase
    {
        private AddBaggeViewModle _addBaggeViewModle;
        private BaggageService _baggageService;


        public AddBaggageCommand(AddBaggeViewModle _addBaggeViewModle)
        {
            this._addBaggeViewModle = _addBaggeViewModle;
            _baggageService = new BaggageService();
        }
        public override void Execute(object parameter)
        {
            int baggadeId = _baggageService.GetLastBaggeId() + 1;

            Baggage newBagge = new Baggage
            {
                BaggageId = _baggageService.GetLastBaggeId() + 1,
                BaggageType = _addBaggeViewModle.BaggeType,
                Weight = int.Parse(_addBaggeViewModle.Weight),
                Payment = int.Parse(_addBaggeViewModle.Payment),
                PassangerId = _addBaggeViewModle.SelectedPassengerId
            };
            _baggageService.AddBaggage(newBagge);
        }
    }










}






