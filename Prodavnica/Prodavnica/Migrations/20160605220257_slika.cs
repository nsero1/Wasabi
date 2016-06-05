using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace ProdavnicaMigrations
{
    public partial class slika : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            /*migration.AlterColumn(
                name: "ID",
                table: "ArtikalViewModel",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
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
            migration.AddColumn(
                name: "Slika",
                table: "Artikal",
                type: "image",
                nullable: true);
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropColumn(name: "Slika", table: "Artikal");
            /*migration.AlterColumn(
                name: "ID",
                table: "ArtikalViewModel",
                type: "INTEGER",
                nullable: false)
                .Annotation("Sqlite:Autoincrement", true);
            migration.AlterColumn(
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
