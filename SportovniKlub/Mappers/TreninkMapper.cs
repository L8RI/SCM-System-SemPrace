using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using SportovniKlub.ModelsDTO;
using SportovniKlub.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SportovniKlub.Mappers
{
    public class TreninkMapper : ITreninkMapper
    {
        public TreninkDTO ToDTO(Trenink trenink)
        {
            return new TreninkDTO
            {
                TreninkID = trenink.TreninkID,
                TrenerID = trenink.TrenerID,
                Datum = trenink.Datum,
                Disciplina = trenink.SportDisciplina?.Nazev ?? "Chyba",
                TypTreninkuID = trenink.TypTreninkuID
            };
        }

        public Trenink ToEntity(TreninkDTO dto, SportovniDisciplina disciplina)
        {
            return new Trenink(
                dto.TreninkID,
                dto.TrenerID,
                dto.Datum,
                disciplina,
                dto.TypTreninkuID
            );
        }
    }

}
