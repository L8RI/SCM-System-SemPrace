using SportovniKlub.Models;
using SportovniKlub.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Interfaces
{
    public interface ISportovniDisciplinaService
    {
        List<SportovniDisciplina> GetAllDiscipliny();
        SportovniDisciplina GetById(int disciplinaId);
        SportovniDisciplina GetByName(string name);
    }
}
