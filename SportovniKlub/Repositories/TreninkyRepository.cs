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
    public class TreninkyRepository
    {
        private readonly IUnitOfWork _uow;

        public TreninkyRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Trenink>> ShowTreninky()
        {
            var treninky = new List<Trenink>();

            using var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;
            command.CommandText = "SELECT * FROM TRENINKY";

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                int treninkID = reader.GetInt32(reader.GetOrdinal("TRENINK_ID"));
                int trenerID = reader.GetInt32(reader.GetOrdinal("TRENER_ID"));
                DateTime datum = reader.GetDateTime(reader.GetOrdinal("DATUM"));
                int disciplinaId = reader.GetInt32(reader.GetOrdinal("SPORTOVNI_DISCIPLINA_ID"));
                int typ = reader.GetInt32(reader.GetOrdinal("TYP_TRENINKU_ID"));

                treninky.Add(new Trenink(
                        treninkID,
                        trenerID,
                        datum,
                        disciplinaId,
                        typ
                        )
                );
            }

            //return await treninky.ToListAsync();
            return null;
        }

        public void AddTrenink(Trenink trenink)
        {
            using var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;

            command.CommandText =
                @"INSERT INTO TRENINKY (TRENER_ID, DATUM, SPORTOVNI_DISCIPLINA_ID, TYP_TRENINKU_ID)
              VALUES (:trenerId, :datum, :disciplinaId, :typTreninkuId)";

            command.Parameters.Add(new OracleParameter("trenerId", trenink.TrenerID));
            command.Parameters.Add(new OracleParameter("datum", trenink.Datum));
            command.Parameters.Add(new OracleParameter("disciplinaId", trenink.SportDisciplinaId));
            command.Parameters.Add(new OracleParameter("typTreninkuId", trenink.TypTreninkuID));

            command.ExecuteNonQuery();
        }

        public void DeleteTrenink(Trenink trenink)
        {
            using var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;

            command.CommandText =
                @"DELETE FROM TRENINKY WHERE TRENINK_ID = :id";

            command.Parameters.Add(new OracleParameter("id", trenink.TreninkID));

            command.ExecuteNonQuery();
        }
    }
}
