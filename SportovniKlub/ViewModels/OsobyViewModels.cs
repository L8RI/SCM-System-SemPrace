using SportovniKlub.Interfaces;
using SportovniKlub.ModelsDTO;
using System.Collections.ObjectModel;

namespace SportovniKlub.ViewModels
{
    public class OsobyViewModels
    {
        public ObservableCollection<OsobaDTO> Osoby { get; set; }

        public IOsobyService OsobyService { get; set; }

        public RelayCommand AddOsobaCommand { get; set; }
        public RelayCommand DeleteOsobaCommand { get; set; }

        public OsobyViewModels(IOsobyService osobyService)
        {
            OsobyService = osobyService;
            Osoby = new ObservableCollection<OsobaDTO>();

            //AddOsobaCommand = new RelayCommand(osoba =>
            //{
            //    if (osoba is OsobaDTO dto)
            //    {
            //        OsobyService.Add(dto);
            //        LoadData();
            //    }
            //});

            //DeleteOsobaCommand = new RelayCommand(osoba =>
            //{
            //    if (osoba is OsobaDTO dto)
            //    {
            //        OsobyService.Delete(dto);
            //        LoadData();
            //    }
            //});

            LoadData();
        }

        public void LoadData()
        {
            Osoby.Clear();
            var rows = OsobyService.GetAllOsoby();
            foreach (var row in rows)
            {
                Osoby.Add(row);
            }
        }
    }
}
