using SportovniKlub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Interfaces
{
    public interface ITymyService
    {
        List<Tym> GetAllTymy();

        public void AddTym(Tym tym);

        public void DeleteTym(Tym tym);
    }
}
