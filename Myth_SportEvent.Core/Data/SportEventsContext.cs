using Microsoft.EntityFrameworkCore;
using Myth_SportEvent.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myth_SportEvent.Core.Data
{
    public class SportEventsContext : DbContext
    {
        public DbSet<SportsEvent> SportsEvents { get; set; } = null!;

        public SportEventsContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-NR731O8\\SQLEXPRESS;Initial Catalog=MythDigital;Integrated Security=True;Pooling=False;TrustServerCertificate=True"); //To be stored in appsettings or secret store
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

    }
}
