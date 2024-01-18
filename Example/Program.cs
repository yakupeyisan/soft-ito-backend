// See https://aka.ms/new-console-template for more information
using Example;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
/*
Banka Uygulaması
IBaseBank bank = new ZiraatBank();
bank.AddMoney(15);
bank.SpendMoney(5);
Console.WriteLine(bank.Money);
if(bank is ITosunBank)
{
var nBank = (bank as ITosunBank);
nBank.BuyChicken();
Console.WriteLine(bank.Money);
}
*/

/*
 User and Interfaces
TestUser test = new TestUser("Ali","1234");
Console.WriteLine(JsonConvert.SerializeObject(test));
IUser user = new Jobber();
user.UserName = "yakupeyisan";
user.Password = "1234";
user.IsActive = true;
if (user is IPersonal)
{
    var personal = (user as IPersonal);
    personal.Salary = 250;
    personal.SSN = "Social Number";
    personal.CalculateSalary(20);
    Console.WriteLine(JsonConvert.SerializeObject(personal));
}
if (user is IStudent)
{
    var student = (user as IStudent);
    student.Absenteeism = 10;
    student.Marks = 85;
    Console.WriteLine(JsonConvert.SerializeObject(student));
}
if (user is IJobber)
{
    var jobber = (user as IJobber);
    //jobber.WorkArea = "Yönetim";
    Console.WriteLine(JsonConvert.SerializeObject(jobber));
}

*/
var user=UserFactory.GetInstance(UserTypeEnum.Personal);
user.UserName = "yakupeyisan";
user.Password = "1234";
user.IsActive = true;
Console.WriteLine(user.GetType().Name);
if(user is IPersonal)
{
    var personal = (user as IPersonal);
    personal.Salary = 250;
    personal.CalculateSalaryWithDebt(20,100);
}
Console.WriteLine(JsonConvert.SerializeObject(user));

Console.ReadKey();

public static class UserExtensions
{
    public static void CalculateSalaryWithDebt(this IPersonal personal,short workHours ,int debt)
    {
        Console.WriteLine(personal.Salary*workHours-debt);
        //IDictionary,IList,IQueryable,Array Generic List
    }
}
