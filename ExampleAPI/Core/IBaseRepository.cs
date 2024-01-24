using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace ExampleAPI.Core
{
	public interface IBaseRepository<TEntity>
		where TEntity: Entity
	{
		IEnumerable<TEntity> GetAll(
				Expression<Func<TEntity,bool>>? predicate=null, //filter
				Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>? include=null,//join
				Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>>? order=null //order
			);
        TEntity? Get(
            Expression<Func<TEntity, bool>> predicate, //filter
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null//join
        );
		TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TEntity entity);
    }
}

