using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchLink.Core.Models
{
    public class ResearchGapComment : Comment
    {
        public override Guid? ResearchId { get; set; }
        [ForeignKey(nameof(ResearchId))]
        public ResearchGap? Research { get; set; }       
    }
}
