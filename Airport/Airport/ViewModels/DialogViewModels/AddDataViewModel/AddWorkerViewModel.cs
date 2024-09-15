using Airport.Command.AddDataCommands;
using Airport.Models;
using Airport.Services;
using Airport.Views.Dialog;
using MongoDB.Bson;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class AddWorkerViewModel : INotifyPropertyChanged
    {
        private readonly BrigadeService _brigadeService;
        private readonly PositionService _postitionService;
        private AddWorkerCommand _addWorkerCommand;
        public AddWorkerCommand AddWorkerCommand
        {
            get => _addWorkerCommand;
            set
            {
                _addWorkerCommand = value;


            }
        }



        public ObservableCollection<Position> Positions { get; set; }
        public ObservableCollection<Brigade> Brigades { get; set; }


        public Dictionary<int, string> PositionsDictionary { get; set; }
        public Dictionary<int, string> BrigadesDictionary { get; set; }


        public List<string> Gender { get; set; } = new List<string>
        {
            "Чоловік",
            "Жінка"

        };
        public List<string> Status { get; set; } = new List<string>
        {   "Начальник відділу",
            "Начальник департаменту",
            "Начальник бригади",
            "Працівник"
        };
        public List<string> Shift { get; set; } = new List<string>
        {   "Нічна",
            "Денна"
        };


        public string _fullName;
        private string _age;

        private string _selectedGender;
        private string _selectedStatus;
        private string _numberChildren;
        private string _selectedShift;
        private string _email;
        private string _phoneNumber;
        private int _selectedBrigadeId;

        private int _selectedPostionId;
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

        public int SelectedPostionId
        {
            get => _selectedPostionId;
            set
            {
                _selectedPostionId = value;
                OnPropertyChanged(nameof(SelectedPostionId));
            }
        }


        public int SelectedBrigadeId
        {
            get => _selectedBrigadeId;
            set
            {
                _selectedBrigadeId = value;
                OnPropertyChanged(nameof(SelectedBrigadeId));
            }
        }


        public AddWorkerViewModel()
        {
            _brigadeService = new BrigadeService();
            _postitionService = new PositionService();

            LoadData();
            CreateDictionaries();
            _addWorkerCommand = new AddWorkerCommand(this);


        }



        private void LoadData()
        {
            var BrigadesList = _brigadeService.GetBrigadesData();
            Brigades = new ObservableCollection<Brigade>(BrigadesList);

            var PositionsList = _postitionService.GetPositionsData();
            Positions = new ObservableCollection<Position>(PositionsList);


        }

        private void CreateDictionaries()
        {
            BrigadesDictionary = Brigades.ToDictionary(b => b.BrigadeId, b => b.ToString());
            PositionsDictionary = Positions.ToDictionary(b => b.PositionId, b => b.ToString());

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





    }
}