using System;
using System.Diagnostics;
using System.Linq.Expressions;
using ExampleAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ExampleAPI.Core;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : Entity
{
    protected ExampleDbContext _context;
    public BaseRepository(ExampleDbContext context)
    {
        _context = context;
    }
    protected IQueryable<TEntity> Query()
    {
        return _context.Set<TEntity>();
    }
    public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? order = null)
    {
        var queryable = Query();
        if (predicate != null) queryable = queryable.Where(predicate);
        if (include != null) queryable = include(queryable);
        if (order != null) queryable = order(queryable);
        Debug.WriteLine(queryable.ToQueryString());
        return queryable;
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        var queryable = Query().Where(predicate);
        if (include != null) queryable = include(queryable);
        return queryable.FirstOrDefault();
    }
    public TEntity Add(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        _context.SaveChanges();
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        _context.SaveChanges();
        return entity;
    }
}

