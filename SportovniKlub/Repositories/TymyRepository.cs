using Oracle.ManagedDataAccess.Client;
using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.TablesHandlers
    {
        internal class TymyRepository
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
                    int? sponzorId = reader.IsDBNull(7) ? null : reader.GetInt32(7);

                    var tym = new Tym(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetInt32(2),
                    reader.GetDecimal(3),
                    reader.GetInt32(4),
                    reader.GetDecimal(5),
                    reader.GetInt32(6),
                    sponzorId,
                    reader.GetInt32(8)
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
                command.Parameters.Add(new OracleParameter("sportovniDisciplinaID", tym.SportovniDisciplinaID));

                if (tym.SponzorID.HasValue)
                    command.Parameters.Add(new OracleParameter("sponzorID", tym.SponzorID.Value));
                else
                    command.Parameters.Add(new OracleParameter("sponzorID", DBNull.Value));

                command.Parameters.Add(new OracleParameter("trenerID", tym.TrenerID));

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
