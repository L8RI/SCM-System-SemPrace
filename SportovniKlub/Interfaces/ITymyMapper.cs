using SportovniKlub.Models;
using SportovniKlub.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Interfaces
{
    public interface ITymyMapper
    {
        public TymDTO ToDTO(Tym tym);

        public Tym ToEntity(TymDTO tym);
    }
}
