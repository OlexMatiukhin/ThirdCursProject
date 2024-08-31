using Airport.Models;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Airport.ViewModels.WindowViewModels
{
    public class DepartmentsViewModel
    {
        public ObservableCollection<Department> Deparments { get; set; }

        private DepartmentService _departmentService;

        public DepartmentsViewModel()
        {
            _departmentService = new DepartmentService();
            LoadFlights();
        }

        private void LoadFlights()
        {
            try
            {
                var departmentList = _departmentService.GetDepartmentsData();
                Deparments = new ObservableCollection<Department>(departmentList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}