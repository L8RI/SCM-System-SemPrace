using SportovniKlub.Models;
using SportovniKlub.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Interfaces
{
    public interface ITypyTreninkuService
    {
        List<TypTreninku> GetAllTypyTreninku();
        TypTreninku GetById(int typTreninkuId);
        TypTreninku GetByName(string name);

        //public void AddTypyTreninku(TypTreninku typTreninku);

        //public void DeleteTypTreninku(TypTreninku typTreninku);
    }
}
