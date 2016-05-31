using Prodavnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prodavnica.DataSource
{
    public class DataSource
    {
        public class Data
        {
            public static ListaUposlenika ListaUposlenika;
            public static Dictionary<NivoPristupa, List<MeniStavka>> Stavke;
            public static Inventar Inventar;

            private void kreirajStavke()
            {
                List<MeniStavka> DirektorStavke;
                List<MeniStavka> MenadzerStavke;
                List<MeniStavka> SupervizorStavke;
                List<MeniStavka> ProdavacStavke;

                DirektorStavke = new List<MeniStavka>();
                MenadzerStavke = new List<MeniStavka>();
                SupervizorStavke = new List<MeniStavka>();
                ProdavacStavke = new List<MeniStavka>();

                ProdavacStavke.Add(new MeniStavka()
                {
                    MeniStavkaId = 2,
                    Naziv = "Prikaz inventara",
                    Kod = "F1",
                    Podstranica = typeof(PrikazInventara)
                });

                SupervizorStavke.AddRange(ProdavacStavke);
                MenadzerStavke.AddRange(SupervizorStavke);

                MenadzerStavke.Add(new MeniStavka()
                {
                    MeniStavkaId = 2,
                    Naziv = "Prikaz uposlenika",
                    Kod = "F2",
                    Podstranica = typeof(PrikazUposlenika)
                });

                MenadzerStavke.Add(new MeniStavka()
                {
                    MeniStavkaId = 3,
                    Naziv = "Unos uposlenika",
                    Kod = "F3",
                    Podstranica = typeof(DodajUposlenika)
                });

                MenadzerStavke.Add(new MeniStavka()
                {
                    MeniStavkaId = 4,
                    Naziv = "Dodaj artikal",
                    Kod = "F4",
                    Podstranica = typeof(DodajArtikal)
                });
                DirektorStavke.AddRange(MenadzerStavke);

                Stavke[NivoPristupa.Nivo1] = DirektorStavke;
                Stavke[NivoPristupa.Nivo2] = MenadzerStavke;
                Stavke[NivoPristupa.Nivo3] = SupervizorStavke;
                Stavke[NivoPristupa.Nivo4] = ProdavacStavke;
            }

            public Data()
            {
                ListaUposlenika = new ListaUposlenika();
                Stavke = new Dictionary<NivoPristupa, List<MeniStavka>>();
                Inventar = new Inventar();

                Stavke[NivoPristupa.Nivo1] = new List<MeniStavka>();
                Stavke[NivoPristupa.Nivo2] = new List<MeniStavka>();
                Stavke[NivoPristupa.Nivo3] = new List<MeniStavka>();
                Stavke[NivoPristupa.Nivo4] = new List<MeniStavka>();

                kreirajStavke();
            }
        }
    }
}
