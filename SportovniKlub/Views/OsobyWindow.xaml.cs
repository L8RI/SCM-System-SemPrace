using SportovniKlub.ViewModels;
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

namespace SportovniKlub.Views
{
    /// <summary>
    /// Interaction logic for OsobyWindow.xaml
    /// </summary>
    public partial class OsobyWindow : Window
    {
        private OsobyViewModels osobyViewModels;

        public OsobyWindow()
        {
            InitializeComponent();
            //var app = (App)Application.Current;
            //osobyViewModels = new OsobyViewModels(app.OsobyService);

            //DataContext = osobyViewModels;
        }

        private void AddOsobaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteOsobaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveOsobaButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
