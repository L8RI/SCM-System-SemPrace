using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Models
{
    public class Trenink
    {
        public int TreninkID { get; set; }
        public int TrenerID { get; set; }
        public DateTime Datum { get; set; }
        public int SportDisciplinaId { get; set; }
        public SportovniDisciplina SportDisciplina { get; set; }
        public int TypTreninkuID { get; set; }

        public Trenink(int trenerID, DateTime datum, int sportDisciplinaId, int typTreninkuID)
        {
            TrenerID = trenerID;
            Datum = datum;
            SportDisciplinaId = sportDisciplinaId;
            TypTreninkuID = typTreninkuID;
        }

        public Trenink(int treninkID, int trenerID, DateTime datum, int sportDisciplinaId, int typTreninkuID)
        {
            TreninkID = treninkID;
            TrenerID = trenerID;
            Datum = datum;
            SportDisciplinaId = sportDisciplinaId;
            TypTreninkuID = typTreninkuID;
        }

        public Trenink(int treninkID, int trenerID, DateTime datum, SportovniDisciplina sportDisciplina, int typTreninkuID)
        {
            TreninkID = treninkID;
            TrenerID = trenerID;
            Datum = datum;
            SportDisciplina = sportDisciplina;
            TypTreninkuID = typTreninkuID;
        }
    }
}
