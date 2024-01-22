// See https://aka.ms/new-console-template for more information
using DatabaseExample.Repositories;
using Newtonsoft.Json;

ExampleDbContext db = new();
/*
 * db.Users.Add(new DatabaseExample.Entities.User()
{
    FirstName = "Yakup",
    LastName = "Eyisan",
    UserName = "yakupeyisan",
    Password = "1234",
    IsActive = true,
    IdentificationNumber="11223344551"
}) ;

db.SaveChanges();*/

//var user = db.Users.Where(user => user.IdentificationNumber == "112233445512").First();
var user = db.Users.Where(user => user.IdentificationNumber == "11223344551").FirstOrDefault();

if (user != null)
{
    user.Password = "12345";
    db.Users.Update(user);
    db.SaveChanges();
    db.Users.Remove(user);
    db.SaveChanges();
}

var users=db.Users.ToList();

Console.WriteLine(JsonConvert.SerializeObject(users));
Console.ReadKey();