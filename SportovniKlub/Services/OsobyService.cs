using SportovniKlub.Interfaces;
using SportovniKlub.Models;
using SportovniKlub.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportovniKlub.Services
{
    public class OsobyService : IOsobyService
    {
        private OsobyRepository osobyHandler;

        public OsobyService(IDatabase db) 
        { 
            osobyHandler = new OsobyRepository(db); 
        }

        public List<Osoba> GetAllOsoby()
        {
            List<Osoba> osoby = osobyHandler.ShowOsoby();
            return osoby;
        }


    }
}
