namespace ResearchLink.Core.Services.Impl
{
    [Service]
    internal class CommentService : ServiceBase<Comment>, ICommentService
    {
        public CommentService(DatabaseContext context) : base(context)
        {
        }
    }   
}
