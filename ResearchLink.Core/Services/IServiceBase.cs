namespace ResearchLink.Core.Services;

public interface IServiceBase<TEntity> where TEntity : class, IEntity
{
    IQueryable<TEntity> Table { get; }
    Result Delete(Guid id);
    TEntity? Get(Guid id);
    Result Save(TEntity entity);
}