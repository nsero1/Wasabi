using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace ProdavnicaMigrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Artikal",
                columns: table => new
                {
                    ID = table.Column(type: "INTEGER", nullable: false),
                    //    .Annotation("Sqlite:Autoincrement", true),
                    CijenaArtikla = table.Column(type: "REAL", nullable: false),
                    NazivArtikla = table.Column(type: "TEXT", nullable: true),
                    OpisArtikla = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikal", x => x.ID);
                });
            migration.CreateTable(
                name: "Direktor",
                columns: table => new
                {
                    ID = table.Column(type: "INTEGER", nullable: false),
//                        .Annotation("Sqlite:Autoincrement", true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Nivo = table.Column(type: "INTEGER", nullable: false),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Sifra = table.Column(type: "TEXT", nullable: true),
                    korisnickoIme = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direktor", x => x.ID);
                });
            migration.CreateTable(
                name: "Menadzer",
                columns: table => new
                {
                    ID = table.Column(type: "INTEGER", nullable: false),
//                        .Annotation("Sqlite:Autoincrement", true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Nivo = table.Column(type: "INTEGER", nullable: false),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Sifra = table.Column(type: "TEXT", nullable: true),
                    korisnickoIme = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menadzer", x => x.ID);
                });
            migration.CreateTable(
                name: "Prodavac",
                columns: table => new
                {
                    ID = table.Column(type: "INTEGER", nullable: false),
//                        .Annotation("Sqlite:Autoincrement", true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Nivo = table.Column(type: "INTEGER", nullable: false),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Sifra = table.Column(type: "TEXT", nullable: true),
                    Smjena = table.Column(type: "INTEGER", nullable: false),
                    korisnickoIme = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodavac", x => x.ID);
                });
            migration.CreateTable(
                name: "Supervizor",
                columns: table => new
                {
                    ID = table.Column(type: "INTEGER", nullable: false),
//                        .Annotation("Sqlite:Autoincrement", true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Nivo = table.Column(type: "INTEGER", nullable: false),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Sifra = table.Column(type: "TEXT", nullable: true),
                    Smjena = table.Column(type: "INTEGER", nullable: false),
                    korisnickoIme = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervizor", x => x.ID);
                });
            migration.CreateTable(
                name: "Uposlenik",
                columns: table => new
                {
                    ID = table.Column(type: "INTEGER", nullable: false),
//                        .Annotation("Sqlite:Autoincrement", true),
                    Ime = table.Column(type: "TEXT", nullable: true),
                    Nivo = table.Column(type: "INTEGER", nullable: false),
                    Prezime = table.Column(type: "TEXT", nullable: true),
                    Sifra = table.Column(type: "TEXT", nullable: true),
                    korisnickoIme = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uposlenik", x => x.ID);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Artikal");
            migration.DropTable("Direktor");
            migration.DropTable("Menadzer");
            migration.DropTable("Prodavac");
            migration.DropTable("Supervizor");
            migration.DropTable("Uposlenik");
        }
    }
}
