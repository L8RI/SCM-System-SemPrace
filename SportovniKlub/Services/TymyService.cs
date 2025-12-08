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
    public class TymyService : ITymyService
    {
        private readonly IUnitOfWork _uow;
        private readonly TymyRepository _repo;
        private readonly SportovniDisciplinyRepository _sportovniDisciplinyRepository;
        private readonly TreneriRepository _treneriRepo;
        private readonly SponzoriRepository _sponzoriRepo;
        private readonly ITymyMapper _tymyMapper;

        public TymyService(IUnitOfWork uow, TymyRepository repo, TreneriRepository treneriRepo,
            SponzoriRepository sponzoriRepo, SportovniDisciplinyRepository sportovniDiscipliny,
            ITymyMapper mapper)
        {
            _uow = uow;
            _repo = repo;
            _treneriRepo = treneriRepo;
            _sponzoriRepo = sponzoriRepo;
            _sportovniDisciplinyRepository = sportovniDiscipliny;
            _tymyMapper = mapper;
        }

        public List<TymDTO> GetAllTymy()
        {
            return _uow.Execute(() =>
            {
                var tymy = _repo.ShowTymy();
                var discipliny = _sportovniDisciplinyRepository.GetAllDiscipline();
                var treneri = _treneriRepo.GetAllTreneri();
                var sponzori = _sponzoriRepo.GetAllSponzori();

                foreach (var tym in tymy)
                {
                    tym.SportovniDisciplina = discipliny.FirstOrDefault(d => d.SportovniDisciplinaId == tym.SportovniDisciplinaId);
                    tym.Sponzor = sponzori.FirstOrDefault(s => s.SponzorId == tym.SponzorId);
                    tym.Trener = treneri.FirstOrDefault(t => t.TrenerId == tym.TrenerId);
                }

                return tymy.Select(t => _tymyMapper.ToDTO(t)).ToList();
            });
        }

        public void AddTym(Tym tym)
        {
            //using var uow = new OracleUnitOfWork(_connectionString);
            //var repo = new TymyRepository(uow);

            //try
            //{
            //    repo.AddTym(tym);
            //    uow.Commit(); 
            //}
            //catch
            //{
            //    uow.Rollback();
            //    throw;
            //}
            throw new NotImplementedException();
        }

        public void DeleteTym(Tym tym)
        {
            //using var uow = new OracleUnitOfWork(_connectionString);
            //var repo = new TymyRepository(uow);

            //try
            //{
            //    repo.DeleteTym(tym);
            //    uow.Commit();
            //}
            //catch
            //{
            //    uow.Rollback();
            //    throw;
            //}
            throw new NotImplementedException();
        }
    }
}
