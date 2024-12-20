﻿using Airport.Command.AddDataCommands;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddPlaneViewModel
    {

        private readonly StructureUnitService _structureUnitService;
        private readonly PlaneService _planeService;
        public ICommand AddPlaneCommand { get; }
        private IWindowService _windowService;
        public AddPlaneViewModel(IWindowService windowService)
        {
            this._windowService = windowService;
            _planeService = new PlaneService();
            AddPlaneCommand = new RelayCommand(ExecuteAddPlane, canExecute=>true);


        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(PlaneNumber))
            {
                MessageBox.Show("Номер літака не може бути порожнім.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(SelectedPlaneType))
            {
                MessageBox.Show("Будь ласка, оберіть тип літака.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }
        private void ExecuteAddPlane(object parameter)
        {
            if (ValidateInputs())
            {
                var newPlane = new AirPlane
                {
                    PlaneNumber = this.PlaneNumber,
                    Type = SelectedPlaneType,
                    TechCondition = "задовільний",
                    InteriorReadiness = "готовий",

                    NumberFlightsBeforeRepair = 0,
                    TechInspectionDate = DateTime.Now,
                    Assigned = Assigned,
                    NumberRepairs = 0,
                    ExploitationDate = DateTime.Now,
                    PlaneFuelStatus = "не заправлений"
                };

                _planeService.AddPlane(newPlane);
                MessageBox.Show("Об'єкт упішно додано!");
                _windowService.CloseModalWindow();
            }
          
        }

        


        public List<string> PlaneTypeList { get; set; } = new List<string>
        {
            "грузовий",
            "пасажирський",
           
        };

        public string _planeType;
        public string _planeNumber;


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

        public string PlaneNumber
        {
            get => _planeNumber;
            set
            {
                _planeNumber = value;
                OnPropertyChanged(nameof(PlaneNumber));
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
