using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica.Models
{
    public class ListaUposlenika
    {
        public List<Uposlenik> uposlenici;

        public IList<Uposlenik> dajSveUposlenike()
        {
            return uposlenici;
        }

        public Uposlenik dajUposlenikaPoId(int uposlenikID)
        {
            return uposlenici.Where(k => k.ID.Equals(uposlenikID)).FirstOrDefault();
        }

        public Uposlenik dajUposlenikaPoKorisnickomImenu(string korisnickoIme)
        {
            foreach (Uposlenik k in uposlenici)
                if (k.korisnickoIme == korisnickoIme) return k;

            return null;
        }

        public Uposlenik provjeraUposlenika(string korisnickoIme, string sifra)
        {
            Uposlenik rezultat = new Uposlenik();
            foreach (var k in dajSveUposlenike())
            {
                if (k.korisnickoIme == korisnickoIme && k.Sifra == sifra) rezultat = k;
            }
            return rezultat;
        }

        public void dodajUposlenika(string ime, string prezime, string korisnickoIme, string sifra, Pozicija pozicija)
        {
            if (dajUposlenikaPoKorisnickomImenu(korisnickoIme) != null) return;

            Uposlenik noviUposlenik;

            if (pozicija == Pozicija.Direktor) noviUposlenik = new Direktor();
            else if (pozicija == Pozicija.Menadzer) noviUposlenik = new Menadzer();
            else if (pozicija == Pozicija.Supervizor) noviUposlenik = new Supervizor();
            else noviUposlenik = new Prodavac();

            noviUposlenik.Ime = ime;
            noviUposlenik.Prezime = prezime;
            noviUposlenik.korisnickoIme = korisnickoIme;
            noviUposlenik.Sifra = sifra;

            if (noviUposlenik is Supervizor)
                (noviUposlenik as Supervizor).Smjena = Smjena.Jutarnja;
            else if (noviUposlenik is Prodavac)
                (noviUposlenik as Prodavac).Smjena = Smjena.Jutarnja;

            if (uposlenici.Count == 0)
                noviUposlenik.ID = 1;
            else noviUposlenik.ID = uposlenici.Max(r => r.ID) + 1;

            uposlenici.Add(noviUposlenik);
            UpdateBazuUposlenika();
        }

        public void dodajUposlenika(Uposlenik noviUposlenik)
        {
            uposlenici.Add(noviUposlenik);
            UpdateBazuUposlenika();
        }

        void testniUposlenici()
        {
            //dodajUposlenika("Ajdin", "Hrelja", "Ahrelja", "1234", Pozicija.Direktor);
            dodajUposlenika("Emir", "Hrelja", "Ehrelja", "1234", Pozicija.Prodavac);
        }

        public ListaUposlenika()
        {
            uposlenici = new List<Uposlenik>();
            //testniUposlenici();
            PovuciIzBaze();
            UpdateBazuUposlenika();
        }
        public void UpdateBazuUposlenika() //ti ostalo kad budes radio samo na kraju update bazu
        {
            DataSource.DataSource.Data.pDbC.Database.ExecuteSqlCommand("delete from Prodavac");
            //DataSource.DataSource.Data.pDbC.Prodavaci.RemoveRange(DataSource.DataSource.Data.pDbC.Prodavaci);
            DataSource.DataSource.Data.pDbC.SaveChanges();
            //DataSource.DataSource.Data.pDbC.Direktori.RemoveRange(DataSource.DataSource.Data.pDbC.Direktori);
            DataSource.DataSource.Data.pDbC.Database.ExecuteSqlCommand("delete from Direktor");
            DataSource.DataSource.Data.pDbC.SaveChanges();
            //DataSource.DataSource.Data.pDbC.Menadzeri.RemoveRange(DataSource.DataSource.Data.pDbC.Menadzeri);
            DataSource.DataSource.Data.pDbC.Database.ExecuteSqlCommand("delete from Menadzer");
            DataSource.DataSource.Data.pDbC.SaveChanges();
            //DataSource.DataSource.Data.pDbC.Supervizori.RemoveRange(DataSource.DataSource.Data.pDbC.Supervizori);
            DataSource.DataSource.Data.pDbC.Database.ExecuteSqlCommand("delete from Supervizor");
            DataSource.DataSource.Data.pDbC.SaveChanges();
            /*List<Direktor> lokDir = new List<Direktor>();
            foreach (Uposlenik up in uposlenici)
            {
                if (up is Direktor)
                    lokDir.Add((Direktor)up);
            }*/
            DataSource.DataSource.Data.pDbC.Uposlenici.AddRange(uposlenici);
            DataSource.DataSource.Data.pDbC.SaveChanges();
            DataSource.DataSource.Data.pDbC = new ProdavnicaDbContext();
        }

        public void PovuciIzBaze()
        {
            uposlenici.Clear();
            uposlenici.AddRange(DataSource.DataSource.Data.pDbC.Prodavaci.ToList());
            uposlenici.AddRange(DataSource.DataSource.Data.pDbC.Direktori.ToList());
            uposlenici.AddRange(DataSource.DataSource.Data.pDbC.Supervizori.ToList());
            uposlenici.AddRange(DataSource.DataSource.Data.pDbC.Menadzeri.ToList());
            DataSource.DataSource.Data.pDbC = new ProdavnicaDbContext();
        }
    }
}
