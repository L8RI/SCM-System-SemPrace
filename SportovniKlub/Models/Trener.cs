using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
TRENER_ID NOT NULL NUMBER(38) 
ZKUSENOST NOT NULL NUMBER(38) 
*/

namespace SportovniKlub.Models
{
    public class Trener : Osoba
    {
        public int TrenerId { get; set; }
        public int Zkusenost { get; set; }



        public Trener(int trenerId, string jmeno, string prijmeni, int zkusenost)
        {
            TrenerId = trenerId;
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            Zkusenost = zkusenost;
        }
    }
}
