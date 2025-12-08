using System;

namespace SportovniKlub.ModelsDTO
{
    public class OsobaDTO
    {
        public int OsobaId { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public DateTime DatumNarozeni { get; set; }
        public string Mail { get; set; }
        public char TypOsoby { get; set; }
        public string SportovniDisciplinaNazev { get; set; }

        public OsobaDTO(int osobaId, string jmeno, string prijmeni, DateTime datumNarozeni, string mail, char typOsoby, string sportovniDisciplinaNazev)
        {
            OsobaId = osobaId;
            Jmeno = jmeno;
            Prijmeni = prijmeni;
            DatumNarozeni = datumNarozeni;
            Mail = mail;
            TypOsoby = typOsoby;
            SportovniDisciplinaNazev = sportovniDisciplinaNazev;
        }
    }
}
