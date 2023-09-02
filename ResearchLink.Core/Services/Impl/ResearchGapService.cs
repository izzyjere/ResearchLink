namespace ResearchLink.Core.Services.Impl
{
    [Service]
    internal class ResearchGapService : ServiceBase<ResearchGap>, IResearchGapService
    {
        public ResearchGapService(DatabaseContext context) : base(context)
        {
        }
    }

}
