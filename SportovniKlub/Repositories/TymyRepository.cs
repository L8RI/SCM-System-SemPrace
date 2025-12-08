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
        public class TymyRepository
        {
            private readonly IUnitOfWork _uow;

                public TymyRepository(IUnitOfWork uow)
                {
                    _uow = uow;
                }

        public List<Tym> ShowTymy()
        {
            var tymy = new List<Tym>();

            using var command = _uow.Connection.CreateCommand();
            command.Transaction = _uow.Transaction;
            command.CommandText = "SELECT * FROM TYMY";

            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                int tymId = reader.GetInt32(reader.GetOrdinal("TYM_ID"));
                string nazevTymu = reader.GetString(reader.GetOrdinal("NAZEV_TYMU"));
                int pocetHracu = reader.GetInt32(reader.GetOrdinal("POCET_HRACU"));
                decimal plat = reader.GetDecimal(reader.GetOrdinal("PLAT"));
                int pocetTrofeju = reader.GetInt32(reader.GetOrdinal("POCET_TROFEJU"));
                decimal vyseOdmen = reader.GetDecimal(reader.GetOrdinal("VYSE_ODMEN"));
                int sportovniDisciplinaId = reader.GetInt32(reader.GetOrdinal("SPORTOVNI_DISCIPLINA_ID"));
                int sponzorOrdinal = reader.GetOrdinal("SPONZOR_ID");
                int? sponzorId = reader.IsDBNull(sponzorOrdinal) ? null : reader.GetInt32(sponzorOrdinal);

                int trenerId = reader.GetInt32(reader.GetOrdinal("TRENER_ID"));

                var tym = new Tym(
                    tymId,
                    nazevTymu,
                    pocetHracu,
                    plat,
                    pocetTrofeju,
                    vyseOdmen,
                    sportovniDisciplinaId,
                    sponzorId,
                    trenerId
                );

                tymy.Add(tym);
            }

            return tymy;
        }

        public void AddTym(Tym tym)
            {
                var command = _uow.Connection.CreateCommand();
                command.Connection = _uow.Connection;
                command.Transaction = _uow.Transaction;

                command.CommandText = @"INSERT INTO TYMY 
                        (NAZEV_TYMU, POCET_HRACU, PLAT, POCET_TROFEJU, VYSE_ODMEN, SPORTOVNI_DISCIPLINA_ID, SPONZOR_ID, TRENER_ID)
                        VALUES (:nazevTymu, :pocetHracu, :plat, :pocetTrofeju, :vyseOdmen, :sportovniDisciplinaID, :sponzorID, :trenerID)";

                command.Parameters.Add(new OracleParameter("nazevTymu", tym.NazevTymu));
                command.Parameters.Add(new OracleParameter("pocetHracu", tym.PocetHracu));
                command.Parameters.Add(new OracleParameter("plat", tym.Plat));
                command.Parameters.Add(new OracleParameter("pocetTrofeju", tym.PocetTrofeju));
                command.Parameters.Add(new OracleParameter("vyseOdmen", tym.VyseOdmen));
                command.Parameters.Add(new OracleParameter("sportovniDisciplinaID", tym.SportovniDisciplina.SportovniDisciplinaId));

                if (!tym.Sponzor.SponzorId.Equals(null))
                    command.Parameters.Add(new OracleParameter("sponzorID", tym.Sponzor.SponzorId));
                else
                    command.Parameters.Add(new OracleParameter("sponzorID", DBNull.Value));

                command.Parameters.Add(new OracleParameter("trenerID", tym.Trener.OsobaId));

                command.ExecuteNonQuery();
            }

            public void DeleteTym(Tym tym)
            {
                var command = _uow.Connection.CreateCommand();
                command.Connection = _uow.Connection;
                command.Transaction = _uow.Transaction;

                command.CommandText = "DELETE FROM TYMY WHERE TYM_ID = :tymID";
                command.Parameters.Add(new OracleParameter("tymID", tym.TymID));

                command.ExecuteNonQuery();
            }
        }
    }
