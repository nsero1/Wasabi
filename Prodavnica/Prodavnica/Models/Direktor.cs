using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica.Models
{
    public class Direktor: Uposlenik
    {
        public Direktor()
        {
            this.Nivo = NivoPristupa.Nivo1; 
        }
    }
}
