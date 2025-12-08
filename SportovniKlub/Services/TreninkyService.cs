using Oracle.ManagedDataAccess.Client;
using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using SportovniKlub.ModelsDTO;
using SportovniKlub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SportovniKlub.Services
{
    public class TreninkyService : ITreninkyService
    {
        private readonly IUnitOfWork _uow;
        private readonly TreninkyRepository _repo;
        private readonly SportovniDisciplinyRepository _disciplinaRepo;
        private readonly ITreninkMapper _treninkMapper;

        public TreninkyService(IUnitOfWork uow, TreninkyRepository repo, ITreninkMapper treninkMapper, SportovniDisciplinyRepository disciplinaRepo)
        {
            _uow = uow;
            _repo = repo;
            _treninkMapper = treninkMapper;
            _disciplinaRepo = disciplinaRepo;
        }

        public List<TreninkDTO> GetAllTreninky()
        {
            var treninky = _repo.ShowTreninky();
            var discipliny = _disciplinaRepo.GetAllDiscipline().ToDictionary(d => d.SportovniDisciplinaId);

            //foreach (var t in treninky)
            //{
            //    if (discipliny.TryGetValue(t.SportDisciplinaId, out var d))
            //        t.SportDisciplina = d;
            //}

            //return treninky.Select(t => _treninkMapper.ToDTO(t)).ToList();
            return null;
        }


        public void AddTrenink(Trenink trenink)
        {
            _uow.Execute(() => _repo.AddTrenink(trenink));
        }

        public void DeleteTrenink(Trenink trenink)
        {
            _uow.Execute(() => _repo.DeleteTrenink(trenink));
        }
    }
}
