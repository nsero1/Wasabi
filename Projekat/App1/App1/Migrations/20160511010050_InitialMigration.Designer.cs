using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using App1.Models;

namespace App1Migrations
{
    [ContextType(typeof(UposlenikDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20160511010050_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("App1.Models.Uposlenik", b =>
                {
                    b.Property<int>("UposlenikId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ime");

                    b.Property<int>("nivoPristupa");

                    b.Property<string>("prezime");

                    b.Key("UposlenikId");
                });
        }
    }
}
