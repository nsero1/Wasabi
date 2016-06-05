using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica.Models
{
    public class Prodavac:Uposlenik
    {
        public Smjena Smjena { get; set; }

        public Prodavac()
        {
            this.Nivo = NivoPristupa.Nivo3;
        }
    }
}
