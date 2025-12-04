using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
OSOBA_ID                NOT NULL NUMBER(38)    
JMENO                   NOT NULL VARCHAR2(50)  
PRIJMENI                NOT NULL VARCHAR2(50)  
DATUM_NAROZENI          NOT NULL DATE          
MAIL                    NOT NULL VARCHAR2(100) 
TYPOSOBY                NOT NULL CHAR(1)       
SPORTOVNI_DISCIPLINA_ID NOT NULL NUMBER     
*/

namespace SportovniKlub.Models
{
    public class Osoba
    {
        public int OsobaId { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public DateTime DatumNarozeni { get; set; }
        public string Mail { get; set; }
        public char TypOsoby { get; set; }
        public int SportovniDisciplinaId { get; set; }

        public Osoba(int osobaId, string jmeno, string prijmeni, DateTime datumNarozeni, string mail, char typOsoby, int sportovniDisciplinaId)
        {
            OsobaId = osobaId;
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            DatumNarozeni = datumNarozeni;
            Mail = mail;
            TypOsoby = typOsoby;
            SportovniDisciplinaId = sportovniDisciplinaId;
        }

        public Osoba() { }
    }

}
