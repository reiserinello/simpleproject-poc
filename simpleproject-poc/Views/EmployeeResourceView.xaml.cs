﻿using simpleproject_poc.ViewModels;
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

namespace simpleproject_poc.Views
{
    /// <summary>
    /// Interaktionslogik für EmployeeResourceView.xaml
    /// </summary>
    public partial class EmployeeResourceView : Window
    {
        public EmployeeResourceView()
        {
            InitializeComponent();
            DataContext = new EmployeeResourceViewViewModel();
            Loaded += EmployeeResourceView_Loaded;
        }

        private void EmployeeResourceView_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseWindows vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }
    }
}