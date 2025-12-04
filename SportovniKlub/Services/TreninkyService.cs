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
    public class TreninkyService : ITreninkyService
    {
        private TreninkyRepository treninkyHandler;

        public TreninkyService(IDatabase db)
        {
            treninkyHandler = new TreninkyRepository(db);
        }

        public List<Trenink> GetAllTreninky()
        {
            return treninkyHandler.ShowTreninky();
        }

        public void AddTrenink(Trenink trenink)
        {
            treninkyHandler.AddTrenink(trenink);
        }

        public void DeleteTrenink(Trenink trenink)
        {
            treninkyHandler.DeleteTrenink(trenink);
        }
    }
}
