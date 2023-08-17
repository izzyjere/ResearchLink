namespace ResearchLink.Core.Models
{
    public enum VolumeGenerationFrequency
    {
        [Description("Select frequency")]
        None,
        [Description("Every Month")]
        Monthly,
        [Description("Every 3 Months")]
        Quarterly,
        [Description("Every 6 Months")]
        SemiAnnually,
        [Description("Every Year")]
        Yearly
        
    }
}
