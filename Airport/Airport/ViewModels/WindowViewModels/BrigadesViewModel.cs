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
using System.Windows;

public class BrigadesViewModel:INotifyPropertyChanged
{
    private ObservableCollection<Brigade> _brigades;

    public ObservableCollection<Brigade> Brigades
    {
        get => _brigades;
        set
        {
            if (_brigades != value)
            {
                _brigades = value;
                OnPropertyChanged(nameof(Brigades));
            }
        }
    }
    private BrigadeService _brigadeService;
    private readonly IWindowService _windowService;
    public event PropertyChangedEventHandler PropertyChanged;
    public ICommand OpenMainWindowCommand { get; }




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
        LoadBrigades();
        if (!string.IsNullOrEmpty(searchLine))
        {
            var searchResult = SearchBrigades(searchLine);

            Brigades = new ObservableCollection<Brigade>(searchResult);

        }

    }


    public void SrearchBrigade(string searchLine)
    {
        LoadBrigades();
        if (!string.IsNullOrEmpty(searchLine))
        {
            var searchResult = SearchBrigades(searchLine);

            Brigades = new ObservableCollection<Brigade>(searchResult);

        }
        else
        {

        }
    }
    public ICommand OpenEditWindowCommand { get; }

    public ICommand DeleteWindowCommand { get; }
    public ICommand OpenAddWindowCommand { get; }

    public ICommand DeleteCommand  { get; }
    public BrigadesViewModel(IWindowService windowService)
    {
        _brigadeService = new BrigadeService();
        OpenEditWindowCommand = new RelayCommand(OnEdit);
        OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
        OpenAddWindowCommand = new RelayCommand(OnAdd);
        DeleteWindowCommand = new RelayCommand(OnDelete);

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


    private void OnDelete(object parameter)
    {

                    var brigade = parameter as Brigade;
                    if (brigade != null)
                    {

                        MessageBoxResult resultOther = MessageBox.Show(
                                     "Ви точно хочете видалити бригаду?",
                                     "Видалення бригади",
                                     MessageBoxButton.YesNo,
                                     MessageBoxImage.Warning);
                        if (resultOther == MessageBoxResult.Yes)
                        {
                            _brigadeService.RemoveBrigadeFromWorkers(brigade.BrigadeId);
                            _brigadeService.DeleteBrigade(brigade.BrigadeId);
                            MessageBox.Show(
                                    "Бригаду упішно видалено!",
                                    "Видалення бригади",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                        }


                    }       





    }
    private void OnMainWindowOpen(object parameter)
    {

        _windowService.OpenWindow("MainMenuView");
        _windowService.CloseWindow();

    }
    public List<Brigade> SearchBrigades(string query)
    {
        return Brigades.Where(brigade =>
            brigade.BrigadeId.ToString().Contains(query, StringComparison.OrdinalIgnoreCase) ||  
            brigade.BrigadeType.Contains(query, StringComparison.OrdinalIgnoreCase) || 
            brigade.NumberWorkers.ToString().Contains(query) || 
            brigade.StructureUnitName.Contains(query, StringComparison.OrdinalIgnoreCase)  
        ).ToList();
    }



    private void OnAdd(object parameter)
    {


        _windowService.OpenModalWindow("AddBrigade");







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



    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
