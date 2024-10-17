using Airport.Command.AddDataCommands.Airport.Commands;
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

namespace Airport.ViewModels.DialogViewModels.Change
{
    public class ChangePlaneRepairViewModel
    {
        private readonly PlaneRepairService _planeRepairService;
        private BrigadeService _brigadeService;
        private PlaneService _planeService;


        public ICommand ChangePlaneRepairCommand { get; }

        public ObservableCollection<Brigade> Brigades { get; set; }
        public ObservableCollection<Plane> Planes { get; set; }

        public Dictionary<int, string> BrigadesDictionary { get; set; }
        public Dictionary<int, string> PlanesDictionary { get; set; }


        public List<string> Result { get; set; } = new List<string>
        {
                "відремонтовано",
                "списання",

        };

        public List<string> Status { get; set; } = new List<string>
        {
                "активний",
                "завершений",

        };





        private int _id;
        private DateTime _startDate;
        private string _status;
        private int _numberFlights;
        private DateTime? _endDate;
        private string _reason;
        private string _result;
        private int _brigadeId;
        private int _planeId;

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public string SelectedStatus
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(SelectedStatus));
            }
        }

        public int NumberFlights
        {
            get => _numberFlights;
            set
            {
                _numberFlights = value;
                OnPropertyChanged(nameof(NumberFlights));
            }
        }

        public DateTime? EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        public string Reason
        {
            get => _reason;
            set
            {
                _reason = value;
                OnPropertyChanged(nameof(Reason));
            }
        }

        public string SelectedResult
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

        public int SelectedBrigadeId
        {
            get => _brigadeId;
            set
            {
                _brigadeId = value;
                OnPropertyChanged(nameof(SelectedBrigadeId));
            }
        }

        public int SelectedPlaneId
        {
            get => _planeId;
            set
            {
                _planeId = value;
                OnPropertyChanged(nameof(SelectedPlaneId));
            }
        }

        public ChangePlaneRepairViewModel(PlaneRepair repair)
        {

            _planeRepairService = new PlaneRepairService();
            _brigadeService = new BrigadeService();
            _planeService= new PlaneService();


            this._id = repair.PlaneRepairId;
            this.StartDate=repair.StartDate;
            this.SelectedStatus = repair.Status;
            this.NumberFlights = repair.NumberFlights;
            this.EndDate= repair.EndDate;
            this.Reason = repair.Reason;
            this.SelectedResult=repair.Result;
            this.SelectedBrigadeId = repair.BrigadeId;
            this.SelectedPlaneId = repair.PlaneId;
            
            ChangePlaneRepairCommand = new RelayCommand(ExecuteChangePlaneRepair);
            LoadData();
            CreateDictionaries();
        }

        private void ExecuteChangePlaneRepair(object parameter)
        {
            PlaneRepair planeRepair = new PlaneRepair
            {
                PlaneRepairId = _id,
                StartDate = StartDate,
                Status = SelectedStatus,
                NumberFlights = NumberFlights,
                EndDate = EndDate,
                Reason = Reason,
                Result = SelectedResult,
                BrigadeId = SelectedBrigadeId,
                PlaneId = SelectedPlaneId
            };

            _planeRepairService.UpdatePlaneRepair(planeRepair);






        }

        private void LoadData()
        {
            var BrigadesList = _brigadeService.GetBrigadesData();
            Brigades = new ObservableCollection<Brigade>(BrigadesList);

            var PlaneList  = _planeService.GetPlanesData();
            Planes = new ObservableCollection<Plane>(PlaneList);
        }

        private void CreateDictionaries()
        {
            PlanesDictionary = Planes.ToDictionary(p => p.PlaneId, p => p.ToString());
            BrigadesDictionary = Brigades.ToDictionary(b => b.BrigadeId, b => b.ToString());

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
