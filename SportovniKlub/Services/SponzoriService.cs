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
    public class SponzoriService : ISponzoriService
    {
        private readonly IUnitOfWork _uow;
        private readonly SponzoriRepository _sponzoriRepository;

        public SponzoriService(IUnitOfWork uow, SponzoriRepository sponzoriRepository)
        {
            _uow = uow;
            _sponzoriRepository = sponzoriRepository;
        }

        public Sponzor GetById(int sponzorId)
        {
            return _uow.Execute(() =>
            {
                var sponzori = _sponzoriRepository.GetAllSponzori();

                return _sponzoriRepository.GetById(sponzorId);
            });
        }

        public Sponzor GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
