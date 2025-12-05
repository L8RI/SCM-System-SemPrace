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
    public class TreninkyViewModel
    {
        public ObservableCollection<Trenink> Treninky { get; set; }

        public ITreninkyService TreninkyService;

        public RelayCommand AddTreninkCommand { get; set; }
        public RelayCommand DeleteTreninkCommand { get; set; }

        public TreninkyViewModel(ITreninkyService treninkyService)
        {
            TreninkyService = treninkyService;
            Treninky = new ObservableCollection<Trenink>();

            AddTreninkCommand = new RelayCommand(trenink =>
            {
                TreninkyService.AddTrenink((Trenink)trenink);
                LoadData();
            });

            DeleteTreninkCommand = new RelayCommand(trenink =>
            {
                TreninkyService.DeleteTrenink((Trenink)trenink);
                LoadData();
            });

            LoadData();
        }

        private void LoadData()
        {
            Treninky.Clear();
            var rows = TreninkyService.GetAllTreninky();
            //Treninky.Clear();
            foreach (var row in rows)
            {
                Treninky.Add(row);
            }
        }
    }
}
