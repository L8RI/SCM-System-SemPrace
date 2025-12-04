using SportovniKlub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Interfaces
{
    public interface IOsobyService
    {
        List<Osoba> GetAllOsoby();
    }
}
