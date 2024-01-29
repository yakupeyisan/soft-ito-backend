using System.Linq.Expressions;
using ExampleAPI.Business.Abstracts;
using ExampleAPI.Business.Validations;
using ExampleAPI.Core.Abstracts;
using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore.Query;

namespace ExampleAPI.Business.Concretes;
public class UserManager : IUserService
{
    public readonly IUserRepository _userRepository;
    private readonly IAccountTransactionRepository _accountTransactionRepository;
    private readonly UserValidations _userValidations;

    public UserManager(IUserRepository userRepository,IAccountTransactionRepository accountTransactionRepository, UserValidations userValidations)
    {
        _userRepository = userRepository;
        _accountTransactionRepository = accountTransactionRepository;
        _userValidations = userValidations;
    }

    public User Add(User user)
    {
        _userValidations.CheckFirstName(user);
        _userValidations.CheckIdentity(user);
        return _userRepository.Add(user);
    }

    public void DeleteById(Guid id)
    {
        var user=_userRepository.Get(u=>u.Id==id);
        _userValidations.IfExists(user);
        _userRepository.Delete(user);
    }
    public User? Get(Expression<Func<User, bool>> predicate, Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null)
    {
        return _userRepository.Get(predicate,include);
    }

    public IList<User> GetAll(Expression<Func<User, bool>>? predicate = null, Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null, Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null)
    {
        return _userRepository.GetAll(predicate,include,orderBy).ToList();
    }

    public User Update(User user)
    {
        _userValidations.CheckFirstName(user);
        _userValidations.CheckIdentity(user);
        return _userRepository.Update(user);
    }
    public AccountTransaction AddBalance(AccountTransaction accountTransaction){
        return _accountTransactionRepository.Add(accountTransaction);
    }
}