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
    public class QeryMenuViewModel : INotifyPropertyChanged
    {
        private string _selectedItem;
        private IWindowService _windowService;
        private User _user;
        public ICommand OpenPageCommand { get; }
        public QeryMenuViewModel(IWindowService windowService, User user)
        {
            _windowService = windowService;
            OpenPageCommand = new RelayCommand(OnOpenPage, canExecute => true);
            _user = user;
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
            if (SelectedItem != null && SelectedItem != "")
            {
                _windowService.OpenWindow(SelectedItem, _user);
                _windowService.CloseWindow();


            }
        }




        public Dictionary<string, string> MenuItemsDictionary { get; set; } = new Dictionary<string, string>
        {
            { "Запит 1", "QueryOne" },
            { "Запит 2 ", "Query2" },
            { "Запит 3", "Query3" },
            { "Запит 4", "Query4" },
            { "Запит 5", "Query5" },
            { "Запит 6", "Query6" },
            { "Запит 7", "Query7" },
            { "Запит 8", "Query8" },
            { "Запит 9", "Query9" },
            { "Запит 10", "Query10" },
            { "Запит 11", "Query11" },
            { "Запит 12", "Query12" },
            { "Запит 13 рейси", "Query13" },
            { "Запит 14 рейси", "Query14" }


        };



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }



    }
}
