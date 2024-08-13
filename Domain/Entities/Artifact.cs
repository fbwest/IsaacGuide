using Domain.Enums;

namespace Domain.Entities;

public class Artifact : BaseEntity
{
    public ArtifactType SubType { get; set; }
    public int Charges { get; set; }
    public int Quality { get; set; }
}