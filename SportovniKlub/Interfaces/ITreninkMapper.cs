using SportovniKlub.Models;
using SportovniKlub.ModelsDTO;
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
        public TreninkDTO ToDTO(Trenink trenink);

        public Trenink ToEntity(TreninkDTO dto, SportovniDisciplina disciplina);
    }

}
