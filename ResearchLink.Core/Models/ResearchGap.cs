namespace ResearchLink.Core.Models
{
    public class ResearchGap : Entity
    {
        [Required(ErrorMessage ="Please provide a title.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please provide a short description.")]
        [MaxLength(10000, ErrorMessage = "Description cannot be more than 10000 characters")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Please provide your (org) name.")]
        public string Proposer { get; set; }
        [Required(ErrorMessage = "Please provide your email.")]
        public string ProposerEmail { get; set; }
        [Required]
        [RegularExpression("^((?!00000000-0000-0000-0000-000000000000).)*$", ErrorMessage = "Please select a district")]
        public Guid DistrictId { get; set; }
        public District District { get; set; }
        [Required]
        [RegularExpression("^((?!00000000-0000-0000-0000-000000000000).)*$", ErrorMessage = "Please select a research topic")]
        public Guid ResearchTopicId { get; set; }
        public ResearchTopic ResearchTopic { get; set; }
        public ICollection<ProposedAuthor> ProposedAuthors { get; set; }    
        public ICollection<ResearchGapComment> Comments { get; set; }
        public FileModel? Document { get; set; }
        public ResearchGap()
        {
            ProposedAuthors = new List<ProposedAuthor>();
            Comments = new List<ResearchGapComment>();
        }
    }
}
