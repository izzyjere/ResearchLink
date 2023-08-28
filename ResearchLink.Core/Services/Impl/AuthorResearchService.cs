namespace ResearchLink.Core.Services.Impl;

[Service]
internal class AuthorResearchService : ServiceBase<AuthorResearch>, IAuthorResearchService
{
    public AuthorResearchService(DatabaseContext context) : base(context)
    {
    }
}