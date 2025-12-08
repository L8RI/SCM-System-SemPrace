using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.ModelsDTO
{
    public class TreninkDTO
    {
        public int TreninkID { get; set; }
        public int TrenerID { get; set; }
        public DateTime Datum { get; set; }
        public string Disciplina { get; set; }     
        public int TypTreninkuID { get; set; }

        //public TreninkDTO(int treninkID, int trenerID, DateTime datum, string disciplina, int typTreninkuID)
        //{
        //    TreninkID = treninkID;
        //    TrenerID = trenerID;
        //    Datum = datum;
        //    Disciplina = disciplina;
        //    TypTreninkuID = typTreninkuID;
        //}
    }
}
