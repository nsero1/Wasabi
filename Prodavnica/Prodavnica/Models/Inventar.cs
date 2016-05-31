using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica.Models
{
    public class Inventar
    {
        public List<ArtikalZaProdaju> Artikli;

        public void dodajArtikal(ArtikalZaProdaju artikal)
        {
            Artikli.Add(artikal);
        }

        public void dodajArtikal(Artikal artikal, int brojDostupnihArtikala)
        {
            ArtikalZaProdaju noviArtikal = new ArtikalZaProdaju();
            noviArtikal.Artikal = artikal;
            noviArtikal.BrojDostupnihArtikala = brojDostupnihArtikala;

            if (brojDostupnihArtikala > 0) noviArtikal.Dostupan = true;
            else noviArtikal.Dostupan = false;

            Artikli.Add(noviArtikal);
        }

        public Inventar()
        {
            Artikli = new List<ArtikalZaProdaju>();
        }
    }
}
