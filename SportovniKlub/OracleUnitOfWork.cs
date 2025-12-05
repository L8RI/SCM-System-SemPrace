using Oracle.ManagedDataAccess.Client;
using SportovniKlub.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub
{
    internal class OracleUnitOfWork : IUnitOfWork
    {
        private string _connectionString;

        public IDbConnection Connection { get; }

        public IDbTransaction Transaction { get; }

        public OracleUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
            
            Connection = new OracleConnection(connectionString);
            Connection.Open();
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction?.Commit();
            Dispose();
        }

        public void Dispose()
        {
            Transaction.Dispose();
            Connection.Dispose();
        }

        public void Rollback()
        {
            Transaction?.Rollback();
            Dispose();
        }

        public TResult Execute<TResult>(Func<TResult> func)
        {
            try
            {
                var result = func();
                Commit();
                return result;
            } catch
            {
                Rollback();
                throw;
            }
        }

        public void Execute(Action action)
        {
            try
            {
                action();
                Commit();
            } catch
            {
                Rollback();
                throw;
            }
        }
    }
}
