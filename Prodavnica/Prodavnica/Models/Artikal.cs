using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace Prodavnica.Models
{
    public class Artikal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string NazivArtikla { get; set; }
        public double CijenaArtikla { get; set;}
        public string OpisArtikla { get; set; }        
    }
}
