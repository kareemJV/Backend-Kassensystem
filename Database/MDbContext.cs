using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class MDbContext : DbContext
    {
        public MDbContext(DbContextOptions<MDbContext> options)
       : base(options)
        {
        }

        public DbSet<Produkt> Produkte { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produkt>()
                .Property(p => p.Preis)
                .HasColumnType("decimal(18,2)"); // SQL-Datentyp für Preis festlegen

            base.OnModelCreating(modelBuilder);
        }
    }
}