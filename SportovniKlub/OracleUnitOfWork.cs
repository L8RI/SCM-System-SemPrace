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

        public IDbTransaction Transaction { get; private set;  }

        public OracleUnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
            
            Connection = new OracleConnection(connectionString);
            Connection.Open();
            //Transaction = Connection.BeginTransaction();
        }

        public void BeginTransaction()
        {
            if (Transaction == null)
            {
                Transaction = Connection.BeginTransaction();
            }
        }

        public void Commit()
        {
            if (Transaction == null) return;

            Transaction?.Commit();
            Transaction?.Dispose();
            Transaction = null;
        }

        public void Rollback()
        {
            if (Transaction == null) return;

            Transaction?.Rollback();
            Transaction?.Dispose();
            Transaction = null;
        }

        public TResult Execute<TResult>(Func<TResult> func)
        {
            BeginTransaction();
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
            BeginTransaction();
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

        public void Dispose()
        {
            Transaction?.Dispose();
            Transaction = null;
            Connection?.Dispose();
        }
    }
}
