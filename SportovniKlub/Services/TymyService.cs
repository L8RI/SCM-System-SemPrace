using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using SportovniKlub.TablesHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Services
{
    public class TymyService : ITymyService
    {
        private readonly string _connectionString;

        public TymyService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Tym> GetAllTymy()
        {
            using var uow = new OracleUnitOfWork(_connectionString);
            var repo = new TymyRepository(uow);

            try
            {
                var data = repo.ShowTymy();
                uow.Commit();
                return data;
            } catch
            {
                uow.Rollback();
                throw;
            }
        }

        public void AddTym(Tym tym)
        {
            using var uow = new OracleUnitOfWork(_connectionString);
            var repo = new TymyRepository(uow);

            try
            {
                repo.AddTym(tym);
                uow.Commit(); 
            }
            catch
            {
                uow.Rollback();
                throw;
            }
        }

        public void DeleteTym(Tym tym)
        {
            using var uow = new OracleUnitOfWork(_connectionString);
            var repo = new TymyRepository(uow);

            try
            {
                repo.DeleteTym(tym);
                uow.Commit();
            }
            catch
            {
                uow.Rollback();
                throw;
            }
        }
    }
}
