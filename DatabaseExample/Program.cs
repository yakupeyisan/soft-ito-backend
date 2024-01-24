// See https://aka.ms/new-console-template for more information
using DatabaseExample.Common;
using DatabaseExample.Entities;
using DatabaseExample.Repositories.Abstracts;
using DatabaseExample.Repositories.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
IUserRepository userRepository = new UserRespository();

CustomContainer.AddContainer<IUserRepository,UserRespository>();
CustomContainer.AddContainer<IPersonalRepository,PersonalRepository>();
CustomContainer.AddContainer<IStudentRepository,StudentRepository>();
CustomContainer.AddContainer<IJobberRepository,JobberRepository>();

var repository=CustomContainer.GetItem<IStudentRepository>();
Console.WriteLine(repository.GetType());
Console.ReadKey();
/*
 * 
 * Container Yapısı ve kullanımı

*/

Func<IQueryable<Personal>, IIncludableQueryable<Personal, object>> customInclude = (qPersonal) =>
{
    return qPersonal.Include(p => p.User);
};
Func<IQueryable<Personal>, IOrderedQueryable<Personal>> customOrderBy = (qPersonal) =>
{
    return qPersonal.OrderBy(p=>p.Salary).ThenBy(p=>p.User.FirstName);
};

PersonalRepository personalRespository = new();
Console.WriteLine(JsonConvert.SerializeObject(
    personalRespository
    .GetAll(predicate: p => p.Salary > 1000 && p.Salary < 1020 && p.User.IdentificationNumber == "232-57-8710", include: customInclude, orderBy: customOrderBy)
    .ToList()
    )
);

/*
*/
/*

Func<IQueryable<Personal>, IIncludableQueryable<Personal, object>> customInclude = (qPersonal) =>
{
    return qPersonal.Include(p => p.User);
};

PersonalRepository personalRespository = new();
Console.WriteLine(JsonConvert.SerializeObject(
    personalRespository.GetAll(include:customInclude))
   );

*/
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