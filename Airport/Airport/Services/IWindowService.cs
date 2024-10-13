namespace Airport.Services
{
    public interface IWindowService
    {
        void OpenWindow(string windowName, object parameter = null);
        void CloseWindow();
    }

}