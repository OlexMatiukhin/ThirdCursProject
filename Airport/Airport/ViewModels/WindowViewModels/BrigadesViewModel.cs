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
using Airport.Services.MongoDBService;

public class BrigadesViewModel:INotifyPropertyChanged
{
    private ObservableCollection<Brigade> _brigades;
    private readonly UserService _userService;
    private User _user;

    public ICommand LogoutCommand { get; }



    private string _login;
    private string _accessRight;


    public string Login
    {
        get => _login;
        set
        {
            _login = value;
            OnPropertyChanged(nameof(Login));
        }
    }


    public string AccessRight
    {
        get => _accessRight;
        set
        {
            _accessRight = value;
            OnPropertyChanged(nameof(AccessRight));
        }
    }

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

    public ICommand OpenAddWindowCommand { get; }

    public ICommand DeleteWindowCommand { get; }
    public BrigadesViewModel(IWindowService windowService, User user)
    {
        _brigadeService = new BrigadeService();
        OpenEditWindowCommand = new RelayCommand(OnEdit);
        OpenMainWindowCommand = new RelayCommand(OnMainWindowOpen);
        OpenAddWindowCommand = new RelayCommand(OnAdd);
        DeleteWindowCommand = new RelayCommand(OnDelete);
        _userService = new UserService();
        this._user = user;
        _windowService = windowService;
        Login = _user.Login;
        AccessRight = _user.AccessRight;

        LogoutCommand = new RelayCommand(OnLogoutCommand);


    LoadBrigades();
    }
    private void OnEdit(object parameter)
    {
        if (_userService.IfUserCanDoCrud(_user))
        {
            var brigade = parameter as Brigade;
            if (brigade != null)
            {

                _windowService.OpenModalWindow("ChangeBrigade", brigade);


            }
        }
        




    }


    private void OnLogoutCommand(object parameter)
    {
        _windowService.OpenWindow("LoginView", _user);
        _windowService.CloseWindow();
    }


    private void OnDelete(object parameter)
    {
        if (_userService.IfUserCanDoCrud(_user))
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
                    LoadBrigades();
                }


            }
        }






    }
    private void OnMainWindowOpen(object parameter)
    {

        _windowService.OpenWindow("MainMenuView", _user);
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
        if (_userService.IfUserCanDoCrud(_user))
        {


            _windowService.OpenModalWindow("AddBrigade");
        }
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



    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
