using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.ModelsDTO
{
    public class TymDTO
    {
        public int TymID { get; set; }
        public string NazevTymu { get; set; }
        public int PocetHracu { get; set; }
        public decimal Plat { get; set; }
        public int PocetTrofeju { get; set; }
        public decimal VyseOdmen { get; set; }
        public string SportovniDisciplinaNazev { get; set; }
        public string? SponzorNazev { get; set; }
        public string TrenerPrijmeni { get; set; }

        public TymDTO(int tymID, string nazevTymu, int pocetHracu, decimal plat, int pocetTrofeju, decimal vyseOdmen, string sportovniDisciplinaNazev, string? sponzorNazev, string trenerPrijmeni)
        {
            TymID = tymID;
            NazevTymu = nazevTymu;
            PocetHracu = pocetHracu;
            Plat = plat;
            PocetTrofeju = pocetTrofeju;
            VyseOdmen = vyseOdmen;
            SportovniDisciplinaNazev = sportovniDisciplinaNazev;
            SponzorNazev = sponzorNazev;
            TrenerPrijmeni = trenerPrijmeni;
        }
    }
}
