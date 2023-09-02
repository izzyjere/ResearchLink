namespace ResearchLink.Core.Services.Impl
{
    [Service]
    internal class ResearchGapCommentService : ServiceBase<ResearchGapComment>, IResearchGapCommentService
    {
        public ResearchGapCommentService(DatabaseContext context) : base(context)
        {
        }
    } 
    [Service]
    internal class ResearchCommentService : ServiceBase<ResearchComment>, IResearchCommentService
    {
        public ResearchCommentService(DatabaseContext context) : base(context)
        {
        }
    }   
}
