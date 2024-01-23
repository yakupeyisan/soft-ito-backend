using System;
namespace DatabaseExample.Entities;
#nullable disable
public abstract class Entity
{
}

public abstract class Entity<PKey>:Entity
{
    public PKey Id { get; set; }
}

public class User:Entity<Guid>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string IdentificationNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }
}

public class Personal : Entity<Guid>
{
    public Guid UserId { get; set; }
    public decimal Salary { get; set; }
    public string SSN { get; set; }
    public virtual User User { get; set; }
}

public class Student : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string Number { get; set; }
    public byte Marks { get; set; }
    public byte Absenteeism { get; set; }
    public virtual User User { get; set; }
}

public class Jobber : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string Plate { get; set; }
    public string WorkArea { get; set; }
    public virtual User User { get; set; }
}