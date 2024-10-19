using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Airport.ViewModels.WindowViewModels
{  
    public class DepartmentsViewModel
    {
        public ObservableCollection<Department> Departments { get; set; }

        public ICommand OpenEditWindowCommand { get; }
        public ICommand DeleteWindowCommand { get; }

        private DepartmentService _departmentService;
        private IWindowService _windowService;
        private StructureUnitService _structureUnitService;

       public DepartmentsViewModel(IWindowService _windowService)
        {
            _departmentService = new DepartmentService();
            this._windowService= _windowService;
            _structureUnitService = new StructureUnitService();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            DeleteWindowCommand = new RelayCommand(OnDelete);
            LoadDepartments();

        }
        private void OnEdit(object parameter)
        {
            var department = parameter as Department;
            if (department != null)
            {
                _windowService.OpenModalWindow("ChangeDepartment", department);        
             

            }
             



        }

        private void OnDelete(object parameter)
        {

          

            var department = parameter as Department;
            List<StructureUnit> structureUnitList = _structureUnitService.GetStructureUnitsDataByDepartmentId(department.DepartmentId);
            if (structureUnitList.Count==0)
            {
                MessageBoxResult result = MessageBox.Show(
                  "Якщо ви натисните так, департамент назавжди буде видалено з бази!", 
                  "Ви дійсно хочете видалити департамент?",
                
                 MessageBoxButton.YesNo,
                 MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                  
                    Departments.Remove(department);
                    _departmentService.DeleteDepartment(department.DepartmentId);
                    MessageBox.Show("Департамент успішно видалено", "Успішний результат", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
               MessageBox.Show("В базі наявні структурні одиниці, що підпорядковуються даному департаменту! Видаліть, структурні одинці даного департаменту, для виконання операції видалення!", "Помилка видалення департаменту",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            }





        }
       
        private void LoadDepartments()
        {
            try
            {
                var departmentList = _departmentService.GetDepartmentsData();
                Departments = new ObservableCollection<Department>(departmentList);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}