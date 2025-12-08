using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Models
{
    public class Sponzor
    {
        public int SponzorId { get; set; }

        public string Nazev { get; set; }

        public Sponzor(int sponzorId, string nazev)
        {
            SponzorId = sponzorId;
            Nazev = nazev;
        }
    }
}
