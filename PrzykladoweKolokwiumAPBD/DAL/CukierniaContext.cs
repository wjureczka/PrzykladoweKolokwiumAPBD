using Microsoft.EntityFrameworkCore;
using PrzykladoweKolokwiumAPBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzykladoweKolokwiumAPBD.DAL
{
    public class CukierniaContext : DbContext
    {

        public CukierniaContext() : base()
        {

        }

        public CukierniaContext(DbContextOptions<CukierniaContext> options) : base(options)
        { 
        }

        public DbSet<Klient> Klients { get; set; }

        public DbSet<Pracownik> Pracowniks { get; set; }

        public DbSet<WyrobCukierniczy> WyrobCukierniczies { get; set; }

        public DbSet<Zamowienie> Zamowienies { get; set; }

        public DbSet<Zamowienie_WyrobCukierniczy> Zamowienie_WyrobCukierniczies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>((entity) =>
            {
                entity.HasKey(entity => new { entity.IdWyrobuCukierniczego, entity.IdZamowienia });
            });
        }
    }
}
