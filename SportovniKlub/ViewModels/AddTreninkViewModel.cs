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
    public class AddTreninkViewModel
    {
        public Action CloseAction { get; set; }

        public ObservableCollection<Trener> Treneri { get; }
        public Trener VybranyTrener { get; set; }

        public ObservableCollection<SportovniDisciplina> SportovniDiscipliny { get; }
        public SportovniDisciplina VybranaDisciplina { get; set; }

        public ObservableCollection<TypTreninku> TypyTreninku { get; }
        public TypTreninku VybranyTypTreninku { get; set; }

        public DateTime? Datum { get; set; }

        public RelayCommand SaveCommand { get; }
        public RelayCommand CloseWindowCommand { get; }

        private readonly ITreninkyService _service;

        private readonly IMessageService _messageService;

        public AddTreninkViewModel(
            ITreninkyService service,
            IMessageService messageService,
            ITreneriService treneriService,
            ISportovniDisciplinaService disciplinaService,
            ITypyTreninkuService typyService)
        {
            _service = service;
            _messageService = messageService;

            Treneri = new(treneriService.GetAllTreneri());
            SportovniDiscipliny = new(disciplinaService.GetAllDiscipliny());
            TypyTreninku = new(typyService.GetAllTypyTreninku());

            SaveCommand = new RelayCommand(_ => Save());
            CloseWindowCommand = new RelayCommand(_ => Close());
        }

        private void Close()
        {
            CloseAction?.Invoke();
        }

        private void Save()
        {
            try
            {
                //var trenink = new Trenink(
                //    VybranyTrener?.TrenerId ?? 0,
                //    Datum ?? DateTime.Now,
                //    VybranaDisciplina?.SportovniDisciplinaId ?? 0,
                //    VybranyTypTreninku?.Id ?? 0
                //);

                var trenink = new Trenink(2, DateTime.Now, 1, 1);


                _service.AddTrenink(trenink);
            }
            catch (Exception ex)
            {
                _messageService.ShowMessage(ex.Message);
            }

            Close();
        }
    }
}
