namespace ResearchLink.Core.Services.Impl
{
    [Service]
    internal class VolumeGenerationConfigurationService : ServiceBase<VolumeGenerationConfiguration>, IVolumeGenerationConfigurationService
    {
        public VolumeGenerationConfigurationService(DatabaseContext context) : base(context)
        {
        }
        public async Task ExecuteAutomaticVolumeGenerationJob()
        {
            var journals = await _context.Set<Journal>().Include(j => j.VolumeGenerationConfiguration).ToListAsync();
            foreach (var journal in journals)
            {
                if (journal.VolumeGenerationConfiguration == null) continue;
                if (journal.VolumeGenerationConfiguration.Mode == VolumeGenerationMode.Automatic)
                {   var config = journal.VolumeGenerationConfiguration;
                    switch (config.Frequency)
                    {
                        case VolumeGenerationFrequency.Yearly:
                            if (DateTime.Now.Year >= config.StartYear && DateTime.Now.Year <= config.EndYear)
                            {
                                await GenerateVolume(journal);
                            }
                            break;
                        case VolumeGenerationFrequency.Monthly:
                            if (DateTime.Now.Year >= config.StartYear && DateTime.Now.Year <= config.EndYear)
                            {
                                if (DateTime.Now.Month == 1 || DateTime.Now.Month == 3 || DateTime.Now.Month == 5 ||
                                                                       DateTime.Now.Month == 7 || DateTime.Now.Month == 8 || DateTime.Now.Month == 10 ||
                                                                                                          DateTime.Now.Month == 12)
                                {
                                    await GenerateVolume(journal);
                                }
                            }
                            break;
                        case VolumeGenerationFrequency.Quarterly:
                            if (DateTime.Now.Year >= config.StartYear && DateTime.Now.Year <= config.EndYear)
                            {
                                if (DateTime.Now.Month == 1 || DateTime.Now.Month == 4 || DateTime.Now.Month == 7 ||
                                                                       DateTime.Now.Month == 10)
                                {
                                    await GenerateVolume(journal);
                                }
                            }
                            break;
                        case VolumeGenerationFrequency.SemiAnnually:
                            if (DateTime.Now.Year >= config.StartYear && DateTime.Now.Year <= config.EndYear)
                            {
                                if (DateTime.Now.Month == 1 || DateTime.Now.Month == 7)
                                {
                                    await GenerateVolume(journal);
                                }
                            }
                            break;  
                    }                   
                    await _context.SaveChangesAsync();
                }
            }
              
        }

        private async Task GenerateVolume(Journal journal)
        {
            var lastVolume = await _context.Set<Volume>().Where(v => v.JournalId == journal.Id).OrderByDescending(v => v.Number).FirstOrDefaultAsync();
            if (lastVolume == null)
            {
                var volume = new Volume
                {
                    JournalId = journal.Id,
                    Number = 1,
                    Year = DateTime.Now.Year,
                    CreatedDate = DateTime.Now
                };
                _context.Set<Volume>().Add(volume);
            }
            else
            {
                var volume = new Volume
                {
                    JournalId = journal.Id,
                    Number = lastVolume.Number + 1,
                    Year = DateTime.Now.Year,
                    CreatedDate = DateTime.Now
                };
                _context.Set<Volume>().Add(volume);
            }
        }
    }     
}
