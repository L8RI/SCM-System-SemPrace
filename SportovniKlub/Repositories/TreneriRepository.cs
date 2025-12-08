using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Repositories
{
    public class TreneriRepository
    {
        private readonly IUnitOfWork _uow;

        public TreneriRepository(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Trener GetById(int id)
        {
            var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;
            command.CommandText = "SELECT t.TRENER_ID, t.ZKUSENOST, " +
                "o.JMENO, o.PRIJMENI" +
                " FROM TRENERI t JOIN OSOBY o ON o.OSOBA_ID = t.TRENER_ID WHERE TRENER_ID = :id";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int trenerId = reader.GetInt32(reader.GetOrdinal("TRENER_ID"));
                int zkusenot = reader.GetInt32(reader.GetOrdinal("ZKUSENOST"));
                string jmeno = reader.GetString(reader.GetOrdinal("JMENO"));
                string prijmeni = reader.GetString(reader.GetOrdinal("PRIJMENI"));

                return new Trener(trenerId, jmeno, prijmeni, zkusenot);
            }

            return null;
        }

        public List<Trener> GetAllTreneri()
        {
            var treneri = new List<Trener>();

            using var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;

            command.CommandText = @"
                SELECT 
                    t.TRENER_ID,
                    t.ZKUSENOST,
                    o.JMENO,
                    o.PRIJMENI
                FROM TRENERI t
                JOIN OSOBY o ON t.TRENER_ID = o.OSOBA_ID
            ";

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                int trenerId = reader.GetInt32(reader.GetOrdinal("TRENER_ID"));
                int zkusenost = reader.GetInt32(reader.GetOrdinal("ZKUSENOST"));
                string jmeno = reader.GetString(reader.GetOrdinal("JMENO"));
                string prijmeni = reader.GetString(reader.GetOrdinal("PRIJMENI"));

                var trener = new Trener(
                    trenerId,
                    jmeno,
                    prijmeni,
                    zkusenost
                );

                treneri.Add(trener);
            }

            return treneri;
        }
    }
}
