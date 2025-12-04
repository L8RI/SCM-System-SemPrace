using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Models
{
    public class Tym
    {
        public int TymID { get; set; }
        public string NazevTymu { get; set; }
        public int PocetHracu { get; set; }
        public decimal Plat { get; set; }
        public int PocetTrofeju { get; set; }
        public decimal VyseOdmen { get; set; }
        public int SportovniDisciplinaID { get; set; }
        public int? SponzorID { get; set; }
        public int TrenerID { get; set; }

        public Tym(int tymID, string nazevTymu, int pocetHracu, decimal plat, int pocetTrofeju, decimal vyseOdmen, int sportovniDisciplinaID, int? sponzorID, int trenerID)
        {
            TymID = tymID;
            NazevTymu = nazevTymu;
            PocetHracu = pocetHracu;
            Plat = plat;
            PocetTrofeju = pocetTrofeju;
            VyseOdmen = vyseOdmen;
            SportovniDisciplinaID = sportovniDisciplinaID;
            SponzorID = sponzorID;
            TrenerID = trenerID;
        }
    }
}
