using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class LocalizerContext : DbContext
{
    public virtual DbSet<Sensor> Sensors { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"host=localhost;database=localizer;user id=postgres;password=zaq12WSX");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocalizerContext).Assembly);
    }
}