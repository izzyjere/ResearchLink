namespace ResearchLink.Core.Services.Impl
{
    [Service]
    internal class ResearchGapCommentService : ServiceBase<ResearchGapComment>, IResearchGapCommentService
    {
        public ResearchGapCommentService(DatabaseContext context) : base(context)
        {
        }
    } 
}
