using System;
using DatabaseExample.Core;

namespace DatabaseExample.Entities;
#nullable disable
public class User:Entity<Guid>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string IdentificationNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }
}
