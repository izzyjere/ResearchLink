using System.ComponentModel;

namespace ResearchLink.Core.Models;

public enum ResearchType
{
    [Description("Select research type")]
    None,
    [Description("Journal Article")]
    JournalArticle,
    [Description("Project")]
    Project,
    [Description("Book")]
    Book,
    [Description("Conference & Meetings")]
    Conference,
}
