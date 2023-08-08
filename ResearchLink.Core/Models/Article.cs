namespace ResearchLink.Core.Models;
public class Article  : Entity
{
    public string Title { get; set; }
    [MaxLength(10000)]
    public string Description { get; set; }
    [MaxLength(10000)]
    public string Content { get; set; }
    public Guid PublisherId { get; set; }
    public virtual Publisher Publisher { get; set; }
    public DateTime DatePublished { get; set; }
    public ICollection<Citation> Citations { get; set; }  
    public ICollection<AuthorArticle> Authors { get; set; }
    public int Year => DatePublished.Year;
    public string Pages { get; set; }
    public Guid? VolumeId { get; set; }
    public virtual  Volume? Volume { get; set; }
    public ResearchType Type { get; set; }

}

