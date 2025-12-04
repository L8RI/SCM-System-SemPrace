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
            private IDatabase _db;

            public TymyRepository(IDatabase db)
            {
                _db = db;
            }

            public List<Tym> ShowTymy()
            {
                var tymy = new List<Tym>();

                using (var connection = _db.GetConnection())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT * FROM TYMY";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int tymID = 0;
                                string nazevTymu = string.Empty;
                                int pocetHracu = 0;
                                decimal plat = 0;
                                int pocetTrofeju = 0;
                                decimal vyseOdmen = 0;
                                int sportovniDisciplinaID = 0;
                                int? sponzorID = null;
                                int trenerID = 0;

                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    if (reader.GetName(i) == "TYM_ID")
                                    {
                                        tymID = Convert.ToInt32(reader.GetValue(i));
                                    }
                                    else if (reader.GetName(i) == "NAZEV_TYMU")
                                    {
                                        nazevTymu = reader.GetValue(i).ToString();
                                    }
                                    else if (reader.GetName(i) == "POCET_HRACU")
                                    {
                                        pocetHracu = Convert.ToInt32(reader.GetValue(i));
                                    }
                                    else if (reader.GetName(i) == "PLAT")
                                    {
                                        plat = Convert.ToDecimal(reader.GetValue(i));
                                    }
                                    else if (reader.GetName(i) == "POCET_TROFEJU")
                                    {
                                        pocetTrofeju = Convert.ToInt32(reader.GetValue(i));
                                    }
                                    else if (reader.GetName(i) == "VYSE_ODMEN")
                                    {
                                        vyseOdmen = Convert.ToDecimal(reader.GetValue(i));
                                    }
                                    else if (reader.GetName(i) == "SPORTOVNI_DISCIPLINA_ID")
                                    {
                                        sportovniDisciplinaID = Convert.ToInt32(reader.GetValue(i));
                                    }
                                    else if (reader.GetName(i) == "SPONZOR_ID")
                                    {
                                        if (reader.GetValue(i) != DBNull.Value)
                                            sponzorID = Convert.ToInt32(reader.GetValue(i));
                                    }
                                    else if (reader.GetName(i) == "TRENER_ID")
                                    {
                                        trenerID = Convert.ToInt32(reader.GetValue(i));
                                    }
                                }

                                Tym tym = new Tym(tymID, nazevTymu, pocetHracu, plat, pocetTrofeju, vyseOdmen, sportovniDisciplinaID, sponzorID, trenerID);

                                tymy.Add(tym);
                            }
                        }
                    }
                }
                return tymy;
            }

            public void AddTym(Tym tym)
            {
                using (var connection = _db.GetConnection())
                {
                    using (var command = connection.CreateCommand())
                    {
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
                }
            }

            public void DeleteTym(Tym tym)
            {
                using (var connection = _db.GetConnection())
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "DELETE FROM TYMY WHERE TYM_ID = :tymID";
                        command.Parameters.Add(new OracleParameter("tymID", tym.TymID));

                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
