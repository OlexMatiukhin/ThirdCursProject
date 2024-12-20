﻿using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Command.AddDataCommands;
using Airport.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Airport.Services.MongoDBSevice;
using Airport.Services;
using System.Windows;
using Xceed.Wpf.Toolkit;

namespace Airport.ViewModels.DialogViewModels.ChangeDataViewModel
{
    public class ChangeDepartmentViewModel
    {
        
        private DepartmentService _departmentService;
        private IWindowService _windowService;
        private Department _departement;

        public ICommand ChangeDepartmentCommand { get; }
        public ChangeDepartmentViewModel(Department department, IWindowService windowService)
        {
            this._departement = department;
            DepartmentName= department.DepartmentName;
            this._windowService = windowService;

            ChangeDepartmentCommand = new RelayCommand(ChangeDepartment, canExecute => true);
            _departmentService = new DepartmentService();


        }



        
     
        public string _departmentName;





        public string DepartmentName
        {
            get => _departmentName;
            set
            {
                _departmentName = value;
                OnPropertyChanged(nameof(DepartmentName));
            }
        }
        private void ChangeDepartment(object parameter)
        {
            if (ValidateInputs()) {

                _departement.DepartmentName = DepartmentName;
                _departmentService.UpdateDepartment(_departement);
                System.Windows.MessageBox.Show("Об'єкт успішно змінено!");
                _windowService.CloseModalWindow();
            }
           
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(DepartmentName))
            {
                System.Windows.MessageBox.Show("Будь ласка, введіть назву департаменту.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


    


        
