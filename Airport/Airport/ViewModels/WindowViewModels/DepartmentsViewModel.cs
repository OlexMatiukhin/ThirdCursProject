using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBService;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Airport.ViewModels.WindowViewModels
{  
    public class DepartmentsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Department> _departments;
        private readonly UserService _userService;

        private User _user;
        public ObservableCollection<Department> Departments
        {
            get => _departments;
            set
            {
                if (_departments != value)
                {
                    _departments = value;
                    OnPropertyChanged(nameof(Departments));
                }
            }
        }
        private string _login;
        private string _accessRight;


        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }


        public string AccessRight
        {
            get => _accessRight;
            set
            {
                _accessRight = value;
                OnPropertyChanged(nameof(AccessRight));
            }
        }






        private string _searchLine;

        public string SearchLine
        {
            get => _searchLine;
            set
            {

                _searchLine = value;
                SearchOperation(_searchLine);
                OnPropertyChanged(nameof(SearchLine));


            }
        }

        public void SearchOperation(string searchLine)
        {
            LoadDepartments();
            if (!string.IsNullOrEmpty(searchLine))
            {
                var searchResult = SearchDepartments(searchLine);

                Departments = new ObservableCollection<Department>(searchResult);

            }

        }

        public ICommand OpenEditWindowCommand { get; }
        public ICommand DeleteWindowCommand { get; }
        public ICommand OpenMainWindowCommand { get; }

        public ICommand OpenAddWindowCommand { get; }

        private DepartmentService _departmentService;
        private IWindowService _windowService;
        private StructureUnitService _structureUnitService;

       public DepartmentsViewModel(IWindowService _windowService, User user)
        {
            _departmentService = new DepartmentService();
            this._windowService= _windowService;
            _userService = new UserService();
            this._user = user;
            _structureUnitService = new StructureUnitService();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            DeleteWindowCommand = new RelayCommand(OnDelete);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            OpenAddWindowCommand = new RelayCommand(OnAdd);

            Login = _user.Login;
            AccessRight = _user.AccessRight;
            LoadDepartments();


        }


        public List<Department> SearchDepartments(string query)
        {
            return Departments.Where(department =>
                department.DepartmentId.ToString().Contains(query) ||
                department.DepartmentName.Contains(query, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }

        private void OnEdit(object parameter)
        {
            var department = parameter as Department;
            if (department != null)
            {
                _windowService.OpenModalWindow("ChangeDepartment", department);         

            }
        
        }
        private void OnMainWindowOpen(object parameter)
        {
            _windowService.OpenWindow("MainMenuView", _user);
            _windowService.CloseWindow();

        }
        private void OnAdd(object parameter)
        {


            if (_userService.IfUserCanDoCrud(_user))
            {

                _windowService.OpenModalWindow("AddDepartment");
            }
           


        }
        private void OnDelete(object parameter)
        {

            if (_userService.IfUserCanDoCrud(_user))
            {

                var department = parameter as Department;
                List<StructureUnit> structureUnitList = _structureUnitService.GetStructureUnitsDataByDepartmentName(department.DepartmentName);
                if (structureUnitList.Count == 0)
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
                        MessageBox.Show("Департамент успішно видалено!", "Успішний результат", MessageBoxButton.OK, MessageBoxImage.Error);
                        LoadDepartments();
                    }
                }
                else
                {
                    MessageBox.Show("В базі наявні структурні одиниці, що підпорядковуються даному департаменту! Видаліть, структурні одинці даного департаменту, для виконання операції видалення!", "Помилка видалення департаменту",
                     MessageBoxButton.OK,
                     MessageBoxImage.Error);
                }
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