using GhibliApiNet.Api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GhibliApiNet.Api.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Location> Locations { get; set; } = null!;
    public DbSet<Species> Species { get; set; } = null!;
    public DbSet<Film> Films { get; set; } = null!;
    public DbSet<Person> People { get; set; } = null!;
    public DbSet<Vehicle> Vehicles { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>().HasKey(l => l.Id);
        modelBuilder.Entity<Species>().HasKey(s => s.Id);
        modelBuilder.Entity<Film>().HasKey(f => f.Id);
        modelBuilder.Entity<Person>().HasKey(p => p.Id);
        modelBuilder.Entity<Vehicle>().HasKey(v => v.Id);
    }
}