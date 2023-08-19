namespace ResearchLink.Core.Services.Impl;

[Service]
internal class CitationService : ServiceBase<Citation>, ICitationService
{
    public CitationService(DatabaseContext context) : base(context)
    {
        
    }
}
