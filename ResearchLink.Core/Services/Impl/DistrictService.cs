namespace ResearchLink.Core.Services.Impl;

[Service]
internal class DistrictService : ServiceBase<District>, IDistrictService
{
    public DistrictService(DatabaseContext context) : base(context)
    {
    }
}
