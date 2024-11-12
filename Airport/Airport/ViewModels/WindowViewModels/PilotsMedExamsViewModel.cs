using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;



namespace Airport.ViewModels.WindowViewModels
{
    
    public class PilotsMedExamsViewModel:INotifyPropertyChanged
    {
        private ObservableCollection<PilotMedExam> _pilotMedExams;

        public ObservableCollection<PilotMedExam> PilotMedExams
        {
            get => _pilotMedExams;
            set
            {
                if (_pilotMedExams != value)
                {
                    _pilotMedExams = value;
                    OnPropertyChanged(nameof(PilotMedExams));
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
            LoadPilotMedExams();
            if (!string.IsNullOrEmpty(searchLine))
            {
                var searchResult = SearchExams(searchLine);

                PilotMedExams = new ObservableCollection<PilotMedExam>(searchResult);

            }

        }
        private PilotMedExamService _pilotMedExamService;
        public ICommand OpenMainWindowCommand { get; }
        public ICommand DeleteWindowCommand { get; }

        private readonly IWindowService _windowService;
        private ICommand EndExamCommand;
        private Worker _worker;
        private WorkerService _workerService;
        public PilotsMedExamsViewModel(IWindowService windowService)
        {
            _pilotMedExamService = new PilotMedExamService();
            LoadPilotMedExams();
            this._windowService = windowService;
            _workerService = new WorkerService();
            EndExamCommand = new RelayCommand(OnEndExam);
            _windowService = new WindowService();
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
            DeleteWindowCommand = new RelayCommand(OnDelete);


        }
        private void OnMainWindowOpen(object parameter)
        {

            _windowService.OpenWindow("MainMenuView");
            _windowService.CloseWindow();

        }

        private void OnDelete(object parameter)
        {

            var pilotMedExam = parameter as PilotMedExam;
            if (pilotMedExam != null&& pilotMedExam.Result=="пройдено")
            {

                MessageBoxResult resultOther = MessageBox.Show(
                             "Ви точно хочете видалити інформацію про завершений рейс?",
                             "Видалення інформації",
                             MessageBoxButton.YesNo,
                             MessageBoxImage.Warning);
                if (resultOther == MessageBoxResult.Yes)
                {

                    _pilotMedExamService.DeletePilotMedExam(pilotMedExam.ExamId);
                    MessageBox.Show(
                            " Інформацію упішно видалено!",
                              "Видалення інформації",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                }


            }
            else
            {
                MessageBox.Show(
                            "Видалення інформації неможливе!",
                              "Видалення інформації",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning);

            }






        }
        private void OnEndExam(object parameter)
        {

            var pilotMedExam = parameter as PilotMedExam;
            if (pilotMedExam != null)
            {
                MessageBoxResult result = MessageBox.Show(
                       "Стан здоров`я задовільний?",
                       "",
                       MessageBoxButton.YesNo,
                       MessageBoxImage.Question);
                _worker = _workerService.GetWorkerById(pilotMedExam.PilotId);
                if (result == MessageBoxResult.Yes)
                {
                    pilotMedExam.Result = "пройдений";
                    pilotMedExam.DateExamination = DateTime.Now;
                    pilotMedExam.DoctorId = null;
                    _pilotMedExamService.UpdatePilotMedExam(pilotMedExam);
                    _worker.ResultMedExam = "задовільний";
                    _worker.LastMedExamDate = DateTime.Now;
                }
                else
                {
                    _windowService.OpenModalWindow("ChangePilotPositionViewModel", pilotMedExam, _worker);
                }



            }
            



        }


        public List<PilotMedExam> SearchExams(string query)
        {
            return PilotMedExams.Where(exam =>
                exam.ExamId.ToString().Contains(query) ||                                  // Поиск по ExamId
                (!string.IsNullOrEmpty(exam.Result) && exam.Result.Contains(query, StringComparison.OrdinalIgnoreCase)) || // Поиск по Result
                (exam.PilotId.HasValue && exam.PilotId.ToString().Contains(query)) ||       // Поиск по PilotId
                (exam.DoctorId.HasValue && exam.DoctorId.ToString().Contains(query)) ||     // Поиск по DoctorId
                (exam.DateExamination.HasValue && exam.DateExamination.Value.ToString("yyyy-MM-dd").Contains(query)) // Поиск по DateExamination
            ).ToList();
        }



        private void LoadPilotMedExams()
        {
            try
            {
                var pilotMedExamList = _pilotMedExamService.GetPilotMedExamsData();
                PilotMedExams = new ObservableCollection<PilotMedExam>(pilotMedExamList);
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

