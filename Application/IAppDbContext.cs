using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Object = Domain.Entities.Object;

namespace Application;

public interface IAppDbContext
{
    DbSet<Achievement> Achievements { get; }
    DbSet<Artifact> Artifacts { get; }
    DbSet<Character> Characters { get; }
    DbSet<Floor> Floors { get; }
    DbSet<Monster> Monsters { get; }
    DbSet<Object> Objects { get; }
    DbSet<Pickup> Pickups { get; }
    DbSet<Room> Rooms { get; }
    DbSet<Trinket> Trinkets { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}