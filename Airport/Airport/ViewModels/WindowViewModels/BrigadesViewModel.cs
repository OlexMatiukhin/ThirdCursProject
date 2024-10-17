using Airport.Models;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Airport.Services;

public class BrigadesViewModel
{
    public ObservableCollection<Brigade> Brigades { get; set; }
    private BrigadeService _brigadeService;
    private readonly IWindowService _windowService;


    public BrigadesViewModel(IWindowService windowService)
    {
        _brigadeService = new BrigadeService();
        _windowService = windowService;
        LoadBrigades();
    }

    private void LoadBrigades()
    {
        try
        {
            var brigadeList = _brigadeService.GetBrigadesData();
            Brigades = new ObservableCollection<Brigade>(brigadeList);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
