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
    /// Interaktionslogik für PhaseView.xaml
    /// </summary>
    public partial class PhaseView : Window
    {
        public PhaseView()
        {
            InitializeComponent();
            DataContext = new PhaseViewViewModel();
        }
    }
}
