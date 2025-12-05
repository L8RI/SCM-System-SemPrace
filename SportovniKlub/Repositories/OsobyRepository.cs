using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Repositories
{
    public class OsobyRepository
    {
        private readonly IDatabase _db;

        public OsobyRepository(IDatabase db)
        {
            _db = db;
        }

        public List<Osoba> ShowOsoby()
        {
            //List<Osoba> osoby = new();

            //using (var connection = _db.GetConnection())
            //{
            //    using (var command = connection.CreateCommand())
            //    {
            //        command.CommandText = "SELECT * FROM OSOBY";

            //        using (var reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                    char typ = reader.GetString(5)[0];

            //                    Osoba osoba = typ switch
            //                    {
            //                        'T' => new Trener(),
            //                        'C' => new ClenKlubu(),
            //                        _ => new Osoba()
            //                    };

            //                    osoba.OsobaId = reader.GetInt32(0);
            //                    osoba.Jmeno = reader.GetString(1);
            //                    osoba.Prijmeni = reader.GetString(2);
            //                    osoba.DatumNarozeni = reader.GetDateTime(3);
            //                    osoba.Mail = reader.GetString(4);
            //                    osoba.TypOsoby = typ;
            //                    osoba.SportovniDisciplinaId = reader.GetInt32(6);

            //                    osoby.Add(osoba);
            //            }
            //        }
            //    }
            //}
            //return osoby;

            return null;
        }
    }
}
