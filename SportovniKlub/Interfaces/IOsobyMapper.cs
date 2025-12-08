using SportovniKlub.Models;
using SportovniKlub.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Interfaces
{
    public interface IOsobyMapper
    {
        public OsobaDTO ToDTO(Osoba osoba, string sportovniDisciplinaNazev);

        public Osoba ToEntity(OsobaDTO dto, int sportovniDisciplinaId);
    }
}
