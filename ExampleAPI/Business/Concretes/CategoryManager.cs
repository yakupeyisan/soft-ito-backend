using System.Linq.Expressions;
using ExampleAPI.Business.Abstracts;
using ExampleAPI.Business.Validations;
using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore.Query;

namespace ExampleAPI.Business.Concretes;
public class CategoryManager : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly CategoryValidations _categoryValidations;
    public CategoryManager(ICategoryRepository categoryRepository,CategoryValidations categoryValidations){
        _categoryRepository=categoryRepository;
        _categoryValidations=categoryValidations;
    }
    public Category Add(Category category)
    {
        return _categoryRepository.Add(category);
    }

    public void DeleteById(Guid id)
    {
    var category=_categoryRepository.Get(u=>u.Id==id);
    _categoryValidations.IfExists(category);
    _categoryRepository.Delete(category);
    }

    public Category? Get(Expression<Func<Category, bool>> predicate, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null)
    {
        return _categoryRepository.Get(predicate,include);
    }

    public IList<Category> GetAll(Expression<Func<Category, bool>>? predicate = null, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null, Func<IQueryable<Category>, IOrderedQueryable<Category>>? orderBy = null)
    {
        return _categoryRepository.GetAll(predicate,include,orderBy).ToList();
    }

    public Category Update(Category category)
    {
        return _categoryRepository.Update(category);
    }
}
