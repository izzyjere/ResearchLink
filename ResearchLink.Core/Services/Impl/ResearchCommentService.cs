namespace ResearchLink.Core.Services.Impl
{
    [Service]
    internal class ResearchCommentService : ServiceBase<ResearchComment>, IResearchCommentService
    {
        public ResearchCommentService(DatabaseContext context) : base(context)
        {
        }
    }   
}
