using SportovniKlub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Interfaces
{
    public interface ITreninkyService
    {
        List<Trenink> GetAllTreninky();

        public void AddTrenink(Trenink trenink);

        public void DeleteTrenink(Trenink trenink);
    }
}
