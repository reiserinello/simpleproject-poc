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
using simpleproject_poc.ViewModels;

namespace simpleproject_poc.Views
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class ProjectOverview : Window
    {
        public ProjectOverview()
        {
            InitializeComponent();
            DataContext = new ProjectOverviewViewModel();
        }
    }
}
