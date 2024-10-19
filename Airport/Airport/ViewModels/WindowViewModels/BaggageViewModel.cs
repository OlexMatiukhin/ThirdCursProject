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




public class BaggageViewModel
{
    public ObservableCollection<Baggage> Baggages { get; set; }
    private BaggageService _baggageService;
    public ICommand OpenEditWindowCommand { get; }
    private readonly IWindowService _windowService;


    public BaggageViewModel(IWindowService windowService)
    {
        _baggageService = new BaggageService();
        _windowService = windowService;
        LoadCanceledFlights();
        OpenEditWindowCommand = new RelayCommand(OnEdit);
    }
    private void OnEdit(object parameter)
    {

        var baggage = parameter as Baggage;
        if (baggage != null)
        {
            _windowService.OpenModalWindow("ChangeBaggage", baggage);
            
        }





    }

    private void LoadCanceledFlights()
    {
        try
        {
            var baggageList = _baggageService.GetBaggageData();
            Baggages = new ObservableCollection<Baggage>(baggageList);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}