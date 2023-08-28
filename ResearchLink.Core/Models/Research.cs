namespace ResearchLink.Core.Models;
public class Research  : Entity
{
    [Required]
    public string Title { get; set; }
    [MaxLength(10000)]
    [Required(ErrorMessage = "Please provide an abstract for this research.")]
    public string Description { get; set; }
    [Required]
    [RegularExpression("^((?!00000000-0000-0000-0000-000000000000).)*$", ErrorMessage = "Please select a district")]
    public Guid DistrictId { get; set; }
    public virtual District District { get; set; }
    public DateTime DatePublished { get; set; }    
    public ICollection<AuthorResearch> Authors { get; set; }
    public int Year => DatePublished.Year;
    public string? Pages { get; set; } 
    public FileModel Document { get; set; }
    public ICollection<Comment> Comments { get; set; }
    public Guid ResearchTopicId { get; set; }
    public ResearchTopic ResearchTopic { get; set; }    
}

