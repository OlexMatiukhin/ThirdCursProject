using Airport.ViewModels.DialogViewModels.ChangeDataViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Airport.Views.Dialog
{
    /// <summary>
    /// Логика взаимодействия для ChangeBaggage.xaml
    /// </summary>
    public partial class ChangeBaggage : Window
    {
        public ChangeBaggage()
        {
            InitializeComponent();
        }
        private void FlightNumber_Копировать1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            // Здесь можно добавить логику, если нужно
            // Например, показывать диалог подтверждения перед закрытием
        }

        // Закрытие окна через кнопку
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Закрывает только это модальное окно
        }




    }
}
