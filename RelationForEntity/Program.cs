// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

IList<User> listUsers= new List<User>();
IList<Card> cards= new List<Card>();
IQueryable<User> queryableUsers= new List<User>().AsQueryable();

listUsers.Where(u=>u.Id==0);
queryableUsers.Where(u=>u.Id==0);

listUsers.First();
listUsers.First(u=>u.Id>5);
listUsers.Where(u=>u.Id>5).First();
listUsers.FirstOrDefault(u=>u.Id>5);
listUsers.Where(u=>u.Id>5).FirstOrDefault();

var groups=listUsers.GroupBy(u=>u.Name);
listUsers.Select(u=>u.Name);
listUsers.Join(
    cards,
    u=>u.Id,
    c=>c.UserId,
    (u,c)=>new ViewDto(){
    Id=u.Id,
    Name=u.Name,
    CardName=c.Name
});

var distinctUsers= listUsers.DistinctBy(u=>u.Name);
listUsers.GroupJoin(
    cards,
    u=>u.Id,
    c=>c.UserId,
    (u,cards)=>new ViewDto2(){
    Id=u.Id,
    Name=u.Name,
    Cards=cards.AsQueryable().Where(c=>c.Id>5).ToList()
});
public class User{
    public int Id { get; set; }
    public string Name { get; set; }
}
public class Card{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
}
public class ViewDto{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CardName {get;set;}
}
public class ViewDto2{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Card> Cards {get;set;}
}