using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Entity;

namespace Prodavnica.Models
{
    public class Inventar
    {
        public List<ArtikalZaProdaju> Artikli;

        public void dodajArtikal(ArtikalZaProdaju artikal)
        {
            Artikli.Add(artikal);
            UpdateBazuArtikala();
        }

        public void dodajArtikal(Artikal artikal, int brojDostupnihArtikala)
        {
            ArtikalZaProdaju noviArtikal = new ArtikalZaProdaju();
            noviArtikal.Artikal = artikal;
            noviArtikal.BrojDostupnihArtikala = brojDostupnihArtikala;

            if (brojDostupnihArtikala > 0) noviArtikal.Dostupan = true;
            else noviArtikal.Dostupan = false;

            Artikli.Add(noviArtikal);
            UpdateBazuArtikala();
        }

        public ArtikalZaProdaju dajArtikalPoNazivu(string naziv)
        {
            foreach (ArtikalZaProdaju k in Artikli)
                if (k.Artikal.NazivArtikla == naziv) return k;

            return null;
        }

        public Inventar()
        {
            Artikli = new List<ArtikalZaProdaju>();
            PovuciArtikleIzBaze();
        }
        public void PovuciArtikleIzBaze()
        {
            Artikli.Clear();
            List<Artikal> bazni = DataSource.DataSource.Data.pDbC.Artikli.OrderBy(o => o.NazivArtikla).ToList();
            List<ViewModels.ArtikalViewModel> azp = DataSource.DataSource.Data.pDbC.ArtikliZP.OrderBy(o => o.Naziv).ToList();
            for (int i = 0; i < azp.Count(); i++)
            {
                ArtikalZaProdaju azap = new ArtikalZaProdaju();
                azap.Artikal = bazni[i];
                azap.BrojDostupnihArtikala = azp[i].BrojDostupnihArtikala;
                azap.Dostupan = Convert.ToBoolean(azap.BrojDostupnihArtikala);
                Artikli.Add(azap);
            }
            DataSource.DataSource.Data.pDbC = new ProdavnicaDbContext();
        }
        public void UpdateBazuArtikala()//ti ostalo kad budes radio samo na kraju update bazu brisanje modifikacija itd.
        {
            List<Artikal> zabaze = new List<Artikal>();
            List<ViewModels.ArtikalViewModel> zaprod = new List<ViewModels.ArtikalViewModel>();
            foreach(var kr in Artikli)
            {
                zabaze.Add(kr.Artikal);
                zaprod.Add(new ViewModels.ArtikalViewModel
                {
                    BrojDostupnihArtikala = kr.BrojDostupnihArtikala,
                    Cijena = kr.Artikal.CijenaArtikla,
                    ID = kr.Artikal.ID,
                    Naziv = kr.Artikal.NazivArtikla
                });
            }
            DataSource.DataSource.Data.pDbC.Database.ExecuteSqlCommand("delete from Artikal");
            DataSource.DataSource.Data.pDbC.SaveChanges();
            DataSource.DataSource.Data.pDbC.Database.ExecuteSqlCommand("delete from ArtikalViewModel");
            DataSource.DataSource.Data.pDbC.SaveChanges();
            DataSource.DataSource.Data.pDbC.Artikli.AddRange(zabaze);
            DataSource.DataSource.Data.pDbC.SaveChanges();
            DataSource.DataSource.Data.pDbC = new ProdavnicaDbContext();
            DataSource.DataSource.Data.pDbC.ArtikliZP.AddRange(zaprod);
            DataSource.DataSource.Data.pDbC.SaveChanges();
            DataSource.DataSource.Data.pDbC = new ProdavnicaDbContext();
        }
    }
}
