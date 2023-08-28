namespace ResearchLink.Core.Models;

public class AuthorResearch : Entity
{
    public Guid AuthorId { get; set; }
    public Guid ResearchId { get; set; }
    public virtual Research Research { get; set; }
    public virtual Author Author { get; set; }
    public int Order { get; set; }
}
