namespace ResearchLink.Core.Models
{
    public class ProposedAuthor: Entity
    {
        public Guid ResearchGapId { get; set; } 
        public Guid AuthorId { get; set; }
        public ResearchGap ResearchGap { get; set; }
        public Author Author { get; set; }
    }   
}
