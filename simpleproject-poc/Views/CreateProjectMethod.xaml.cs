﻿using System;
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
using simpleproject_poc.ViewModels;

namespace simpleproject_poc.Views
{
    /// <summary>
    /// Interaktionslogik für CreateProjectMethod.xaml
    /// </summary>
    public partial class CreateProjectMethod : Window
    {
        public CreateProjectMethod()
        {
            InitializeComponent();
            DataContext = new CreateProjectMethodViewModel();
            Loaded += CreateProjectMethod_Loaded;
        }

        private void CreateProjectMethod_Loaded (object sender, RoutedEventArgs e)
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
