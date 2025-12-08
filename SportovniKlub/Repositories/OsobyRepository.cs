using Oracle.ManagedDataAccess.Client;
using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using System;
using System.Collections.Generic;

namespace SportovniKlub.Repositories
{
    public class OsobyRepository
    {
        private readonly IUnitOfWork _uow;

        public OsobyRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public List<Osoba> GetAll()
        {
            var osoby = new List<Osoba>();

            using var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;
            command.CommandText = "SELECT * FROM OSOBY";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var osoba = new Osoba(
                    reader.GetInt32(reader.GetOrdinal("OSOBA_ID")),
                    reader.GetString(reader.GetOrdinal("JMENO")),
                    reader.GetString(reader.GetOrdinal("PRIJMENI")),
                    reader.GetDateTime(reader.GetOrdinal("DATUM_NAROZENI")),
                    reader.GetString(reader.GetOrdinal("MAIL")),
                    reader.GetString(reader.GetOrdinal("TYPOSOBY"))[0],
                    reader.GetInt32(reader.GetOrdinal("SPORTOVNI_DISCIPLINA_ID"))
                );

                osoby.Add(osoba);
            }

            return osoby;
        }

        public void Add(Osoba osoba)
        {
            using var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;

            command.CommandText = @"INSERT INTO OSOBY
                (JMENO, PRIJMENI, DATUM_NAROZENI, MAIL, TYPOSOBY, SPORTOVNI_DISCIPLINA_ID)
                VALUES (:jmeno, :prijmeni, :datumNarozeni, :mail, :typOsoby, :sportovniDisciplinaId)";

            command.Parameters.Add(new OracleParameter("jmeno", osoba.Jmeno));
            command.Parameters.Add(new OracleParameter("prijmeni", osoba.Prijmeni));
            command.Parameters.Add(new OracleParameter("datumNarozeni", osoba.DatumNarozeni));
            command.Parameters.Add(new OracleParameter("mail", osoba.Mail));
            command.Parameters.Add(new OracleParameter("typOsoby", osoba.TypOsoby));
            command.Parameters.Add(new OracleParameter("sportovniDisciplinaId", osoba.SportovniDisciplinaId));

            command.ExecuteNonQuery();
        }

        public void Update(Osoba osoba)
        {
            using var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;

            command.CommandText = @"UPDATE OSOBY SET
                JMENO = :jmeno,
                PRIJMENI = :prijmeni,
                DATUM_NAROZENI = :datumNarozeni,
                MAIL = :mail,
                TYPOSOBY = :typOsoby,
                SPORTOVNI_DISCIPLINA_ID = :sportovniDisciplinaId
                WHERE OSOBA_ID = :osobaId";

            command.Parameters.Add(new OracleParameter("jmeno", osoba.Jmeno));
            command.Parameters.Add(new OracleParameter("prijmeni", osoba.Prijmeni));
            command.Parameters.Add(new OracleParameter("datumNarozeni", osoba.DatumNarozeni));
            command.Parameters.Add(new OracleParameter("mail", osoba.Mail));
            command.Parameters.Add(new OracleParameter("typOsoby", osoba.TypOsoby));
            command.Parameters.Add(new OracleParameter("sportovniDisciplinaId", osoba.SportovniDisciplinaId));
            command.Parameters.Add(new OracleParameter("osobaId", osoba.OsobaId));

            command.ExecuteNonQuery();
        }

        public void Delete(int osobaId)
        {
            using var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;

            command.CommandText = "DELETE FROM OSOBY WHERE OSOBA_ID = :osobaId";
            command.Parameters.Add(new OracleParameter("osobaId", osobaId));

            command.ExecuteNonQuery();
        }
    }
}
