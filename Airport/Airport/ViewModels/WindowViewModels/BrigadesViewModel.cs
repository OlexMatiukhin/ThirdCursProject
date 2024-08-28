using Airport.Models;
using MongoDB.Driver;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

public class BrigadesViewModel
{
    public ObservableCollection<Brigade> Brigades { get; set; }
    private BrigadeService _brigadeService;

    public BrigadesViewModel()
    {
        _brigadeService = new BrigadeService();
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
