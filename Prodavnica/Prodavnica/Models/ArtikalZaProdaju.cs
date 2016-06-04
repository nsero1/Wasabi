using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica.Models
{
    public class ArtikalZaProdaju
    {
        public Artikal Artikal { get; set; }
        public bool? Dostupan { get; set; }
        public int BrojDostupnihArtikala { get; set; }
    }
}
