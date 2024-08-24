using System;
using System.Collections.Generic;
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

namespace Airport
{
    /// <summary>
    /// Логика взаимодействия для CompletedFlightPassengersView.xaml
    /// </summary>
    public partial class CompletedFlightPassengersView : Window
    {
        public CompletedFlightPassengersView()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button clicked!");
        }


        private void StackPanel_MouseDown(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Button clicked!");
        }
        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show("Ошибка загрузки изображения: " + e.ErrorException.Message);
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("аг");
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
