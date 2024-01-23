// See https://aka.ms/new-console-template for more information
using DatabaseExample.Entities;
using DatabaseExample.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
PersonalRepository personalRespository = new();
Console.WriteLine(JsonConvert.SerializeObject(
    personalRespository.GetAll(include:personal=>personal.Include(p=>p.User)))
   );
/*
 * user ve personel ekleme
UserRespository userRespository = new();
var userJson = File.ReadAllText(@"/Users/derslik1-01/Projects/Example/DatabaseExample/DummyData/users.json");
var users = JsonConvert.DeserializeObject<List<User>>(userJson);
users.ForEach(user =>
{
    userRespository.Add(user);
});
var userArray=userRespository.GetAll().ToArray();
PersonalRepository personalRespository = new();
var personalJson = File.ReadAllText(@"/Users/derslik1-01/Projects/Example/DatabaseExample/DummyData/personals.json");
var personals = JsonConvert.DeserializeObject<List<Personal>>(personalJson);
if (userArray == null) return;
int index = 0;
personals.ForEach(personal =>
{
    personal.UserId = userArray[index].Id;
    personalRespository.Add(personal);
    index++;
});
*/
/*
 * user ekleme
var userJson=File.ReadAllText(@"/Users/derslik1-01/Projects/Example/DatabaseExample/DummyData/users.json");
var users = JsonConvert.DeserializeObject<List<User>>(userJson);
users.ForEach(user =>
{
    userRespository.Add(user);
});
Console.WriteLine(JsonConvert.SerializeObject(userRespository.GetAll()));
*/
/*
UserRespository userRespository = new();
userRespository.Add(new()
{
    FirstName = "Yakup",
    LastName = "Eyisan",
    UserName = "yakupeyisan",
    Password = "1234",
    IsActive = true,
    IdentificationNumber = "11223344551"
});
var user = userRespository.Get(user=>user.FirstName.StartsWith("a"));
Console.WriteLine(JsonConvert.SerializeObject(user)); ;

Console.WriteLine(JsonConvert.SerializeObject(userRespository.GetAll()));

/*
 
ExampleDbContext db = new();

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
/*
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
*/

Console.ReadKey();