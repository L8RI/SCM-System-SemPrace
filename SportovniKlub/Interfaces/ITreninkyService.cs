using SportovniKlub.Models;
using SportovniKlub.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Interfaces
{
    public interface ITreninkyService
    {
        List<TreninkDTO> GetAllTreninky();

        public void AddTrenink(Trenink trenink);

        public void DeleteTrenink(Trenink trenink);
    }
}
