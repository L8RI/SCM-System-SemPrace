using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using SportovniKlub.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SportovniKlub.Converters
{
    public class TreninkMapper : ITreninkMapper
    {
        private readonly ISportovniDisciplinaService disciplinaService;

        public TreninkMapper(ISportovniDisciplinaService disciplinaService)
        {
            this.disciplinaService = disciplinaService;
        }

        public Trenink FromDb(int treninkId, int trenerId, DateTime datum,
                              int disciplinaId, int typTreninkuId)
        {
            var disciplina = disciplinaService.GetById(disciplinaId);

            return new Trenink(
                treninkId,
                trenerId,
                datum,
                disciplina,
                typTreninkuId
            );
        }

        public int ToDisciplinaId(SportovniDisciplina disciplina)
        {
            return disciplina.SportovniDisciplinaId;
        }
    }
}
