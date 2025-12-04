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
        int TrenerId { get; set; }
        int Zkusenot { get; set; }
        public Trener() 
        {
            TypOsoby = 'T';
        }
    }
}
