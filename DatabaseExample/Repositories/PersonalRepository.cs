using System;
using System.Linq.Expressions;
using DatabaseExample.Core;
using DatabaseExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseExample.Repositories;
public class PersonalRepository:BaseRepository<Personal>
{
	public PersonalRepository()
	{
	}
    
    public IList<Personal> GetAllV2(Expression<Func<Personal, bool>>? predicate = null)
    {
        /*
        var result = from personal in context.Personals
                     join user in context.Users on personal.UserId equals user.Id
                     select new Personal
                     {
                         Id=personal.Id,
                         Salary=personal.Salary,
                         SSN=personal.SSN,
                         UserId=user.Id,
                         User=user
                     };
        return result.ToList();
        */
        return context.Personals.Include(personal => personal.User).ToList();
    }

}
