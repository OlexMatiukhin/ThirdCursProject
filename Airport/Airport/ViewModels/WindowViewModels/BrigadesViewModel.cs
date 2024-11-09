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

public class BrigadesViewModel
{
    public ObservableCollection<Brigade> Brigades { get; set; }
    private BrigadeService _brigadeService;
    private readonly IWindowService _windowService;
    public ICommand OpenEditWindowCommand { get; }


    public BrigadesViewModel(IWindowService windowService)
    {
        _brigadeService = new BrigadeService();
        OpenEditWindowCommand = new RelayCommand(OnEdit);
        _windowService = windowService;
        LoadBrigades();
    }
    private void OnEdit(object parameter)
    {

        var brigade = parameter as Brigade;
        if (brigade != null)
        {
            _windowService.OpenModalWindow("ChangeBrigade", brigade);


        }




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
