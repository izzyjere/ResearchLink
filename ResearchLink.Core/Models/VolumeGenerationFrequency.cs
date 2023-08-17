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
        SemiAnually,
        [Description("Every Year")]
        Yearly
    }
}
