using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBService;
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
using MongoDB.Bson;
using System.Windows;

namespace Airport.ViewModels.QueriesViewModel
{
    public class Query10ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Worker> _workers;

        private WorkerService _workerService;
  

        private User _user;
        public ICommand DoQuery { get; }

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
        private readonly UserService _userService;
        private readonly IWindowService _windowService;

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






        public Query10ViewModel(IWindowService windowService, User user)
        {
            _windowService = windowService;
            _workerService = new WorkerService();

            _userService = new UserService();
            _user = user;
            LogoutCommand = new RelayCommand(OnLogoutCommand);
            Login = _user.Login;
            AccessRight = _user.AccessRight;
            DoQuery = new RelayCommand(OnDoQuery);
            LogoutCommand = new RelayCommand(OnLogoutCommand);
            OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);



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
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        private string _brigadeId;
        public string BrigadeId
        {
            get => _brigadeId;
            set
            {
                if (_brigadeId != value)
                {
                    _brigadeId = value;
                    OnPropertyChanged(nameof(BrigadeId));
                }
            }
        }


        private string _minAgeText;
        public string MinAgeText
        {
            get => _minAgeText;
            set
            {
                if (_minAgeText != value)
                {
                    _minAgeText = value;
                    OnPropertyChanged(nameof(MinAgeText));

                  
                    if (int.TryParse(_minAgeText, out int parsedValue))
                    {
                        MinAge = parsedValue;
                    }
                    else
                    {
                        MessageBox.Show("Неправельний ввід", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private int _minAge;
        public int MinAge
        {
            get => _minAge;
            private set
            {
                if (_minAge != value)
                {
                    _minAge = value;
                    OnPropertyChanged(nameof(MinAge));
                }
            }
        }

        

        public void OnDoQuery(object parameter)
        {
            
            if (!ObjectId.TryParse(BrigadeId, out ObjectId brigadeObjectId)&&MinAge>0)
            {
               
                MessageBox.Show("Некоректний ввід.");
                return;
            }

       
            Workers = new ObservableCollection<Worker>(_workerService.GetWorkersByBrigadeIdAndMinAge(brigadeObjectId, MinAge));
        }

       





     

        

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
