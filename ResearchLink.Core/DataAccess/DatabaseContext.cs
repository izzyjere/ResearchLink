namespace ResearchLink.Core.DataAccess;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Citation>();
        modelBuilder.Entity<Citation>()
            .HasOne(c => c.SourceArticle)
            .WithMany(a => a.Citations)
            .HasForeignKey(c => c.SourceArticleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Citation>()
            .HasOne(c => c.TargetArticle)
            .WithMany()
            .HasForeignKey(c => c.TargetArticleId)
            .OnDelete(DeleteBehavior.Restrict);
        var entityTypes = typeof(Document).Assembly.GetTypes()
         .Where(t => typeof(IEntity).IsAssignableFrom(t) && t != typeof(IEntity) && !t.IsAbstract && !t.IsInterface && t!=typeof(Citation));

        foreach (var entityType in entityTypes)
        {
            var entity = modelBuilder.Entity(entityType);

            // Automatically include any navigation properties
            foreach (var navigation in entityType.GetProperties().Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(ICollection<>) || p.PropertyType.IsAssignableTo(typeof(IEntity))))
            {
                entity.Navigation(navigation.Name).AutoInclude();
            }
        }
    }
}
