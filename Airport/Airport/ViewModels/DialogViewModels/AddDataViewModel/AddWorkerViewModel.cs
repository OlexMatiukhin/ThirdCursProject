using Airport.Command.AddDataCommands;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using Airport.Views.Dialog;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddWorkerViewModel : INotifyPropertyChanged
    {
        private readonly BrigadeService _brigadeService;
        private readonly PositionService _postitionService;
        private IWindowService _windowService;

        private readonly WorkerService _workerService;

        public ICommand AddWorkerCommand { get; }
  

        public AddWorkerViewModel(IWindowService windowService)
        {
            _brigadeService = new BrigadeService();
            _postitionService = new PositionService();
            this._windowService = windowService;

            LoadData();
            CreateDictionaries();
            _workerService = new WorkerService();
            AddWorkerCommand = new RelayCommand(ExecuteAddWorker, canExecute=>true);
        }

        private void ExecuteAddWorker(object parameter)
        {
            if (ValidateInputs())
            {
                Worker worker = new Worker
                {

                    FullName = FullName,
                    Age = int.Parse(Age),
                    Status = SelectedStatus,
                    Gender = SelectedGender,
                    NumberChildren = int.Parse(NumberChildren),
                    HireDate = DateTime.Now,
                    Shift = SelectedShift,
                    Email = Email,
                    PhoneNumber = PhoneNumber,
                    LastMedExamDate = DateTime.Now,
                    ResultMedExam="задвоільний",
                    BrigadeId = SelectedBrigadeId,
                    PositionName = SelectedPostionName
                };

                if (SelectedBrigadeId != ObjectId.Empty)
                {
                    _brigadeService.AddWorkerToBrigade(SelectedBrigadeId);

                }
           

                _workerService.AddWorker(worker);

                MessageBox.Show("Користувача успішно додано!");
                _windowService.CloseModalWindow();
            }
        }


        public ObservableCollection<Position> Positions { get; set; }
        public ObservableCollection<Brigade> Brigades { get; set; }


        public Dictionary<string, string> PositionsDictionary { get; set; }
        public Dictionary<ObjectId, string> BrigadesDictionary { get; set; }


        public List<string> Gender { get; set; } = new List<string>
        {
            "чоловік",
            "жінка"

        };
        public List<string> Status { get; set; } = new List<string>
        {   "начальник відділу",
            "начальник департаменту",
            "начальник бригади",
            "працівник"
        };
        public List<string> Shift { get; set; } = new List<string>
        {   "нічна",
            "денна"
        };


        public string _fullName;
        private string _age;

        private string _selectedGender;
        private string _selectedStatus;
        private string _numberChildren;
        private string _selectedShift;
        private string _email;
        private string _phoneNumber;
        private ObjectId _selectedBrigadeId;

        private string _selectedPostionName;
        public string FullName
        {
            get => _fullName;
            set
            {
                _fullName = value;
                OnPropertyChanged(nameof(SelectedStatus));
            }
        }
        public string Age
        {
            get => _age;
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }


        public string SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
                OnPropertyChanged(nameof(SelectedStatus));
            }
        }

        public string SelectedGender
        {
            get => _selectedGender;
            set
            {
                _selectedGender = value;
                OnPropertyChanged(nameof(SelectedGender));
            }
        }


        public string NumberChildren
        {
            get => _numberChildren;
            set
            {
                _numberChildren = value;
                OnPropertyChanged(nameof(NumberChildren));
            }
        }


        public string SelectedShift
        {
            get => _selectedShift;
            set
            {
                _selectedShift = value;
                OnPropertyChanged(nameof(SelectedShift));
            }
        }


        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }


        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public string SelectedPostionName
        {
            get => _selectedPostionName;
            set
            {
                _selectedPostionName = value;
                OnPropertyChanged(nameof(SelectedPostionName));
            }
        }


        public ObjectId SelectedBrigadeId
        {
            get => _selectedBrigadeId;
            set
            {
                _selectedBrigadeId = value;
                OnPropertyChanged(nameof(SelectedBrigadeId));
            }
        }


    



        private void LoadData()
        {
            var BrigadesList = _brigadeService.GetBrigadesData();
            Brigades = new ObservableCollection<Brigade>(BrigadesList);

            var PositionsList = _postitionService.GetPositionsData();
            Positions = new ObservableCollection<Position>(PositionsList);


        }


        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(FullName))
            {
                MessageBox.Show("Повне ім'я не може бути порожнім.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

         
            if (string.IsNullOrEmpty(Age) || !int.TryParse(Age, out _))
            {
                MessageBox.Show("Вік має бути числом і не може бути порожнім.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

    
            if (string.IsNullOrEmpty(SelectedStatus))
            {
                MessageBox.Show("Оберіть статус працівника.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (string.IsNullOrEmpty(SelectedGender))
            {
                MessageBox.Show("Оберіть стать.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }


            if (string.IsNullOrEmpty(NumberChildren) || !int.TryParse(NumberChildren, out _))
            {
                MessageBox.Show("Кількість дітей має бути числом.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }


            if (string.IsNullOrEmpty(SelectedShift))
            {
                MessageBox.Show("Оберіть зміну.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }


            if (string.IsNullOrEmpty(Email) || !Email.Contains("@"))
            {
                MessageBox.Show("Введіть правильну електронну пошту.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            
            if (string.IsNullOrEmpty(PhoneNumber) || PhoneNumber.Length < 10)
            {
                MessageBox.Show("Номер телефону має бути правильним і містити не менше 10 цифр.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

      
          

           
            if (string.IsNullOrEmpty(SelectedPostionName))
            {
                MessageBox.Show("Оберіть посаду.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void CreateDictionaries()
        {
            BrigadesDictionary = Brigades.ToDictionary(b => b.BrigadeId, b => b.ToString());
            PositionsDictionary = Positions.ToDictionary(b => b.PositionName, b => b.ToString());

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





    }
}