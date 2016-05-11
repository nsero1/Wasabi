using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace App1Migrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Uposlenik",
                columns: table => new
                {
                    UposlenikId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    ime = table.Column(type: "TEXT", nullable: true),
                    nivoPristupa = table.Column(type: "INTEGER", nullable: false),
                    prezime = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uposlenik", x => x.UposlenikId);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Uposlenik");
        }
    }
}
