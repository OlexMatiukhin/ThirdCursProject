

using Airport.Models; // Исправлено: используется правильное пространство имен для Flight и Worker
using System;
using System.Windows; // Добавлено: для использования MessageBox

namespace Airport.ViewModels.DialogViewModels.AddDataViewModel
{
    public class OpenEditFlightCommand : CommandBase
    {
        private readonly Action<Flight> _onOpenWindow;
                public OpenEditFlightCommand(Action<Flight> onOpenWindow)
        {
            _onOpenWindow = onOpenWindow ?? throw new ArgumentNullException(nameof(onOpenWindow));
        }

        public override void Execute(object parameter)
        {
           
            if (parameter is Flight flight)
            {
                
                _onOpenWindow(flight);
            }
            else
            {
               MessageBox.Show("Invalid data.");
            }
        }
    }
}


