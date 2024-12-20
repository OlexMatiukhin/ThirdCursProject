﻿using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Models;
using Airport.Services;
using Airport.Services.MongoDBSevice;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Airport.ViewModels.DialogViewModels.ChangeDataViewModel
{
    public class ChangeWorkerViewModel
    {
        private readonly BrigadeService _brigadeService;
        private readonly PositionService _postitionService;
        private readonly Worker _worker;


        private IWindowService _windowService;

        private readonly WorkerService _workerService;

        public ICommand ChangeWorkerCommand { get; }

        public ChangeWorkerViewModel(Worker worker, IWindowService windowService)
        {  this._worker = worker;
            this._windowService = windowService;
            _brigadeService = new BrigadeService();
            _postitionService = new PositionService();

            LoadData();
            CreateDictionaries();
            _workerService = new WorkerService();
            ChangeWorkerCommand = new RelayCommand(ExecuteChangeWorker, canExecute => true);
            FullName = worker.FullName;
            Age = worker.Age.ToString();
            SelectedStatus = worker.Status;
            SelectedGender = worker.Gender;
            NumberChildren = worker.NumberChildren.ToString();
            SelectedShift = worker.Shift;
            Email = worker.Email;
            PhoneNumber = worker.PhoneNumber;
            SelectedBrigadeId = worker.BrigadeId;
            SelectedPostionName = worker.PositionName;
        }

        private void ExecuteChangeWorker(object parameter)
        {
            if (ValidateInputs())
            {
              _worker.FullName = FullName;
            _worker.Age = int.Parse(Age);
            _worker.Status = SelectedStatus;
            _worker.Gender = SelectedGender;
            _worker.NumberChildren = int.Parse(NumberChildren);
            _worker.HireDate = DateTime.Now;
            _worker.Shift = SelectedShift;
            _worker.Email = Email;
            _worker.PhoneNumber = PhoneNumber;
            _worker.BrigadeId = SelectedBrigadeId;
            _worker.PositionName = SelectedPostionName;
             _workerService.UpdateWorker(_worker);
                   System.Windows.MessageBox.Show("Об'єкт успішно змінено!");
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
        {   "ніч",
            "ранок"
        };

        private bool ValidateInputs()
        {
            bool isValid = true;

            // Перевірка поля 'Повне ім'я'
            if (string.IsNullOrWhiteSpace(FullName))
            {
                MessageBox.Show("Поле 'Повне ім'я' не може бути порожнім.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            // Перевірка поля 'Вік'
            if (string.IsNullOrWhiteSpace(Age) || !int.TryParse(Age, out _))
            {
                MessageBox.Show("Поле 'Вік' повинно бути числовим значенням.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            // Перевірка поля 'Статус'
            if (string.IsNullOrWhiteSpace(SelectedStatus))
            {
                MessageBox.Show("Поле 'Статус' не може бути порожнім.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            // Перевірка поля 'Стать'
            if (string.IsNullOrWhiteSpace(SelectedGender))
            {
                MessageBox.Show("Поле 'Стать' не може бути порожнім.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            // Перевірка поля 'Кількість дітей'
            if (string.IsNullOrWhiteSpace(NumberChildren) || !int.TryParse(NumberChildren, out _))
            {
                MessageBox.Show("Поле 'Кількість дітей' повинно бути числовим значенням.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            // Перевірка поля 'Зміна'
            if (string.IsNullOrWhiteSpace(SelectedShift))
            {
                MessageBox.Show("Поле 'Зміна' не може бути порожнім.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            // Перевірка поля 'Email'
            if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@"))
            {
                MessageBox.Show("Поле 'Email' повинно містити коректну електронну пошту.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            // Перевірка поля 'Телефон'
            if (string.IsNullOrWhiteSpace(PhoneNumber) || PhoneNumber.Length < 10)
            {
                MessageBox.Show("Поле 'Телефон' повинно містити принаймні 10 цифр.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            // Перевірка поля 'Бригада'
            if (!SelectedBrigadeId.HasValue)
            {
                MessageBox.Show("Поле 'Бригада' не може бути порожнім.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            // Перевірка поля 'Посада'
            if (string.IsNullOrWhiteSpace(SelectedPostionName))
            {
                MessageBox.Show("Поле 'Посада' не може бути порожнім.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            return isValid;
        }

        public int _id;
        public string _fullName;
        private string _age;

        private string _selectedGender;
        private string _selectedStatus;
        private string _numberChildren;
        private string _selectedShift;
        private string _email;
        private string _phoneNumber;
        private ObjectId? _selectedBrigadeId;

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


        public ObjectId? SelectedBrigadeId
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
            PositionsDictionary = Positions.ToDictionary(b => b.PositionName, b => b.ToString());

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





    }
}

