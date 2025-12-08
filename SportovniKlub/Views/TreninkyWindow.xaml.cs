using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;
using SportovniKlub.Models;
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

namespace SportovniKlub
{
    /// <summary>
    /// Interaction logic for TreninkyWindow.xaml
    /// </summary>
    public partial class TreninkyWindow : Window
    {
        public TreninkyWindow()
        {
            InitializeComponent();
        }

        private void AddTreninkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Trenink trenink = new Trenink(1, 2, new DateTime(2025, 1, 17), 1, 2);
                //viewModel.AddTreninkCommand.Execute(trenink);
            }
            catch (Exception ex)
            {
                Clipboard.SetText(ex.StackTrace);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void DeleteTreninkButton_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    if (treninkyGrid.SelectedItem is not Trenink selectedTrenink)
            //    {
            //        MessageBox.Show("Vyberte trenink, který chcete smazat.");
            //        return;
            //    }

            //    _viewModel.DeleteTreninkCommand.Execute(selectedTrenink);
            //}
            //catch (OracleException ex)
            //{
            //    Clipboard.SetText(ex.Message);
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void SaveTreninkButton_Click(object sender, RoutedEventArgs e)
        {
            //ob.Commit();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            //ob.Rollback();
            this.Close();
        }
    }
}
