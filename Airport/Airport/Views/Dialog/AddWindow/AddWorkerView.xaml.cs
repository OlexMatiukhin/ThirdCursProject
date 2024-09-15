﻿using Airport.ViewModels.DialogViewModels.AddDataViewModel;
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
using System.Windows.Shapes;

namespace Airport.Views.Dialog
{
    /// <summary>
    /// Логика взаимодействия для AddWorkerView.xaml
    /// </summary>
    public partial class AddWorkerView : Window
    {
        public AddWorkerView()
        {
            InitializeComponent();

            DataContext = new AddWorkerViewModel();
        }
    }
}