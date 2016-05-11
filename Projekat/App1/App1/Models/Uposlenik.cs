using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    class Uposlenik
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UposlenikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int nivoPristupa { get; set; }

    }
}
