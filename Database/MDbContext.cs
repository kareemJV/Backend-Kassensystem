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


    }
}