namespace ResearchLink.Core.Shared;

public abstract class Entity : IEntity
{
    [Key]
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
