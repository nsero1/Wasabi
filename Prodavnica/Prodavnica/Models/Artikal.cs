using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica.Models
{
    public class Artikal
    {
        public int ID { get; set; }
        public string NazivArtikla { get; set; }
        public double CijenaArtikla { get; set;}
        public string OpisArtikla { get; set; }
    }
}
