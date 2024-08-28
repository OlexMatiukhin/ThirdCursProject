using System;
using System.Windows.Input;
public abstract class ComandBase : ICommand
{
    public event EventHandler CanExecuteChanged;

    public virtual bool CanExecute(object? parameter)
    {
        return true;
    }

    public abstract void Execute(object parameter);
    public void OnCanExucteChanged() 
    { 
        CanExecuteChanged?.Invoke(this, new EventArgs());
    }
    
    
}
