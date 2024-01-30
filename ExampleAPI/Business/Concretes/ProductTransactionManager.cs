using System.Linq.Expressions;
using ExampleAPI.Business.Abstracts;
using ExampleAPI.Business.Validations;
using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore.Query;

namespace ExampleAPI.Business.Concretes;

public class ProductTransactionManager : IProductTransactionService
{
    private readonly IProductTransactionRepository _productTransactionRepository;
    private readonly ProductTransactionValidations _productTransactionValidations;
    public ProductTransactionManager(IProductTransactionRepository productTransactionRepository, ProductTransactionValidations productTransactionValidations)
    {
        _productTransactionRepository = productTransactionRepository;
        _productTransactionValidations = productTransactionValidations;
    }
    public ProductTransaction Add(ProductTransaction productTransaction)
    {
        return _productTransactionRepository.Add(productTransaction);
    }

    public void DeleteById(Guid id)
    {
        var productTransaction = _productTransactionRepository.Get(u => u.Id == id);
        _productTransactionValidations.IfExists(productTransaction);
        _productTransactionRepository.Delete(productTransaction);
    }

    public ProductTransaction? Get(Expression<Func<ProductTransaction, bool>> predicate, Func<IQueryable<ProductTransaction>, IIncludableQueryable<ProductTransaction, object>>? include = null)
    {
        return _productTransactionRepository.Get(predicate, include);
    }
    public IList<ProductTransaction> GetAll(Expression<Func<ProductTransaction, bool>>? predicate = null, Func<IQueryable<ProductTransaction>, IIncludableQueryable<ProductTransaction, object>>? include = null, Func<IQueryable<ProductTransaction>, IOrderedQueryable<ProductTransaction>>? orderBy = null)
    {
        return _productTransactionRepository.GetAll(predicate, include, orderBy).ToList();
    }

    public ProductTransaction Update(ProductTransaction productTransaction)
    {
        return _productTransactionRepository.Update(productTransaction);
    }
}
