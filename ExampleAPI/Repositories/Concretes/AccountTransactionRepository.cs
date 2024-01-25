using ExampleAPI.Contexts;
using ExampleAPI.Core;
using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;

namespace ExampleAPI.Repositories.Concretes;

public class AccountTransactionRepository : BaseRepository<AccountTransaction>, IAccountTransactionRepository
{
    public AccountTransactionRepository(ExampleDbContext context) : base(context)
    {
    }
}

