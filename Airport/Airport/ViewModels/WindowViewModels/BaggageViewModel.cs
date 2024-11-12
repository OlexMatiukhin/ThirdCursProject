using Airport.Models;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Airport.Services;
using System.Windows.Input;
using Airport.Command.AddDataCommands.Airport.Commands;
using Airport.Services.MongoDBSevice;
using System.Numerics;
using System.Windows.Controls;




public class BaggageViewModel:INotifyPropertyChanged
{
    public ObservableCollection<Baggage> _baggages;


     public ObservableCollection<Baggage> Baggages
    {
        get => _baggages;
        set
        {
            _baggages = value;
            OnPropertyChanged(nameof(Baggages));
        }
    }

    private BaggageService _baggageService;
    public ICommand OpenEditWindowCommand { get; }
    public ICommand OpenMainWindowCommand { get; }
    public ICommand OpenAddWindowCommand { get; }
    private readonly IWindowService _windowService;
    public event PropertyChangedEventHandler PropertyChanged;



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
        LoadBagge();
        if (!string.IsNullOrEmpty(searchLine))
        {
            var searchResult = SearchBaggage(searchLine);

            Baggages = new ObservableCollection<Baggage>(searchResult);

        }

    }





    public BaggageViewModel(IWindowService windowService)
    {
        _baggageService = new BaggageService();
        _windowService = windowService;
        LoadBagge();
        OpenEditWindowCommand = new RelayCommand(OnEdit);
        OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
        OpenAddWindowCommand = new RelayCommand(OnAdd);
    }
    private void OnEdit(object parameter)
    {

        var baggage = parameter as Baggage;
        if (baggage != null)
        {
            _windowService.OpenModalWindow("ChangeBaggage", baggage);
            
        }





    }


  




    public List<Baggage> SearchBaggage(string query)
    {
        
         
            return Baggages.Where(baggage =>
                baggage.BaggageId.ToString().Contains(query, StringComparison.OrdinalIgnoreCase) ||
                baggage.FlightId.ToString().Contains(query, StringComparison.OrdinalIgnoreCase) ||
                baggage.BaggageType.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                baggage.Weight.ToString().Contains(query) ||
                baggage.Payment.ToString().Contains(query) ||
                baggage.PassengerId.ToString().Contains(query, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        
    }
    private void OnMainWindowOpen(object parameter)
    {

        _windowService.OpenWindow("MainMenuView");
        _windowService.CloseWindow();

    }
    private void OnAdd(object parameter)
    {

        
            _windowService.OpenModalWindow("AddBaggage");

        





    }

    private void LoadBagge()
    {
        try
        {
            var baggageList = _baggageService.GetBaggageData();
            Baggages = new ObservableCollection<Baggage>(baggageList);
        }
        catch (Exception ex)
        {
           
        }
    }
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}