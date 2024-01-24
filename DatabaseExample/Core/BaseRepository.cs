using System.Linq.Expressions;
using DatabaseExample.Repositories.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
namespace DatabaseExample.Core;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
where TEntity : Entity
{
    protected ExampleDbContext context;
    public BaseRepository()
    {
        context = new ExampleDbContext();
    }
    public IQueryable<TEntity> Query()
    {
        return context.Set<TEntity>();
    }
    /// <summary>
    /// This function returned TEntity list by predicate and include and orderby
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="include"></param>
    /// <param name="orderBy"></param>
    /// <returns></returns>
    public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate=null,
        Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>? include=null,
        Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>>? orderBy=null)
    {
        var query = Query();
        if (predicate!=null)
            query = query.Where(predicate);
        if (include != null)
            query = include(query);
        if (orderBy != null)
            query = orderBy(query);
        return query;
    }

    public virtual TEntity? Get(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null
        )
    {
        var query = Query().Where(predicate);
        if (include != null) query = include(query);
        return query.FirstOrDefault();
    }
    public virtual TEntity Add(TEntity entity)
    {
        context.Entry<TEntity>(entity).State = EntityState.Added;
        context.SaveChanges();
        return entity;
    }
    public virtual TEntity Update(TEntity entity)
    {
        context.Entry<TEntity>(entity).State = EntityState.Modified;
        context.SaveChanges();
        return entity;
    }
    public virtual TEntity Delete(TEntity entity)
    {
        context.Entry<TEntity>(entity).State = EntityState.Deleted;
        context.SaveChanges();
        return entity;
    }
}
