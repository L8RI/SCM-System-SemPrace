using Oracle.ManagedDataAccess.Client;
using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using System;
using System.Collections.Generic;

namespace SportovniKlub.Repositories
{
    internal class SportovniDisciplinyRepository
    {
        private readonly IDatabase db;

        public SportovniDisciplinyRepository(IDatabase db)
        {
            this.db = db;
        }

        public List<SportovniDisciplina> GetAllDiscipline()
        {
            var disciplines = new List<SportovniDisciplina>();

            using (var connection = db.GetConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT SPORTOVNI_DISCIPLINA_ID, NAZEV FROM SPORTOVNI_DISCIPLINA";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = 0;
                        string nazev = string.Empty;

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (reader.GetName(i) == "SPORTOVNI_DISCIPLINA_ID")
                                id = Convert.ToInt32(reader.GetValue(i));
                            else if (reader.GetName(i) == "NAZEV")
                                nazev = reader.GetValue(i)?.ToString() ?? string.Empty;
                        }

                        disciplines.Add(new SportovniDisciplina(id, nazev));
                    }
                }
            }

            return disciplines;
        }
    }
}
