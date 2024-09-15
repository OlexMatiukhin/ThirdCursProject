using Airport.Models;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
using Airport.Services;




public class BaggageViewModel
{
    public ObservableCollection<Baggage> Baggages { get; set; }
    private BaggageService _baggageService;

    public BaggageViewModel()
    {
        _baggageService = new BaggageService();
        LoadCanceledFlights();
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