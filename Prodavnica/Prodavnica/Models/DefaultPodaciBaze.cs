using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica.Models
{
    class DefaultPodaciBaze
    {
        public static void Initialize(ProdavnicaDbContext dbC)
        {
            if (!dbC.Direktori.Any())
            {
                dbC.Direktori.AddRange(
                    new Direktor
                    {
                        ID = 1,
                        Ime = "vako",
                        Prezime = "tako",
                        korisnickoIme = "rkaleta1",
                        Sifra = "1234",
                        Nivo = NivoPristupa.Nivo1
                    },
                new Direktor
                {
                    ID = 2,
                    Ime = "neko",
                    Prezime = "nako",
                    korisnickoIme = "Ahrelja",
                    Sifra = "1234",
                    Nivo = NivoPristupa.Nivo1
                });
                dbC.SaveChanges();
            }
            /*dbC.Supervizori.Add(new Supervizor{  ID = 35,
                    Ime = "dasd",
                    Prezime = "nagfgdfgko",
                    korisnickoIme = "addsffmin",
                    Sifra = "ad45345min",
                    Nivo = NivoPristupa.Nivo3});*/
            /*ProdavnicaDbContext ghjk = new ProdavnicaDbContext();
            ghjk.Supervizori.Add(new Supervizor
            {
                ID = 90,
                Ime = "dadsadsd",
                Prezime = "naassgfgdfgko",
                korisnickoIme = "addfsdsffmin",
                Sifra = "ad4534ewr5min",
                Nivo = NivoPristupa.Nivo3
            });
            ghjk.SaveChanges();*/

        }
    }
}
