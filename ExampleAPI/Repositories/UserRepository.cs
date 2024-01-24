using System;
using ExampleAPI.Contexts;

namespace ExampleAPI.Repositories;
public class UserRepository:IUserRepository
{
	protected ExampleDbContext Context;
	public UserRepository(ExampleDbContext context)
	{
		Context = context;
	}
}