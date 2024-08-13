using Domain.Enums;

namespace Domain.Entities;

public class BaseEntity
{
    public Guid Id { get; set; }
    public string? InnerId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public EntityType Type { get; set; }
    public string? Image { get; set; }
}