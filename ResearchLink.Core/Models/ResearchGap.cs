namespace ResearchLink.Core.Models
{
    public class ResearchGap : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }               
        public string Proposer { get; set; }
        public string ProposerEmail { get; set; }
        public Guid ReseaechTopicId { get; set; }
        public ResearchTopic ResearchTopic { get; set; }
        public ICollection<ProposedAuthor> ProposedAuthors { get; set; }         
    }
}
