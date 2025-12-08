using Oracle.ManagedDataAccess.Client;
using SportovniKlub.Models;
using SportovniKlub.Services;
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
    /// Interaction logic for TymyWindow.xaml
    /// </summary>
    public partial class TymyWindow : Window
    {
        public TymyWindow(TymyViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void AddTymButton_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    Tym tym = new Tym(
            //        tymID: 0,
            //        nazevTymu: "Nový tým",
            //        pocetHracu: 10,
            //        plat: 50000,
            //        pocetTrofeju: 3,
            //        vyseOdmen: 2000,
            //        sportovniDisciplinaID: 1,
            //        sponzorID: null,
            //        trenerID: 1
            //    );
            //    viewModel.AddTymCommand.Execute(tym);
            //}
            //catch (Exception ex)
            //{
            //    Clipboard.SetText(ex.Message);
            //    MessageBox.Show(ex.Message, "Chyba při přidávání týmu");
            //}
        }

        private void DeleteTymButton_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    Tym selectedTym = tymyGrid.SelectedItem as Tym;

            //    if (selectedTym == null)
            //    {
            //        MessageBox.Show("Vyberte tým, který chcete smazat.");
            //        return;
            //    }

            //    viewModel.DeleteTymCommand.Execute(selectedTym);
            //}
            //catch (OracleException ex)
            //{
            //    Clipboard.SetText(ex.Message);
            //    MessageBox.Show(ex.Message, "Chyba při mazání týmu");
            //}
        }

        private void SaveTymButton_Click(object sender, RoutedEventArgs e)
        {
            // ob.Commit();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // ob.Rollback();
            this.Close();
        }
    }
}
