namespace ResearchLink.Core.Services.Impl
{
    [Service]
    internal class ResearchService : ServiceBase<Research>, IResearchService
    {
        public ResearchService(DatabaseContext context) : base(context)
        {
        }
    } 

}
