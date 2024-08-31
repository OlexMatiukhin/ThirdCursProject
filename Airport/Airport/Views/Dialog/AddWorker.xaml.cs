﻿using Airport.ViewModels.DialogViewModels;
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

namespace Airport.Views.Dialog
{
    /// <summary>
    /// Логика взаимодействия для ChangePlane.xaml
    /// </summary>
    public partial class AddWorker : Window
    {
        public AddWorker()
        {
            InitializeComponent();
            DataContext = new AddFlightViewModel();
        }

        private void Status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void FlightBrigade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}