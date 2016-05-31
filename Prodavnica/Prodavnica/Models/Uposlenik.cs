using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica.Models
{
    public class Uposlenik
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int ID { get; set; }
        public string Sifra { get; set; }
        public NivoPristupa Nivo { get; set; }
        public string korisnickoIme { get; set; }
    }
}
