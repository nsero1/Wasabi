using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    class DefaultPodaci
    {
        public static void Initialize(UposlenikDbContext context)
        {
            if(!context.Uposlenici.Any())
            {
                context.Uposlenici.Add(
                    new Uposlenik()
                    {
                        Ime = "mujo",
                        Prezime = "mujic",
                        nivoPristupa = 1
                    });
                context.SaveChanges();
            }
        }
    }
}
