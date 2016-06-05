using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using Prodavnica.Models;

namespace ProdavnicaMigrations
{
    [ContextType(typeof(ProdavnicaDbContext))]
    partial class slika
    {
        public override string Id
        {
            get { return "20160605220257_slika"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("Prodavnica.Models.Artikal", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("CijenaArtikla");

                    b.Property<string>("NazivArtikla");

                    b.Property<string>("OpisArtikla");

                    b.Property<byte[]>("Slika")
                        .Annotation("Relational:ColumnType", "image");

                    b.Key("ID");
                });

            builder.Entity("Prodavnica.Models.Direktor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.Property<int>("Nivo");

                    b.Property<string>("Prezime");

                    b.Property<string>("Sifra");

                    b.Property<string>("korisnickoIme");

                    b.Key("ID");
                });

            builder.Entity("Prodavnica.Models.Menadzer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.Property<int>("Nivo");

                    b.Property<string>("Prezime");

                    b.Property<string>("Sifra");

                    b.Property<string>("korisnickoIme");

                    b.Key("ID");
                });

            builder.Entity("Prodavnica.Models.Prodavac", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.Property<int>("Nivo");

                    b.Property<string>("Prezime");

                    b.Property<string>("Sifra");

                    b.Property<int>("Smjena");

                    b.Property<string>("korisnickoIme");

                    b.Key("ID");
                });

            builder.Entity("Prodavnica.Models.Supervizor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.Property<int>("Nivo");

                    b.Property<string>("Prezime");

                    b.Property<string>("Sifra");

                    b.Property<int>("Smjena");

                    b.Property<string>("korisnickoIme");

                    b.Key("ID");
                });

            builder.Entity("Prodavnica.Models.Uposlenik", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Ime");

                    b.Property<int>("Nivo");

                    b.Property<string>("Prezime");

                    b.Property<string>("Sifra");

                    b.Property<string>("korisnickoIme");

                    b.Key("ID");
                });

            builder.Entity("Prodavnica.ViewModels.ArtikalViewModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrojDostupnihArtikala");

                    b.Property<double>("Cijena");

                    b.Property<string>("Naziv");

                    b.Key("ID");
                });
        }
    }
}
