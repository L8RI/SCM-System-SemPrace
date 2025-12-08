using SportovniKlub.Models;
using SportovniKlub.ModelsDTO;
using SportovniKlub.ViewModels;
using System;
using System.Windows;

namespace SportovniKlub
{
    public partial class OsobyWindow : Window
    {
        private OsobyViewModel viewModel;

        public OsobyWindow(OsobyViewModel vm)
        {
            InitializeComponent();
            viewModel = vm;
            DataContext = viewModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Osoba osoba = new Osoba(
                    osobaId: 0,
                    jmeno: "Nové jméno",
                    prijmeni: "Nové příjmení",
                    datumNarozeni: DateTime.Now,
                    mail: "novy@mail.cz",
                    typOsoby: 'C', 
                    sportovniDisciplinaId: 1
                );

                viewModel.AddCommand.Execute(osoba);
            }
            catch (Exception ex)
            {
                Clipboard.SetText(ex.Message);
                MessageBox.Show(ex.Message, "Chyba při přidávání osoby");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (osobyGrid.SelectedItem is OsobaDTO selected)
                {
                    viewModel.DeleteCommand.Execute(selected);
                }
                else
                {
                    MessageBox.Show("Vyberte osobu, kterou chcete smazat.");
                }
            }
            catch (Exception ex)
            {
                Clipboard.SetText(ex.Message);
                MessageBox.Show(ex.Message, "Chyba při mazání osoby");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // viewModel.UpdateCommand.Execute(selectedOsoba);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
