namespace ResearchLink.Core.DataAccess;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
    {
            
    }
   
}
