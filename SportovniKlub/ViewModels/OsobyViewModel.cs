using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using SportovniKlub.ModelsDTO;
using SportovniKlub.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SportovniKlub.ViewModels
{
    public class OsobyViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<OsobaDTO> Osoby { get; set; }
        public IOsobyService OsobyService { get; set; }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        public OsobyViewModel(IOsobyService service)
        {
            OsobyService = service;
            Osoby = new ObservableCollection<OsobaDTO>();

            AddCommand = new RelayCommand(o => OsobyService.Add((Osoba)o));
            UpdateCommand = new RelayCommand(o => OsobyService.Update((Osoba)o));
            DeleteCommand = new RelayCommand(o =>
            {
                if (o is OsobaDTO dto) OsobyService.Delete(dto.OsobaId);
            });

            LoadData();
        }

        private void LoadData()
        {
            var rows = OsobyService.GetAllOsoby();
            Osoby.Clear();
            foreach (var o in rows)
            {
                Osoby.Add(o);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
