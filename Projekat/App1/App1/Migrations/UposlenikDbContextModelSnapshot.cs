using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using App1.Models;

namespace App1Migrations
{
    [ContextType(typeof(UposlenikDbContext))]
    partial class UposlenikDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
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
