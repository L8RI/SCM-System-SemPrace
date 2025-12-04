using Oracle.ManagedDataAccess.Client;
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
        //private TreninkyRepository treninkyHandler;
        private readonly string _connectionString;

        public TreninkyService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Trenink> GetAllTreninky()
        {
            using var uow = new OracleUnitOfWork(_connectionString);
            var repo = new TreninkyRepository(uow);

            try
            {
                var data = repo.ShowTreninky();
                uow.Commit();
                return data;
            } catch
            {
                uow.Rollback();
                throw;
            }
        }

        public void AddTrenink(Trenink trenink)
        {
            using var uow = new OracleUnitOfWork(_connectionString);
            var repo = new TreninkyRepository(uow);

            try
            {
                repo.AddTrenink(trenink);
                uow.Commit();
            }
            catch
            {
                uow.Rollback();
                throw;
            }
        }

        public void DeleteTrenink(Trenink trenink)
        {
            using var uow = new OracleUnitOfWork(_connectionString);
            var repo = new TreninkyRepository(uow);

            try
            {
                repo.DeleteTrenink(trenink);
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
