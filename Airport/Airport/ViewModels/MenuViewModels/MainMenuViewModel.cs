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
using System.Windows.Input;



namespace Airport.ViewModels.MenuViewModels
{
    public class MainMenuViewModel : INotifyPropertyChanged
    {
        private string _selectedItem;
        private IWindowService _windowService;
        public ICommand OpenPageCommand { get; }
        public MainMenuViewModel(IWindowService windowService)
        {
            _windowService = windowService;
            OpenPageCommand = new RelayCommand(OnOpenPage, canExecute=>true);
        }

        public string SelectedItem

        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public void OnOpenPage(object parameter)
        {
            if(SelectedItem!=null&& SelectedItem != "")
            {   _windowService.OpenWindow(SelectedItem);
                _windowService.CloseWindow();
                
             
            }
        }


        

        public Dictionary<string, string> MenuItemsDictionary { get; set; } = new Dictionary<string, string>
        {
            { "Департаменти", "DepartmentsView" },
            { "Структурні одиниця", "StructureUnitsView" },
            { "Бригади", "BrigadesView" },
            { "Посади", "PositionsView" },
            { "Працівники", "WorkersView" },
            { "Маршрути", "RoutesView" },
            { "Літаки", "PlanesView" },
            { "Рейси", "FlightsView" },
            { "Сидіння", "SeatsView" },
            { "Квитки", "TicketsView" },
            { "Пасажири", "PassengersView" },
            { "Багаж", "BaggageView" },
            { "Скасовані рейси", "CanceledFlightsView" },
            { "Перенесені рейси", "DelayedFlightsInfoView" },
            { "Завершені рейси", "CompletedFlightsView" },
            { "Пасажири завершених рейсів", "PassengerCompletedFlightView" },
            { "Повернення квитків", "RefundedTicketsView" },
            { "Ремонт літаків", "PlaneRepairView" },
            { "Медогляд пілотів", "PilotsMedExamView" }
        };



        public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
       
    }



}
}
