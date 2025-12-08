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
        public SportovniDisciplina SportovniDisciplina { get; set; }
        public Sponzor? Sponzor { get; set; }
        public Trener Trener { get; set; }
        public int SportovniDisciplinaId {  get; set; }
        public int? SponzorId { get; set; }
        public int TrenerId { get; set; }

        public Tym(int tymID, string nazevTymu, int pocetHracu, decimal plat, int pocetTrofeju, decimal vyseOdmen, int sportovniDisciplinaId, int? sponzorId, int trenerId)
        {
            TymID = tymID;
            NazevTymu = nazevTymu;
            PocetHracu = pocetHracu;
            Plat = plat;
            PocetTrofeju = pocetTrofeju;
            VyseOdmen = vyseOdmen;
            SportovniDisciplinaId = sportovniDisciplinaId;
            SponzorId = sponzorId;
            TrenerId = trenerId;
        }

        public Tym(int tymID, string nazevTymu, int pocetHracu, decimal plat, int pocetTrofeju, decimal vyseOdmen, SportovniDisciplina sportovniDisciplina, Sponzor? sponzor, Trener trener)
        {
            TymID = tymID;
            NazevTymu = nazevTymu;
            PocetHracu = pocetHracu;
            Plat = plat;
            PocetTrofeju = pocetTrofeju;
            VyseOdmen = vyseOdmen;
            SportovniDisciplina = sportovniDisciplina;
            Sponzor = sponzor;
            Trener = trener;
        }
    }
}
