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

  
    public class PositionsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Position> _positions;
        private readonly UserService _userService;


        public ObservableCollection<Position> Positions
        {
            get => _positions;
            set
            {
                if (_positions != value)
                {
                    _positions = value;
                    OnPropertyChanged(nameof(Positions));
                }
            }
        }

        private PositionService _positionService;
        private WorkerService _workerService;

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
            LoadPositions();
            if (!string.IsNullOrEmpty(searchLine))
            {
                var searchResult = SearchPositions(searchLine);

                Positions = new ObservableCollection<Position>(searchResult);

            }

        }
        private User _user;

        public ICommand OpenMainWindowCommand { get; }
        private readonly IWindowService _windowService;
        
        public ICommand OpenEditWindowCommand { get; }
        public ICommand DeleteElmentCommand { get; }
        public ICommand OpenAddWindowCommand { get; }

        public PositionsViewModel(IWindowService windowService, User user)
        {
            _positionService = new PositionService();
            this._windowService = windowService;
            LoadPositions();       
            _workerService = new WorkerService();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            DeleteElmentCommand = new RelayCommand(OnDelete);
            OpenAddWindowCommand = new RelayCommand(OnAdd);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            _userService = new UserService();
            this._user = user;
            Login = _user.Login;
            AccessRight = _user.AccessRight;



        }
        private void OnAdd(object parameter)
        {
            if (_userService.IfUserCanDoCrud(_user))
            {
                _windowService.OpenModalWindow("AddPosition");
            }



        }

        private void OnMainWindowOpen(object parameter)
        {

            _windowService.OpenWindow("MainMenuView", _user);
            _windowService.CloseWindow();

        }

        private void OnEdit(object parameter)
        {
            if (_userService.IfUserCanDoCrud(_user))
            {
                var position = parameter as Position;
                if (position != null)
                {
                    _windowService.OpenModalWindow("ChangePosition", position);


                }
            }
        }


        public List<Position> SearchPositions(string query)
        {
            return Positions.Where(position =>
                position.PositionId.ToString().Contains(query) ||                            // Поиск по PositionId
                (!string.IsNullOrEmpty(position.PositionName) && position.PositionName.Contains(query, StringComparison.OrdinalIgnoreCase)) || // Поиск по PositionName
                position.Salary.ToString().Contains(query) ||                               // Поиск по Salary
                (!string.IsNullOrEmpty(position.StructureUnitName) && position.StructureUnitName.Contains(query, StringComparison.OrdinalIgnoreCase)) // Поиск по StructureUnitName
            ).ToList();
        }




        private void OnDelete(object parameter)
        {


            if (_userService.IfUserCanDoCrud(_user))
            {

                var position = parameter as Position;
                if (position != null)
                {
                    List<Worker> workerList = _workerService.GetWorkerDataByPositionId(position.PositionName);
                    if (workerList.Count == 0)
                    {
                        MessageBoxResult result = MessageBox.Show(
                          "Якщо ви натисните так, cтруктурну одиницю назавжди буде видалено з бази!",
                          "Ви дійсно хочете видалити cтруктурну одиницю?",

                         MessageBoxButton.YesNo,
                         MessageBoxImage.Warning);
                        if (result == MessageBoxResult.Yes)
                        {
                         
                            Positions.Remove(position);
                            _positionService.DeletePostion(position.PositionId);
                            LoadPositions();
                            MessageBox.Show("Стуркутрну одиницю успішно видалено", "Успішний результат", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                    else
                    {
                        MessageBox.Show("В базі наявні посади , що підпорядковуються даному департаменту! Видаліть, посади даної структурної одиниці, для виконання операції видалення!", "Помилка видалення департаменту",
                         MessageBoxButton.OK,
                         MessageBoxImage.Error);
                    }
                }
            }





        }


        private void LoadPositions()
        {
            try
            {
                var positionList = _positionService.GetPositionsData();
                Positions = new ObservableCollection<Position>(positionList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
