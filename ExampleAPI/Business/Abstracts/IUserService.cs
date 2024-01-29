using System.Linq.Expressions;
using ExampleAPI.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace ExampleAPI.Business.Abstracts;

public interface IUserService
{
    IList<User> GetAll(
            Expression<Func<User, bool>>? predicate = null,
            Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
            Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null
        );
    User? Get(
        Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null
    );
    User Add(User entity);
    User Update(User entity);
    void DeleteById(Guid id);
    AccountTransaction AddBalance(AccountTransaction accountTransaction);
}
