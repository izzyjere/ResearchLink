namespace ResearchLink.Core.Services.Impl
{
    [Service]
    internal class ResearchTopicService  : ServiceBase<ResearchTopic>, IResearchTopicService
    {
        public ResearchTopicService(DatabaseContext context) : base(context)
        {
        }
    }
    
}
