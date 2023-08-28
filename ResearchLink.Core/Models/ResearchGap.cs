namespace ResearchLink.Core.Models
{
    public class ResearchGap : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ResearchQuestion { get; set; }
        public string? ResearchMethod { get; set; }        
        public string Proposer { get; set; }
        public string ProposerEmail { get; set; }
        public ICollection<ProposedAuthor> ProposedAuthors { get; set; }         
    }
}
