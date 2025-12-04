using SportovniKlub.Models;
using SportovniKlub.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Interfaces
{
    public interface ITreninkMapper
    {
        Trenink FromDb(int treninkId, int trenerId, DateTime datum,
                       int disciplinaId, int typTreninkuId);
    }

}
