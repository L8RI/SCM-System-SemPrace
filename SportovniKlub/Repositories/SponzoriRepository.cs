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
    public class SponzoriRepository
    {
        private readonly IUnitOfWork _uow;

        public SponzoriRepository(IUnitOfWork uow) 
        { 
            _uow = uow;
        }

        public Sponzor GetById(int id)
        {
            var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;
            command.CommandText = "SELECT * FROM SPONZORI WHERE SPONZOR_ID = :id";

            command.Parameters.Add(new OracleParameter("id", id));

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int sponzorId = reader.GetInt32(reader.GetOrdinal("SPONZOR_ID"));
                string nazev = reader.GetString(reader.GetOrdinal("NAZEV"));

                return new Sponzor(sponzorId, nazev);
            }

            return null;
        }

        public List<Sponzor> GetAllSponzori()
        {
            List<Sponzor> sponzori = new List<Sponzor>();

            var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;
            command.CommandText = "SELECT * FROM SPONZORI";

            using (var reader = command.ExecuteReader())
            while (reader.Read())
            {
                int id = reader.GetInt32(reader.GetOrdinal("SPONZOR_ID"));
                string nazev = reader.GetString(reader.GetOrdinal("NAZEV"));

                sponzori.Add(new Sponzor(id, nazev));
            }

            return sponzori;
        }
    }
}
