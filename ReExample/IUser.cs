namespace ReExample;
public interface IUser
{
    string UserName { get; set; }
    string Password { get; set; }
    string IdentificationNumber { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    bool IsActive { get; set; }
}

public interface IPersonal:IUser
{
    decimal Salary { get; set; }
    string SSN { get; set; }
    decimal CalculateSalary(int workHours);         
}
public interface IStudent : IUser
{
    string Number { get; set; }
    byte Marks { get; set; }
    byte Absenteeism { get; set; }
}
public interface IJobber : IUser
{
    string Plate { get; set; }
    string WorkArea { get; set; }
}
public abstract class User : IUser
{
    [Search]
    public string UserName { get; set; }
    [Search(MatchTypes.Full)]
    public string Password { get; set; }
    [Search(MatchTypes.StartsWith)]
    public string IdentificationNumber { get; set; }
    [Search]
    public string FirstName { get; set; }
    [Search]
    public string LastName { get; set; }
    public bool IsActive { get; set; }
}

public class Personal : User, IPersonal
{
    [Search]
    public decimal Salary { get; set; }
    [Search]
    public string SSN { get; set; }

    public decimal CalculateSalary(int workHours)
    {
        return workHours * Salary;
    }
}
public class Student : User, IStudent
{
    public string Number { get; set; }
    public byte Marks { get; set; }
    public byte Absenteeism { get; set; }
}
public class Jobber : User, IJobber
{
    public string Plate { get; set; }
    public string WorkArea { get; set; }
}