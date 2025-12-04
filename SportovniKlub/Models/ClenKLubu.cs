using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Models
{
    public class ClenKlubu : Osoba
    {
        public int ClenKlubuId { get; set; }
        public DateTime DatumRegistrace { get; set; }
        public int? TymId { get; set; }
        public int Body { get; set; }

        public ClenKlubu(int clenKlubuId, DateTime datumRegistrace, int? tymId, int body)
        {
            ClenKlubuId = clenKlubuId;
            DatumRegistrace = datumRegistrace;
            TymId = tymId;
            Body = body;
            TypOsoby = 'C';
        }

        public ClenKlubu()
        {
            TypOsoby = 'C';
        }

        public override string ToString()
        {
            return $"{ClenKlubuId} | {DatumRegistrace:d} | {TymId?.ToString() ?? ""} | {Body}";
        }
    }
}
