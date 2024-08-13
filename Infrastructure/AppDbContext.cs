using Application;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Object = Domain.Entities.Object;

namespace Infrastructure;

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<Achievement> Achievements => Set<Achievement>();
    public DbSet<Artifact> Artifacts => Set<Artifact>();
    public DbSet<Character> Characters => Set<Character>();
    public DbSet<Floor> Floors => Set<Floor>();
    public DbSet<Monster> Monsters => Set<Monster>();
    public DbSet<Object> Objects => Set<Object>();
    public DbSet<Pickup> Pickups => Set<Pickup>();
    public DbSet<Room> Rooms => Set<Room>();
    public DbSet<Trinket> Trinkets => Set<Trinket>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Port=5432; User Id=postgres; Password=12; Database=isaac_guide;");
    }
}