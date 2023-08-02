namespace ResearchLink.Core.Services.Impl
{
    [Service]
    internal class VolumeService : ServiceBase<Volume>, IVolumeService
    {
        public VolumeService(DatabaseContext context) : base(context)
        {
        }
    }
}
