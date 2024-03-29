﻿using ResearchLink.Core.Shared;

namespace ResearchLink.Core.Services;

internal abstract class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class, IEntity
{
    protected readonly DatabaseContext _context;
    public ServiceBase(DatabaseContext context)
    {
        _context = context;
    }
    public IQueryable<TEntity> Table => _context.Set<TEntity>();
    public TEntity? Get(Guid id)
    {
        return Table.FirstOrDefault(e => e.Id==id);
    }
    public Result Delete(Guid id)
    {
        try
        {
            var record = Get(id);
            if (record != null)
            {
                _context.Set<TEntity>().Remove(record);
                return _context.SaveChanges()>0 ? Result.Success("Item Deleted!") : Result.Failure("Failed to save this item.");
            }
            return Result.Failure("Delete failed! Record not found.");
        }
        catch (Exception e)
        {
            e.PrintStackTrace();
            return Result.Failure(e.Message);
        }
    }
    public Result Save(TEntity entity)
    {
        try
        {
            if (entity.Id == Guid.Empty)
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

    public Result Save(IEnumerable<TEntity> entities)
    {

        try
        {
            foreach (var entity in entities)
            {
                if (entity.Id == Guid.Empty)
                {
                    _context.Set<TEntity>().Add(entity);
                }
                else
                {
                    _context.Set<TEntity>().Update(entity);
                }
            }            

            return _context.SaveChanges()>0 ? Result.Success("Items Saved!") : Result.Failure("Failed to save this item.");

        }
        catch (Exception e)
        {
            e.PrintStackTrace();
            return Result.Failure(e.Message);
        }
    }
}

