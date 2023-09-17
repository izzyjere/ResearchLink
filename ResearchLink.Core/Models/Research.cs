namespace ResearchLink.Core.Models;
public class Research  : Entity
{
    [Required]
    public string Title { get; set; }
    [MaxLength(10000)]
    [Required(ErrorMessage = "Please provide an abstract for this research.")]
    public string Abstract { get; set; }
    [Required]
    [RegularExpression("^((?!00000000-0000-0000-0000-000000000000).)*$", ErrorMessage = "Please select a district")]
    public Guid DistrictId { get; set; }
    public virtual District District { get; set; }
    public DateTime DatePublished { get; set; }    
    public ICollection<AuthorResearch> Authors { get; set; }
    public int Year => DatePublished.Year;
    public string? ResearchMethod { get; set; }
    public FileModel Document { get; set; }
    public ICollection<ResearchComment> Comments { get; set; }
    [Required]
    [RegularExpression("^((?!00000000-0000-0000-0000-000000000000).)*$", ErrorMessage = "Please select a research topic")]
    public Guid ResearchTopicId { get; set; }
    public ResearchTopic ResearchTopic { get; set; }    
    public Guid? ResearchGapId { get; set; }
    public ResearchGap? ResearchGap { get; set; }
    public bool Monetize { get; set; }
    public decimal? Price { get; set; }
}

