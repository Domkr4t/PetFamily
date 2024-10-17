using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Pets.Entity;
using PetFamily.Domain.Species.Entity;

namespace PetFamily.Infrastucture
{
    public class ApplicationDbConbext(IConfiguration configuration) : DbContext
    {
        private const string DATABASE = "Database";

        public DbSet<Volunteer> Volunteers => Set<Volunteer>();
        public DbSet<Specie> Species => Set<Specie>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString(DATABASE));
            optionsBuilder.UseSnakeCaseNamingConvention();
            optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbConbext).Assembly);
        }

        private ILoggerFactory CreateLoggerFactory() => 
            LoggerFactory.Create(builder => { builder.AddConsole(); });
    }
}
