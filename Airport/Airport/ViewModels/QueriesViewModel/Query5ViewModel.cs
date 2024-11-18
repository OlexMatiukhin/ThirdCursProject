using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using Airport.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Airport.ViewModels.QueriesViewModel
{
    public class Query5ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PilotMedExam> _pilotMedExams;
        private readonly PilotMedExamService _pilotMedExamService;

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



        private User _user;


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





        private string _selectedQueryType;
        public string SelectedQueryType
        {
            get => _selectedQueryType;
            set
            {
                _selectedQueryType = value;
                OnPropertyChanged(nameof(SelectedQueryType));
            }
        }

  
        private DateTime _startDate;
        private DateTime _endDate;

      

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

    

        public ICommand DoQuery { get; }

        private readonly IWindowService _windowService;

        public Query5ViewModel(IWindowService windowService, User user)
        {
            _windowService = windowService;
            _pilotMedExamService = new PilotMedExamService();
            DoQuery = new RelayCommand(OnDoQuery);

            Login = _user.Login;
            AccessRight = _user.AccessRight;

            LogoutCommand = new RelayCommand(OnLogoutCommand);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);

        }


        public ICommand OpenMainWindowCommand { get; }

        private void OnMainWindowOpen(object parameter)
        {
            _windowService.OpenWindow("MainMenuView", _user);
            _windowService.CloseWindow();

        }

        public ICommand LogoutCommand { get; }

        private void OnLogoutCommand(object parameter)
        {
            _windowService.OpenWindow("LoginView", _user);
            _windowService.CloseWindow();
        }



        public void OnDoQuery(object parameter)
        {
            if (SelectedQueryType != "Кількість")
            {
                PilotMedExams = new ObservableCollection<PilotMedExam>(
                _pilotMedExamService.GetPilotMedExamsWithPilotInfo(StartDate, EndDate));
            }
            else
            {
                var result = _pilotMedExamService.GetTotalPilotMedExamsCount(StartDate, EndDate);
                MessageBox.Show($"{result}", "Результат", MessageBoxButton.OK);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


