using simpleproject_poc.ViewModels;
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
    /// Interaktionslogik für SetVisumView.xaml
    /// </summary>
    public partial class SetVisumView : Window
    {
        public SetVisumView()
        {
            InitializeComponent();
            DataContext = new SetVisumViewViewModel();
        }
    }
}
