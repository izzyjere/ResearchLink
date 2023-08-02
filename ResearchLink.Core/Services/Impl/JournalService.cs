namespace ResearchLink.Core.Services.Impl
{
    [Service]
    internal class JournalService : ServiceBase<Journal>, IJournalService
    {
        public JournalService(DatabaseContext context) : base(context)
        {
        }
    }
}
