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
    /// Interaktionslogik für CreateProjectView.xaml
    /// </summary>
    public partial class CreateProjectView : Window
    {
        public CreateProjectView()
        {
            InitializeComponent();
            DataContext = new CreateProjectViewViewModel();
            Loaded += CreateProjectView_Loaded;
        }

        private void CreateProjectView_Loaded(object sender, RoutedEventArgs e)
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
