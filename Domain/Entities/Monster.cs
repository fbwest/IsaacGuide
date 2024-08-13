namespace Domain.Entities;

public class Monster : BaseEntity
{
    public int BaseHp { get; set; }
    public int StageHp { get; set; }
    public bool IsBoss { get; set; }
}