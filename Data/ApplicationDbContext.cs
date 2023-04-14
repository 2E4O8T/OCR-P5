using EVSec.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EVSec.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Inventaire>? Inventaires { get; set; }
        public DbSet<Reparations>? Reparations { get; set; }
        public DbSet<Interventions>? Interventions { get; set; }
        public DbSet<InterventionsReparations>? InterventionsReparations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
            modelBuilder.Entity<Inventaire>().ToTable("Inventaire");
            modelBuilder.Entity<Reparations>().ToTable("Reparations");
            modelBuilder.Entity<Interventions>().ToTable("Interventions");
            modelBuilder.Entity<InterventionsReparations>().ToTable("InterventionsReparations");
        }
    }
}