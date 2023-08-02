namespace ResearchLink.Core.Services.Impl;

[Service]
internal class AuthorArticleService : ServiceBase<AuthorArticle>, IAuthorArticleService
{
    public AuthorArticleService(DatabaseContext context) : base(context)
    {
    }
}