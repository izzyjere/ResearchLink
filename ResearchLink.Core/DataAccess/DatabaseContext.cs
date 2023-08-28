namespace ResearchLink.Core.DataAccess;

public class DatabaseContext : DbContext 
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {

    }
    public override int SaveChanges()
    {
          var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is IEntity && (
                               e.State == EntityState.Added
                                                  || e.State == EntityState.Modified));
        foreach (var entityEntry in entries)
        {
            ((IEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;
            if (entityEntry.State == EntityState.Added)
            {
                ((IEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
            }
        }
        return base.SaveChanges();  
    }
    //Configures the entity model.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         var entityTypes = typeof(Document).Assembly.GetTypes()
         .Where(t => typeof(IEntity).IsAssignableFrom(t) && t != typeof(IEntity) && !t.IsAbstract && !t.IsInterface);
        modelBuilder.Entity<Author>()
           .OwnsOne(a => a.Avatar, av =>
           {
               av.ToTable("ProfileImages");                 
               av.WithOwner();
           }); 
        modelBuilder.Entity<Research>()
           .OwnsOne(a => a.Document, av =>
           {
               av.ToTable("ResearchDocuments");               
               av.WithOwner();
           });
        modelBuilder.Entity<Comment>(comment =>
        {
           comment.OwnsMany(c => c.Replies, reply =>
           {
               reply.ToTable("CommentReplies");
               reply.WithOwner(r=>r.Comment);
           });
        });
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
