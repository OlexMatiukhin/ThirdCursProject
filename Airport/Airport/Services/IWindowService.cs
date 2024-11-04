namespace Airport.Services
{
    public interface IWindowService
    {
        void OpenWindow(string windowName, object parameter = null);
        void OpenModalWindow(string windowName, object parameter = null, object parameter2 = null);
        void CloseWindow();
        void CloseModalWindow();
    }

}