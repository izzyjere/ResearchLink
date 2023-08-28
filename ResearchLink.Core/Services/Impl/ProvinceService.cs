namespace ResearchLink.Core.Services.Impl
{
    [Service]
    internal class ProvinceService : ServiceBase<Province>, IProvinceService
    {
        public ProvinceService(DatabaseContext context) : base(context)
        {
        }
    }
}
