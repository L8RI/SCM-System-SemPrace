using SportovniKlub.Models;
using SportovniKlub.ModelsDTO;
using System.Collections.Generic;

namespace SportovniKlub.Interfaces
{
    public interface IOsobyService
    {
        List<OsobaDTO> GetAllOsoby();
        void Add(Osoba osoba);
        void Update(Osoba osoba);
        void Delete(int osobaId);
    }
}
