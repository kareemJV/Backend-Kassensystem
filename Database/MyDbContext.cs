using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbSet<Produkt> produkte)
        {
            Produkte = produkte;
        }

        public DbSet<Produkt> Produkte { get; set; }
    }
}