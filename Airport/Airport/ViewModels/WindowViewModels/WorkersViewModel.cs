using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.Services;
using System.Windows.Input;
using Airport.Command.AddDataCommands.Airport.Commands;
using System.Reflection.Metadata;
using System.Windows;
using System.ComponentModel;

namespace Airport.ViewModels.WindowViewModels
{
    public class WorkersViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Worker> _workers;


        public ObservableCollection<Worker> Workers
        {
            get => _workers;
            set
            {
                if (_workers != value)
                {
                    _workers = value;
                    OnPropertyChanged(nameof(Workers));
                }
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
            LoadWorkers();
            if (!string.IsNullOrEmpty(searchLine))
            {
                var searchResult = SearchWorkers(searchLine);

                Workers = new ObservableCollection<Worker>(searchResult);

            }

        }
        private WorkerService _workerService;
        private BrigadeService _briagadeService;
        private PilotMedExamService _pilotMedExamService;
        public ICommand OpenMainWindowCommand { get; }
        public ICommand OpenEditWindowCommand { get; }
        public ICommand OpenAddWindowCommand { get; }
        public ICommand DeleteWindowCommand { get; }
        private readonly IWindowService _windowService;

        public ICommand SendPilotToMedExam { get; }
   

        public WorkersViewModel( IWindowService windowService)
        {
            _workerService = new WorkerService();
            LoadWorkers();
            OpenEditWindowCommand = new RelayCommand(OnEdit);
            this._windowService =windowService;
            _briagadeService = new BrigadeService();
            _pilotMedExamService = new PilotMedExamService();
            OpenAddWindowCommand = new RelayCommand(OnAdd);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            DeleteWindowCommand = new RelayCommand(OnDelete);

        }
        private void OnMainWindowOpen(object parameter)
        {

            _windowService.OpenWindow("MainMenuView");
            _windowService.CloseWindow();

        }
        public List<Worker> SearchWorkers(string query)
        {
            return Workers.Where(worker =>
                worker.WorkerId.ToString().Contains(query) ||                            // Поиск по WorkerId
                (!string.IsNullOrEmpty(worker.FullName) && worker.FullName.Contains(query, StringComparison.OrdinalIgnoreCase)) || // Поиск по FullName
                worker.Age.ToString().Contains(query) ||                                 // Поиск по Age
                (!string.IsNullOrEmpty(worker.Status) && worker.Status.Contains(query, StringComparison.OrdinalIgnoreCase)) || // Поиск по Status
                (!string.IsNullOrEmpty(worker.Gender) && worker.Gender.Contains(query, StringComparison.OrdinalIgnoreCase)) || // Поиск по Gender
                worker.NumberChildren.ToString().Contains(query) ||                     // Поиск по NumberChildren
                worker.HireDate.ToString("d").Contains(query) ||                         // Поиск по HireDate
                (!string.IsNullOrEmpty(worker.Shift) && worker.Shift.Contains(query, StringComparison.OrdinalIgnoreCase)) || // Поиск по Shift
                (!string.IsNullOrEmpty(worker.Email) && worker.Email.Contains(query, StringComparison.OrdinalIgnoreCase)) || // Поиск по Email
                (!string.IsNullOrEmpty(worker.PhoneNumber) && worker.PhoneNumber.Contains(query)) || // Поиск по PhoneNumber
                (worker.BrigadeId.HasValue && worker.BrigadeId.Value.ToString().Contains(query)) || // Поиск по BrigadeId
                (!string.IsNullOrEmpty(worker.PositionName) && worker.PositionName.Contains(query, StringComparison.OrdinalIgnoreCase)) || // Поиск по PositionName
                worker.LastMedExamDate.ToString("d").Contains(query) ||                  // Поиск по LastMedExamDate
                (!string.IsNullOrEmpty(worker.ResultMedExam) && worker.ResultMedExam.Contains(query, StringComparison.OrdinalIgnoreCase)) // Поиск по ResultMedExam
            ).ToList();
        }

        private void OnEdit(object parameter)
        {

            var worker = parameter as Worker;
            if (worker != null)
            {
                _windowService.OpenModalWindow("ChangeWorker", worker);
                _windowService.CloseWindow();
            }
        }

        private void OnAdd(object parameter)
        {
            _windowService.OpenModalWindow("AddWorker");



        }
        private void OnSendPilotToMedExam(object parameter) {
            var worker = parameter as Worker;
            if (worker != null&& worker.PositionName=="Пілот")

            {
                MessageBoxResult result = MessageBox.Show(
                           "Відправити пілота на медогляд?",
                           "",
                           MessageBoxButton.YesNo,
                           MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes) {
                    _pilotMedExamService.AddPilotMedExamForWorker(worker);
                }

            }
            else
            {
                Console.WriteLine("Данна функція доступна лише для пілотів");
            }

        }

        private void LoadWorkers()
        {
            try
            {
                var workerList = _workerService.GetWorkersData();
                Workers = new ObservableCollection<Worker>(workerList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
        private void OnDelete(object parameter)
        {

            var worker= parameter as Worker;
            if (worker != null && worker.BrigadeId==null)
            {

                MessageBoxResult resultOther = MessageBox.Show(
                             "Ви точно хочете видалити працівника?",
                             "Видалення інформації про працівника",
                             MessageBoxButton.YesNo,
                             MessageBoxImage.Warning);
                if (resultOther == MessageBoxResult.Yes)
                {

                    _workerService.DeleteWorker(worker.WorkerId);
                    MessageBox.Show(
                            "Працівника успішно видалено!",
                            "Видалення інформації про працівника",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                }


            }
            else
            {
                MessageBox.Show(
                            "Видалення літака неможливо, з ним заплановано рейси!",
                              "Видалення інформації",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);

            }






        }


        private void OnDeleteFromBrigade(object parameter)
        {
            var worker = parameter as Worker;
            if (worker != null)
            {
                _workerService.DeleteBrigadeFromWorker(worker.WorkerId);

            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}

