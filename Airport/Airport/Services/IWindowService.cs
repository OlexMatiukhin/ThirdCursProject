namespace Airport.Services
{
    public interface IWindowService
    {
        void OpenWindow(string windowName);
        void OpenModalWindow(string windowName, object parameter = null);
        void CloseWindow();
        void CloseModalWindow();
    }

}