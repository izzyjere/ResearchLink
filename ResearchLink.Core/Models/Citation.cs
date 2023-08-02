namespace ResearchLink.Core.Models;

public class Citation : Entity
{
    public Guid SourceArticleId { get; set; }
    public virtual Article SourceArticle { get; set; }
    public Guid TargetArticleId { get; set; }
    public virtual Article TargetArticle { get; set; }
}

