using Prodavnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica.ViewModels
{
    public class ArtikalViewModel
    {
        public string Naziv { get; set; }
        public int ID { get; set; }
        public int BrojDostupnihArtikala { get; set; }
        public double Cijena { get; set; }

        public static ArtikalViewModel izArtikla(ArtikalZaProdaju artikal)
        {
            ArtikalViewModel artikalView = new ArtikalViewModel();
            artikalView.Naziv = artikal.Artikal.NazivArtikla;
            artikalView.ID = artikal.Artikal.ID;
            artikalView.BrojDostupnihArtikala = artikal.BrojDostupnihArtikala;
            artikalView.Cijena = artikal.Artikal.CijenaArtikla;
            
            return artikalView;
        }

    }
}
