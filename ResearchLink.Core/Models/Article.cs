namespace ResearchLink.Core.Models;
public class Article  : Entity
{
    [Required]
    public string Title { get; set; }
    [MaxLength(10000)]
    [Required(ErrorMessage = "Please provide an abstract for this paper.")]
    public string Description { get; set; }
    [Required]
    [RegularExpression("^((?!00000000-0000-0000-0000-000000000000).)*$", ErrorMessage = "Please select a publisher")]
    public Guid PublisherId { get; set; }
    public virtual Publisher Publisher { get; set; }
    public DateTime DatePublished { get; set; }
    public ICollection<Citation> Citations { get; set; }  
    public ICollection<AuthorArticle> Authors { get; set; }
    public int Year => DatePublished.Year;
    public string Pages { get; set; }
    public Guid? VolumeId { get; set; }
    public virtual  Volume? Volume { get; set; }
    [Required]
    [Range(1, 4, ErrorMessage = "Please select a research type")]
    public ResearchType Type { get; set; }
    public FileModel Document { get; set; }
}

