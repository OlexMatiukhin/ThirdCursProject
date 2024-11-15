using Airport.Services;
using Airport.ViewModels.QueriesViewModel;
using Airport.Views.QueryWindow;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Airport
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        WindowService windowService = new WindowService();       
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            windowService.OpenWindow("LoginView", this);
            /*User user = null;
            Query query = new Query();
            query.DataContext= new Query3ViewModel(windowService, user);
            query.Show();*/
        }
    }

}
