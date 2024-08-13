namespace Domain.Entities;

public class Character : BaseEntity
{
    public int Hp { get; set; }
    public int Damage { get; set; }
    public int Tears { get; set; }
    public int ShotSpeed { get; set; }
    public int Range { get; set; }
    public int Speed { get; set; }
    public int Lack { get; set; }
    public required string BirthrightEffect { get; set; }
    public Guid StartingItemId { get; set; }
}