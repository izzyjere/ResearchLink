using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchLink.Core.Models
{
    public class ResearchComment : Comment
    {
        public override Guid? ResearchId { get; set; }
        [ForeignKey(nameof(ResearchId))]
        public Research? Research { get; set; }       
    }
}
