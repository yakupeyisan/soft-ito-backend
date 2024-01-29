using System.Linq.Expressions;
using ExampleAPI.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace ExampleAPI.Business.Abstracts;

public interface IProductService
{
    IList<Product> GetAll(
            Expression<Func<Product, bool>>? predicate = null,
            Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null,
            Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null
        );
    Product? Get(
        Expression<Func<Product, bool>> predicate,
        Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null
    );
    Product Add(Product entity);
    Product Update(Product entity);
    void DeleteById(Guid id); 
}