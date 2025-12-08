using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using SportovniKlub.ModelsDTO;
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
        private readonly IUnitOfWork _uow;
        private readonly SportovniDisciplinyRepository _repo;
        
        public DisciplinaService(IUnitOfWork uow, SportovniDisciplinyRepository repo) 
        {
            _repo = repo;
            _uow = uow;
        }

        public List<SportovniDisciplina> GetAllDiscipliny()
        {
            return _uow.Execute(() =>
            {
                var sportovniDiscipliny = _repo.GetAllDiscipline();
                return sportovniDiscipliny;
            });
        }

        public SportovniDisciplina GetById(int disciplinaId)
        {
            return _uow.Execute(() =>
            {
                var sportovniDisciplina = _repo.GetById(disciplinaId);
                return sportovniDisciplina;
            });
        }

        public SportovniDisciplina GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
