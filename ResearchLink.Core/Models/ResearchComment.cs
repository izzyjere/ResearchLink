using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace ResearchLink.Core.Models
{
    public class ResearchComment : Comment
    {
        public override Guid ResearchId { get; set; }
        [ForeignKey(nameof(ResearchId))]
        public Research Research { get; set; }   
        
        public void SetResearchId()
        {
            if (Research != null)
            {
                ResearchId = base.ResearchId;
            }
        }
    }
}
