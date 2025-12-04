using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using SportovniKlub.TablesHandlers;

namespace SportovniKlub
{
    //Change the name to OracleDatabaseHandler
    class OracleDatabase : IDatabase
    {
        private readonly string connectionString;

        //public OracleDatabase()
        //{
        //    connectionString = "User Id=st72491;Password=Znahar137273;" +
        //    "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=FEI-SQL3.UPCEUCEBNY.CZ)(PORT=1521))(CONNECT_DATA=(SID=BDAS)));";
        //}

        public IDbConnection GetConnection()
        {
            //var connection = new OracleConnection(connectionString);
            //connection.Open(); // ?
            //return connection;
            throw new NotImplementedException();
        }
    }
}
