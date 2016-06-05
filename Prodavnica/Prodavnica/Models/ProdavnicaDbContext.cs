using Microsoft.Data.Entity;
using Prodavnica.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Prodavnica.Models
{
    public class ProdavnicaDbContext : DbContext
    {
        public DbSet<Uposlenik> Uposlenici { get; set; }
        public DbSet<Artikal> Artikli { get; set; }
        public DbSet<Direktor> Direktori { get; set; }
        public DbSet<Prodavac> Prodavaci { get; set; }
        public DbSet<Menadzer> Menadzeri { get; set; }
        public DbSet<Supervizor> Supervizori { get; set; }
        public DbSet<ArtikalViewModel> ArtikliZP { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder oB)
        {
            string dbpath = "Prodavnica3.db";
            try
            {
                dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbpath);
            }
            catch (Exception) { }
            oB.UseSqlite($"Data source={dbpath}");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { //jedno od polja je image da se zna šta je zapravo predstavlja byte[] 
            modelBuilder.Entity<Artikal>().Property(p => p.Slika).HasColumnType("image"); }
        }
}
