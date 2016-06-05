using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica.Models
{
    public class Supervizor:Uposlenik
    {
        public Smjena Smjena { get; set; }

        public Supervizor ()
        {
            this.Nivo = NivoPristupa.Nivo3;
        }
    }
}
