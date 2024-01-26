using System;
namespace RelationForEntity;

public class User
{
    public int Id { get; set; }
    public int DepartmentId { get; set; } 
    public string UserName { get; set; }
    public string FistName { get; set; }
    public string LastName { get; set; }
    public Department Department { get; set; }
    public ICollection<UserTag> UserTags { get; set; }
    public ICollection<Card> Cards { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<User> Users { get; set; }
}
public class UserTag
{
    public int Id { get; set; }
    public int TagId { get; set; }
    public int UserId { get; set; }
    public Tag Tag { get; set; }
    public User User { get; set; }
}
public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<UserTag> TagUsers { get; set; }
}
public class Card
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string IBAN { get; set; }
    public User User { get; set; }
}