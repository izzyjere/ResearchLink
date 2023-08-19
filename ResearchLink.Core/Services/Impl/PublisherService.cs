namespace ResearchLink.Core.Services.Impl;

[Service]
internal class PublisherService : ServiceBase<Publisher>, IPublisherService
{
    public PublisherService(DatabaseContext context) : base(context)
    {
    }
}
