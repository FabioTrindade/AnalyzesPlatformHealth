using Microsoft.EntityFrameworkCore;
using MonitoringHealth.Entities;

namespace MonitoringHealth.Console.Data
{
    public class MonitoringHealthDbContext : DbContext
    {
        public MonitoringHealthDbContext(DbContextOptions<MonitoringHealthDbContext> options) : base(options) { }

        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<LogError> LogErrors { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Configuration>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<LogError>()
                .HasKey(e => e.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
