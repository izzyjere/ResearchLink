namespace ResearchLink.Core.Services.Impl
{
    [Service]
    internal class ArticleService : ServiceBase<Article>, IArticleService
    {
        public ArticleService(DatabaseContext context) : base(context)
        {
        }
    }

}
