using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using SportovniKlub.ModelsDTO;

namespace SportovniKlub.Mappers
{
    public class OsobyMapper : IOsobyMapper
    {
        public OsobaDTO ToDTO(Osoba osoba, string sportovniDisciplinaNazev)
        {
            return new OsobaDTO(
                osoba.OsobaId,
                osoba.Jmeno,
                osoba.Prijmeni,
                osoba.DatumNarozeni,
                osoba.Mail,
                osoba.TypOsoby,
                sportovniDisciplinaNazev
            );
        }

        public Osoba ToEntity(OsobaDTO dto, int sportovniDisciplinaId)
        {
            return new Osoba(
                dto.OsobaId,
                dto.Jmeno,
                dto.Prijmeni,
                dto.DatumNarozeni,
                dto.Mail,
                dto.TypOsoby,
                sportovniDisciplinaId
            );
        }
    }
}
