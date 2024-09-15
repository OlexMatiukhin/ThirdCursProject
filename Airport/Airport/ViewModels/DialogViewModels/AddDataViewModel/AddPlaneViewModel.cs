using Airport.Command.AddDataCommands;
using Airport.Models;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddPlaneViewModel
    {

        private readonly StructureUnitService _structureUnitService;
        private AddPlaneCommand _addPlaneCommand;
        public AddPlaneViewModel()
        {

            _addPlaneCommand = new AddPlaneCommand(this);


        }

        public AddPlaneCommand AddPlaneCommand
        {
            get => _addPlaneCommand;
            set
            {
                _addPlaneCommand = value;


            }
        }


        public List<string> PlaneTypeList { get; set; } = new List<string>
        {
            "Грузовий",
            "Пасажирський",
           
        };






        public string _planeType;


        private bool _assigned;


        public string SelectedPlaneType
        {
            get => _planeType;
            set
            {
                _planeType = value;
                OnPropertyChanged(nameof(SelectedPlaneType));
            }
        }


        public bool Assigned
        {
            get => _assigned;
            set
            {
                _assigned = value;
                OnPropertyChanged(nameof(Assigned));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
