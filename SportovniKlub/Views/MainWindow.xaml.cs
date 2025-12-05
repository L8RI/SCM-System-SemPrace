using Microsoft.Extensions.DependencyInjection;
using Oracle.ManagedDataAccess.Client;
using SportovniKlub.ViewModels;
using SportovniKlub.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SportovniKlub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Move it all to StartWindow

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string query = "SELECT * FROM CENY";
            //var rows = ob.AddOsoby();



            //string output = "";
            //foreach (var row in rows)
            //{
            //    foreach (var kvp in row)
            //    {
            //        output += $"{kvp.Value}";
            //    }
            //    output += "\n";
            //}

            //Clipboard.SetText(output);
            //MessageBox.Show($"{rows}");
            try
            {
                //var rows = ob.AddOsoby();

                //string output = string.Join("\n", rows.Select(o =>
                //    $"{o.ClenKlubuId} | {o.DatumRegistrace:d} | {o.TymId} | {o.Body}"));

                //Clipboard.SetText($"{output}");
                //MessageBox.Show("ID | Datum registrace | ID Tymu | Body \n" + string.Join("\n", rows));
            } catch (Exception ex)
            {
                MessageBox.Show($"{ex.StackTrace}");
                Clipboard.SetText(ex.StackTrace);
            }

        }

        private void Show_Treninky_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var serviceProvider = App.ServiceProvider;
                var window = serviceProvider.GetRequiredService<TreninkyWindow>();
                window.Show();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Show_Tymy_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var window = new TymyWindow();
                window.Show();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Show_Zapasy_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Show_Osoby_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var window = new OsobyWindow();
                window.Show();
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}