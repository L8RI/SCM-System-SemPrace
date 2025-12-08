using System;

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
