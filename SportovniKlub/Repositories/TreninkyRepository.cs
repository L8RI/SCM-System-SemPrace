using Oracle.ManagedDataAccess.Client;
using SportovniKlub.Converters;
using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.TablesHandlers
{
    internal class TreninkyRepository
    {
        private readonly IUnitOfWork _uow;
        private ITreninkMapper _mapper;

        public TreninkyRepository(IUnitOfWork uow)
        {
            _uow = uow;
            //_mapper = mapper;
        }

        public List<Trenink> ShowTreninky()
        {
            var treninky = new List<Trenink>();

            var connection = _uow.Connection;
            using var command = connection.CreateCommand();
            command.Transaction = connection.BeginTransaction();
            command.CommandText = "SELECT * FROM TRENINKY";

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int treninkID = 0;
                    int trenerID = 0;
                    DateTime datum = new DateTime();
                    int sportDisciplinaID = 0;
                    int typTreninkuID = 0;

                    var trenink = _mapper.FromDb(
                        treninkID,
                        trenerID,
                        datum,
                        sportDisciplinaID,
                        typTreninkuID
                    );

                    treninky.Add(trenink);
                }
            }

            return treninky;
        }

        public void AddTrenink(Trenink trenink)
        {
            using var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;

            command.CommandText = @"INSERT INTO TRENINKY (TRENER_ID, DATUM, SPORTOVNI_DISCIPLINA_ID, TYP_TRENINKU_ID) " +
                      $"VALUES (:trenerId, :datum, :disciplinaId, :typTreninkuId)";

            command.Parameters.Add(new OracleParameter("trenerId", trenink.TrenerID));
            command.Parameters.Add(new OracleParameter("datum", trenink.Datum));
            command.Parameters.Add(new OracleParameter("disciplinaId", trenink.SportDisciplina));
            command.Parameters.Add(new OracleParameter("typTreninkuId", trenink.TypTreninkuID));

            command.ExecuteNonQuery();
        }

        public void DeleteTrenink(Trenink trenink)
        {
            using var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;

            command.CommandText = $"DELETE FROM TRENINKY WHERE TRENINK_ID = :treninkId";

            command.Parameters.Add(new OracleParameter("treninkId", trenink.TreninkID));

            command.ExecuteNonQuery();
        }
    }
}
