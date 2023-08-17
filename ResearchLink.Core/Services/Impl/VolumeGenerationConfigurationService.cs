using Microsoft.Extensions.Logging;

namespace ResearchLink.Core.Services.Impl
{
    [Service]
    internal class VolumeGenerationConfigurationService : ServiceBase<VolumeGenerationConfiguration>, IVolumeGenerationConfigurationService
    {
        ILogger<VolumeGenerationConfigurationService> _logger;
        public VolumeGenerationConfigurationService(DatabaseContext context,ILogger<VolumeGenerationConfigurationService> logger) : base(context)
        {
            _logger = logger;
        }
        public async Task ExecuteAutomaticVolumeGenerationJob()
        {
            var journals = await GetJournalsWithAutomaticVolumeGenerationConfigAsync();
            _logger.LogInformation($"Found {journals.Count} journals with automatic volume generation configuration.");
            foreach (var journal in journals)
            {
                var config = journal.VolumeGenerationConfiguration;
                if (IsVolumeGenerationApplicable(config))
                {
                    await GenerateVolumeAsync(journal);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exception (log, notify, etc.)
                Console.WriteLine($"Error saving changes: {ex.Message}");
            }
        }

        private async Task<List<Journal>> GetJournalsWithAutomaticVolumeGenerationConfigAsync()
        {
            return await _context.Set<Journal>()
                .Include(j => j.VolumeGenerationConfiguration)
                .Where(journal => journal.VolumeGenerationConfiguration.Mode == VolumeGenerationMode.Automatic)
                .ToListAsync();
        }

        private bool IsVolumeGenerationApplicable(VolumeGenerationConfiguration config)
        {
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            if (currentYear < config.StartYear || (currentYear > config.EndYear && config.EndYear !=0 ))
            {
                return false;
            }

            switch (config.Frequency)
            {
                case VolumeGenerationFrequency.Yearly:
                    return true;
                case VolumeGenerationFrequency.Monthly:
                    return currentMonth == 1 || currentMonth == 3 || currentMonth == 5 ||
                           currentMonth == 7 || currentMonth == 8 || currentMonth == 10 || currentMonth == 12;
                case VolumeGenerationFrequency.Quarterly:
                    return currentMonth == 1 || currentMonth == 4 || currentMonth == 7 || currentMonth == 10;
                case VolumeGenerationFrequency.SemiAnnually:
                    return currentMonth == 1 || currentMonth == 7;
                default:
                    return false;
            }
        }

        private async Task GenerateVolumeAsync(Journal journal)
        {
            try
            {
                var lastVolume = await _context.Set<Volume>()
                    .Where(v => v.JournalId == journal.Id)
                    .OrderByDescending(v => v.Number)
                    .FirstOrDefaultAsync();                
                int currentYear = DateTime.Now.Year;
                if (journal.VolumeGenerationConfiguration.Frequency == VolumeGenerationFrequency.Yearly && lastVolume?.Year == currentYear)
                {
                    _logger.LogInformation($"Volume {lastVolume.Number} for journal {journal.Name} already exists.");
                    return;
                }

                var volume = new Volume
                {
                    JournalId = journal.Id,
                    Number = lastVolume?.Number + 1 ?? 1,
                    Year = currentYear,
                    CreatedDate = DateTime.Now
                };

                _context.Set<Volume>().Add(volume);
                _logger.LogInformation($"Generated volume {volume.Number} for journal {journal.Name}.");
            }
            catch (Exception ex)
            {
                // Handle exception (log, notify, etc.)
                Console.WriteLine($"Error generating volume: {ex.Message}");
            }
        }

    }
}
