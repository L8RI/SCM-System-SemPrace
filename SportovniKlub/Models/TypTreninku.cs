using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Models
{
    public class TypTreninku
    {
        public int Id { get; set; }
        public string Nazev { get; set; }

        public TypTreninku(int id, string nazev)
        {
            Id = id;
            Nazev = nazev;
        }
    }
}
