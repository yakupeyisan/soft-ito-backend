using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
namespace DatabaseExample.Core;

public interface IBaseRepository<TEntity>
    where TEntity:Entity
{
    IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
    TEntity? Get(
        Expression<Func<TEntity, bool>> predicate,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null
        );
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Delete(TEntity entity);
}
