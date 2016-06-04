using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace ProdavnicaMigrations
{
    public partial class ViewModelfazoni2 : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "ArtikalViewModel",
                columns: table => new
                {
                    ID = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    BrojDostupnihArtikala = table.Column(type: "INTEGER", nullable: false),
                    Cijena = table.Column(type: "REAL", nullable: false),
                    Naziv = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtikalViewModel", x => x.ID);
                });
           /* migration.AlterColumn(
                name: "ID",
                table: "Uposlenik",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "ID",
                table: "Supervizor",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "ID",
                table: "Prodavac",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "ID",
                table: "Menadzer",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "ID",
                table: "Direktor",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "ID",
                table: "Artikal",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);*/
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("ArtikalViewModel");
            /*migration.AlterColumn(
                name: "ID",
                table: "Uposlenik",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "ID",
                table: "Supervizor",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "ID",
                table: "Prodavac",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "ID",
                table: "Menadzer",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "ID",
                table: "Direktor",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
                name: "ID",
                table: "Artikal",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);*/
        }
    }
}
