using Oracle.ManagedDataAccess.Client;
using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using System;
using System.Collections.Generic;

namespace SportovniKlub.Repositories
{
    public class SportovniDisciplinyRepository
    {
        private readonly IUnitOfWork _uow;

        public SportovniDisciplinyRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public SportovniDisciplina GetById(int id)
        {
            var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;
            command.CommandText = "SELECT SPORTOVNI_DISCIPLINA_ID, NAZEV " +
                "FROM SPORTOVNI_DISCIPLINY WHERE SPORTOVNI_DISCIPLINA_ID = :id";

            command.Parameters.Add(new OracleParameter("id", id));

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int disciplinaId = reader.GetInt32(0);
                string nazev = reader.GetString(1);

                return new SportovniDisciplina(disciplinaId, nazev);
            }
                
            return null;
        }

        public List<SportovniDisciplina> GetAllDiscipline()
        {
            var disciplines = new List<SportovniDisciplina>();

            using var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;
            command.CommandText =
                "SELECT SPORTOVNI_DISCIPLINA_ID, NAZEV FROM SPORTOVNI_DISCIPLINY";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("SPORTOVNI_DISCIPLINA_ID"));
                string nazev = reader.GetString(reader.GetOrdinal("NAZEV"));

                disciplines.Add(new SportovniDisciplina(id, nazev));
            }

            return disciplines;
        }

    }
}
