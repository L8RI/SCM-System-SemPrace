using Oracle.ManagedDataAccess.Client;
using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Repositories
{
    public class TypyTreninkuRepository
    {
        private readonly IUnitOfWork _uow;

        public TypyTreninkuRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public TypTreninku GetById(int id)
        {
            var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;
            command.CommandText = "SELECT * FROM TYPY_TRENINKU WHERE TYP_TRENINKU_ID = :id";

            command.Parameters.Add(new OracleParameter("id", id));

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int typTreninkuId = reader.GetInt32(reader.GetOrdinal("TYP_TRENINKU_ID"));
                string nazev = reader.GetString(reader.GetOrdinal("NAZEV"));

                return new TypTreninku(typTreninkuId, nazev);
            }

            return null;
        }

        public List<TypTreninku> GetAllTypyTreninku()
        {
            List<TypTreninku> treninky = new List<TypTreninku>();

            var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;
            command.CommandText = "SELECT * FROM TYPY_TRENINKU";

            using (var reader = command.ExecuteReader())
                while (reader.Read())
                {
                    int id = reader.GetInt32(reader.GetOrdinal("TYP_TRENINKU_ID"));
                    string nazev = reader.GetString(reader.GetOrdinal("NAZEV"));

                    treninky.Add(new TypTreninku(id, nazev));
                }

            return treninky;
        }
    }
}
