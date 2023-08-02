namespace ResearchLink.Core.Services;

internal abstract class CrudServiceBase<TEntity> where TEntity : class, IEntity
{
    private readonly DatabaseContext _context;
    public CrudServiceBase(DatabaseContext context)
    {
        _context = context;
    }
    public IQueryable<TEntity> Table => _context.Set<TEntity>();
    public TEntity? Get(Guid id)
    {
       return Table.FirstOrDefault(e=>e.Id==id);
    }
    public Result Save(TEntity entity)
    {
        try
        {
            if(entity.Id == Guid.Empty)
            {
                _context.Set<TEntity>().Add(entity);
            }
            else
            {
                _context.Set<TEntity>().Update(entity);
            }
           
            return _context.SaveChanges()>0 ? Result.Success("Item Saved!") : Result.Failure("Failed to save this item.");

        }
        catch (Exception e)
        {
            e.PrintStackTrace();
            return Result.Failure(e.Message);
        }
   }
}

