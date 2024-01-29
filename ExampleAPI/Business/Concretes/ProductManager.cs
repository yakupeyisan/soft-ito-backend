using System.Linq.Expressions;
using ExampleAPI.Business.Abstracts;
using ExampleAPI.Business.Validations;
using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore.Query;

namespace ExampleAPI.Business.Concretes;

public class ProductManager : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ProductValidations _productValidations;
    public ProductManager(IProductRepository productRepository, ProductValidations productValidations)
    {
        _productRepository = productRepository;
        _productValidations = productValidations;
    }
    public Product Add(Product product)
    {
        return _productRepository.Add(product);
    }

    public void DeleteById(Guid id)
    {
        var product = _productRepository.Get(u => u.Id == id);
        _productValidations.IfExists(product);
        _productRepository.Delete(product);
    }

    public Product? Get(Expression<Func<Product, bool>> predicate, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null)
    {
        return _productRepository.Get(predicate, include);
    }
    public IList<Product> GetAll(Expression<Func<Product, bool>>? predicate = null, Func<IQueryable<Product>, IIncludableQueryable<Product, object>>? include = null, Func<IQueryable<Product>, IOrderedQueryable<Product>>? orderBy = null)
    {
        return _productRepository.GetAll(predicate, include, orderBy).ToList();
    }

    public Product Update(Product product)
    {
        return _productRepository.Update(product);
    }
}
