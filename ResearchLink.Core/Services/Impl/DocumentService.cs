namespace ResearchLink.Core.Services.Impl;

[Service]
internal class DocumentService : ServiceBase<Document>, IDocumentService
{
    public DocumentService(DatabaseContext context) : base(context)
    {
    }
}
