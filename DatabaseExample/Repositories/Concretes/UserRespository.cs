using System;
using DatabaseExample.Core;
using DatabaseExample.Entities;
using DatabaseExample.Repositories.Abstracts;

namespace DatabaseExample.Repositories.Concretes;
public class UserRespository:BaseRepository<User>,IUserRepository
{
    
}

