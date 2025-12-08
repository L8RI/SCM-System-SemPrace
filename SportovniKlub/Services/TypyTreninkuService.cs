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
    public class TypyTreninkuService : ITypyTreninkuService
    {
        private readonly IUnitOfWork _uow;
        private readonly TypyTreninkuRepository _repository;

        public TypyTreninkuService(IUnitOfWork uow, TypyTreninkuRepository repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public List<TypTreninku> GetAllTypyTreninku()
        {
            return _uow.Execute(() =>
            {
                var typyTreninku = _repository.GetAllTypyTreninku();
                return typyTreninku;
            });
        }

        public TypTreninku GetById(int typTreninkuId)
        {
            throw new NotImplementedException();
        }

        public TypTreninku GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
