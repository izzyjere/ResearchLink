namespace ResearchLink.Core.Services;

public interface IVolumeGenerationConfigurationService : IServiceBase<VolumeGenerationConfiguration>
{
    Task ExecuteAutomaticVolumeGenerationJob();
}
