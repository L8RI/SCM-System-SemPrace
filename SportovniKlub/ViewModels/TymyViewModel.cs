using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using SportovniKlub.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.ViewModels
{
    internal class TymyViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Tym> Tymy { get; set; }
        public ITymyService TymyService { get; set; }
        public RelayCommand AddTymCommand { get; set; }
        public RelayCommand DeleteTymCommand { get; set; }

        public TymyViewModel(ITymyService tymyService)
        {
            TymyService = tymyService;
            Tymy = new ObservableCollection<Tym>();

            AddTymCommand = new RelayCommand(tym =>
            {
                TymyService.AddTym((Tym)tym);
            });

            DeleteTymCommand = new RelayCommand(tym =>
            {
                TymyService.DeleteTym((Tym)tym);
            });

            LoadData();
        }

        private void LoadData()
        {
            var rows = TymyService.GetAllTymy();
            Tymy.Clear();
            foreach (var tym in rows)
            {
                Tymy.Add(tym);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
