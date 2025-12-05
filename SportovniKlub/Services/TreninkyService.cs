using Oracle.ManagedDataAccess.Client;
using SportovniKlub.Converters;
using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using SportovniKlub.TablesHandlers;
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
        private readonly TreninkMapper _mapper;
        private readonly ISportovniDisciplinaService _discService;

        public TreninkyService(IUnitOfWork uow, TreninkyRepository repo, TreninkMapper mapper, ISportovniDisciplinaService discService)
        {
            _uow = uow;
            _repo = repo;
            _mapper = mapper;
            _discService = discService;
        }

        public List<Trenink> GetAllTreninky()
        {
            return _uow.Execute(() => _repo.ShowTreninky());
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
