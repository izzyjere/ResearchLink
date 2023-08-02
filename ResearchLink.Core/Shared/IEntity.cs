namespace ResearchLink.Core.Shared;

public interface IEntity
{
    Guid Id { get; set; }
    DateTime CreatedDate { get; internal set; }
    DateTime? UpdatedDate { get; internal set; }
}
