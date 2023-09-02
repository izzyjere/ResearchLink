using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchLink.Core.Models
{
    public class ResearchGapComment : Comment
    {
   
        [ForeignKey(nameof(ResearchId))]
        public ResearchGap Research { get; set; }
    }
}
