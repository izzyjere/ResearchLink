namespace ResearchLink.Core.Models;

public class AuthorArticle : Entity
{
    public Guid AuthorId { get; set; }
    public Guid ArticleId { get; set; }
    public virtual Article Article { get; set; }
    public virtual Author Author { get; set; }
    public int Order { get; set; }
}
