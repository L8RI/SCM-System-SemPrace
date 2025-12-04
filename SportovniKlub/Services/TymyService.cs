using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using SportovniKlub.TablesHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Services
{
    public class TymyService : ITymyService
    {
        private TymyRepository tymyHandler;

        public TymyService(IDatabase db)
        {
            tymyHandler = new TymyRepository(db);
        }

        public List<Tym> GetAllTymy()
        {
            return tymyHandler.ShowTymy();
        }

        public void AddTym(Tym tym)
        {            
            tymyHandler.AddTym(tym);
        }

        public void DeleteTym(Tym tym)
        {
            tymyHandler.DeleteTym(tym);
        }
    }
}
