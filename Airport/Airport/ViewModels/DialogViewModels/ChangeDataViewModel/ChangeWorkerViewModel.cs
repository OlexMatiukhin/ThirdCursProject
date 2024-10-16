﻿using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services.MongoDBSevice;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.ChangeDataViewModel
{
    public class ChangeWorkerViewModel
    {
        private readonly BrigadeService _brigadeService;
        private readonly PositionService _postitionService;

        private readonly WorkerService _workerService;

        public ICommand ChangeWorkerCommand { get; }

        public ChangeWorkerViewModel(Worker worker)
        {
            _brigadeService = new BrigadeService();
            _postitionService = new PositionService();

            LoadData();
            CreateDictionaries();
            _workerService = new WorkerService();
            ChangeWorkerCommand = new RelayCommand(ExecuteChangeWorker, canExecute => true);
            _id = worker.WorkerId;
            FullName = worker.FullName;
                Age = worker.Age.ToString();
            SelectedStatus = worker.Status;
                SelectedGender = worker.Gender;
                NumberChildren = worker.NumberChildren.ToString();
                SelectedShift = worker.Shift;
                Email = worker.Email;
                PhoneNumber = worker.PhoneNumber;
                SelectedBrigadeId = worker.BrigadeId;
            SelectedPostionId = worker.PositionId;
        }

        private void ExecuteChangeWorker(object parameter)
        {
            Worker worker = new Worker
            {
                WorkerId = _id,
                FullName = FullName,
                Age = int.Parse(Age),
                Status = SelectedStatus,
                Gender = SelectedGender,
                NumberChildren = int.Parse(NumberChildren),
                HireDate = DateTime.Now,
                Shift = SelectedShift,
                Email = Email,
                PhoneNumber = PhoneNumber,
                BrigadeId = SelectedBrigadeId,
                PositionId = SelectedPostionId
            };

            _workerService.UpdateWorker(worker);
        }


        public ObservableCollection<Position> Positions { get; set; }
        public ObservableCollection<Brigade> Brigades { get; set; }


        public Dictionary<int, string> PositionsDictionary { get; set; }
        public Dictionary<int, string> BrigadesDictionary { get; set; }


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
        {   "ніч",
            "ранок"
        };

        public int _id;
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

