using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using SportovniKlub.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Mappers
{
    internal class TymyMapper : ITymyMapper
    {
        public TymDTO ToDTO(Tym tym)
        {
            return new TymDTO(
                tym.TymID,
                tym.NazevTymu,
                tym.PocetHracu,
                tym.Plat,
                tym.PocetTrofeju,
                tym.VyseOdmen,
                tym.SportovniDisciplina?.Nazev ?? "",
                tym.Sponzor?.Nazev ?? "",
                tym.Trener?.Prijmeni ?? ""
            );
        }


        public Tym ToEntity(TymDTO tym)
        {
            throw new NotImplementedException();
        }
    }
}
