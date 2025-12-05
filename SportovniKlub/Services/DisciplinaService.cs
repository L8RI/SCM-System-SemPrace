using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using SportovniKlub.Repositories;
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
            using var uow = new OracleUnitOfWork(_connectionString);
            var repo = new SportovniDisciplinyRepository(uow);

            var sportovniDisciplina = repo.GetById(disciplinaId);
            return sportovniDisciplina;
        }
    }
}
