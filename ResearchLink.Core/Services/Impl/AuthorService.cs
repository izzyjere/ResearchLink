namespace ResearchLink.Core.Services.Impl
{
    [Service]
    internal class AuthorService : ServiceBase<Author>, IAuthorService
    {
        public AuthorService(DatabaseContext context) : base(context)
        {
        }
    }
}
