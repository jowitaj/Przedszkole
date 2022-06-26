using Microsoft.EntityFrameworkCore;
using Przedszkole.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przedszkole.Database
{
    public class AppDbContext:DbContext
    {
        // Konstruktor bez parametrów
        public AppDbContext()
        {
        }


         // Konstruktor z parametrami z dziedziczacej klasy 
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Dziecko> Dzieci { get; set; }
        public DbSet<Wychowawca> Wychowawcy { get; set; }
        public DbSet<Obecnosc> Obecnosci { get; set; }
        public DbSet<Rodzice> Rodzice { get; set; }

        // Metoda ktora wymaga id przy tworzeniu modelu
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dziecko>().HasKey(x => x.Id);
            modelBuilder.Entity<Wychowawca>().HasKey(x => x.Id);
            modelBuilder.Entity<Obecnosc>().HasKey(x => x.Id);
            modelBuilder.Entity<Rodzice>().HasKey(x => x.Id);
        }

    }
}
