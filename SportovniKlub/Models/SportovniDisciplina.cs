using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Models
{
    public class SportovniDisciplina
    {
        public int SportovniDisciplinaId { get; set; }
        public string Nazev { get; set; }

        public SportovniDisciplina(int sportovniDisciplinaId, string nazev)
        {
            SportovniDisciplinaId = sportovniDisciplinaId;
            Nazev = nazev;
        }
    }
}
