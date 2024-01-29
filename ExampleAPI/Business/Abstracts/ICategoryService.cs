using System.Linq.Expressions;
using ExampleAPI.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace ExampleAPI.Business.Abstracts;
public interface ICategoryService
{
    IList<Category> GetAll(
            Expression<Func<Category, bool>>? predicate = null,
            Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null,
            Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null
        );
    Category? Get(
        Expression<Func<Category, bool>> predicate,
        Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null
    );
    Category Add(Category entity);
    Category Update(Category entity);
    void DeleteById(Guid id); 
}
