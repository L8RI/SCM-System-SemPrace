using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.ViewModels
{
    public class OsobyViewModels
    {
        public ObservableCollection<Osoba> Osoby { get; set; } 

        public IOsobyService OsobyService { get; set; }

        public OsobyViewModels(IOsobyService osobyService) 
        {
            OsobyService = osobyService;
            Osoby = new ObservableCollection<Osoba>();

            LoadData();
        }

        public void LoadData()
        {
            var rows = OsobyService.GetAllOsoby();
            foreach (var row in rows)
            {
                Osoby.Add(row);
            }
        }
    }
}
