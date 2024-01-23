using System;
using System.Linq;
using System.Linq.Expressions;
using DatabaseExample.Entities;
using DatabaseExample.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
namespace DatabaseExample.Core;
public class BaseRepository<TEntity>
where TEntity : Entity
{
    protected ExampleDbContext context;
    public BaseRepository()
    {
        context = new ExampleDbContext();
    }

    public virtual IList<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate=null,
        Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>? include=null)
    {
        var result = context.Set<TEntity>().AsQueryable();
        if (predicate!=null)
            result= result.Where(predicate);
        if (include != null)
            result=include(result);
        return result.ToList();
    }

    public virtual TEntity? Get(Expression<Func<TEntity, bool>> predicate)
    {
        var result = context.Set<TEntity>().Where(predicate);
        Console.WriteLine(result.ToQueryString());
        return result.FirstOrDefault();
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
