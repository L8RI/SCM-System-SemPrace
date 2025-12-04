using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Services
{
    public class DisciplinaService : ISportovniDisciplinaService
    {
        private readonly string _connectionString;

        public DisciplinaService(string connectionString) 
        {
            _connectionString = connectionString; 
        }

        public SportovniDisciplina GetById(int disciplinaId)
        {
            throw new NotImplementedException();
        }
    }
}
