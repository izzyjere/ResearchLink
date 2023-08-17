global using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchLink.Core.Models
{
    public class VolumeGenerationConfiguration : Entity
    {
        public Guid JournalId { get; set; }
        [ForeignKey(nameof(JournalId))]
        public Journal Journal { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public VolumeGenerationMode Mode { get; set; }
        public VolumeGenerationFrequency Frequency { get; set; }
    }
}
