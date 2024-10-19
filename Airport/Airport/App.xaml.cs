using Airport.Services;
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
            windowService.OpenWindow("MainMenuView");
        }
    }

}
