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
    internal class TreneriService : ITreneriService
    {
        private readonly IUnitOfWork _uow;
        private readonly TreneriRepository _treneriRepository;

        public TreneriService(IUnitOfWork uow, TreneriRepository treneriRepository)
        {
            _uow = uow;
            _treneriRepository = treneriRepository;
        }

        public List<Trener> GetAllTreneri()
        {
            return _uow.Execute(() =>
            {
                var treneri = _treneriRepository.GetAllTreneri();
                return treneri;
            });
        }

        public Trener GetById(int trenerId)
        {
            return _uow.Execute(() =>
            {
                var treneri = _treneriRepository.GetAllTreneri();

                return _treneriRepository.GetById(trenerId);
            });
        }

        public Trener GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
