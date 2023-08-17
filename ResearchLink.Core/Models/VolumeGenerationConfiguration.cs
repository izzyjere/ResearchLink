global using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResearchLink.Core.Models
{
    public class VolumeGenerationConfiguration : Entity
    {
        public Guid JournalId { get; set; }
        [ForeignKey(nameof(JournalId))]
        public Journal Journal { get; set; }
        [Required]
        [Range(2022, int.MaxValue,ErrorMessage ="Start year must be on/after 2022.")]
        public int StartYear { get; set; } = DateTime.Now.Year;
        public int EndYear { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "You must select generation mode.")]
        public VolumeGenerationMode Mode { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "You must select generation frequency.")]
        public VolumeGenerationFrequency Frequency { get; set; }
        [NotMapped]
        public bool GenerateNow { get; set; }
    }
}
