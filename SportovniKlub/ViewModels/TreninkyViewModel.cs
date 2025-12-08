using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using SportovniKlub.ModelsDTO;
using SportovniKlub.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SportovniKlub.ViewModels
{
    public class TreninkyViewModel
    {
        public ObservableCollection<TreninkDTO> Treninky { get; set; }

        private readonly ITreninkyService _treninkyService;

        private readonly IMessageService _messageService;

        public INavigationService NavigationService;
        //public ObservableCollection<SportovniDisciplina> SportovniDiscipliny { get; set; }
        //public SportovniDisciplina VybranaDisciplina { get; set; }
        //public ObservableCollection<Trener> Treneri { get; set; }
        //public Trener VybranyTrener { get; set; }
        //public ObservableCollection<TypTreninku> TypyTreninku { get; set; }
        //public TypTreninku VybranyTypTreninku { get; set; }

        //public RelayCommand AddTreninkCommand { get; set; }
        //public RelayCommand DeleteTreninkCommand { get; set; }
        public RelayCommand ShowAddTreninkWindowCommand { get; }

        public TreninkyViewModel(ITreninkyService treninkyService, INavigationService navigationService, IMessageService messageService)
        {
            _treninkyService = treninkyService;
            NavigationService = navigationService;
            _messageService = messageService;
            Treninky = new ObservableCollection<TreninkDTO>();
            //SportovniDiscipliny = new ObservableCollection<SportovniDisciplina>(sportovniDisciplinaService.GetAllDiscipliny());
            //Treneri = new ObservableCollection<Trener>(treneriService.GetAllTreneri());
            //TypyTreninku = new ObservableCollection<TypTreninku>(typyTreninkuService.GetAllTypyTreninku());

            //AddTreninkCommand = new RelayCommand(trenink =>
            //{
            //    TreninkyService.AddTrenink((Trenink)trenink);
            //    LoadData();
            //});

            //DeleteTreninkCommand = new RelayCommand(trenink =>
            //{
            //    TreninkyService.DeleteTrenink((Trenink)trenink);
            //    LoadData();
            //});

            ShowAddTreninkWindowCommand = new RelayCommand(trenink =>
            {
                NavigationService.ShowAddTreninkWindow();
            });

            //LoadData();
        }

        public async Task InitializeAsync()
        {
            //var data = await _treninkyService.GEtA
        }

        //private void LoadData()
        //{
        //    Treninky.Clear();
        //    var rows = TreninkyService.GetAllTreninky();
        //    foreach (var row in rows)
        //    {
        //        Treninky.Add(row);
        //    }
        //}
    }
}
