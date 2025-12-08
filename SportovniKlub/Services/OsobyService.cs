using SportovniKlub.Interfaces;
using SportovniKlub.Mappers;
using SportovniKlub.Models;
using SportovniKlub.ModelsDTO;
using SportovniKlub.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SportovniKlub.Services
{
    public class OsobyService : IOsobyService
    {
        private readonly IUnitOfWork _uow;
        private readonly OsobyRepository _repo;
        private readonly SportovniDisciplinyRepository _disciplinyRepo;
        private readonly IOsobyMapper _mapper;

        public OsobyService(IUnitOfWork uow, OsobyRepository repo, SportovniDisciplinyRepository disciplinyRepo, IOsobyMapper mapper)
        {
            _uow = uow;
            _repo = repo;
            _disciplinyRepo = disciplinyRepo;
            _mapper = mapper;
        }

        public List<OsobaDTO> GetAllOsoby()
        {
            return _uow.Execute(() =>
            {
                var osoby = _repo.GetAll();
                var discipliny = _disciplinyRepo.GetAllDiscipline();

                return osoby.Select(o =>
                    _mapper.ToDTO(o, discipliny.First(d => d.SportovniDisciplinaId == o.SportovniDisciplinaId).Nazev)
                ).ToList();
            });
        }

        public void Add(Osoba osoba) => _uow.Execute(() => _repo.Add(osoba));
        public void Update(Osoba osoba) => _uow.Execute(() => _repo.Update(osoba));
        public void Delete(int osobaId) => _uow.Execute(() => _repo.Delete(osobaId));
    }
}
