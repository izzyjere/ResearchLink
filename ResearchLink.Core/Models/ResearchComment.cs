using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace ResearchLink.Core.Models
{
    public class ResearchComment : Comment
    {
     
        [ForeignKey(nameof(ResearchId))]
        public Research Research { get; set; }       
    }
}
