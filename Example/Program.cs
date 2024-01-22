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




/*
User[] users;
List<User> usersList;


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

*/
/*
// [12,15,8]
// [33,12,25]
int[] numbers = new int[3];
numbers[0] = 12;
numbers[1] = 15;
numbers[2] = 8;

Console.WriteLine(JsonConvert.SerializeObject(numbers));
Console.WriteLine(numbers[2]);

bool[] list = new bool[5];

Console.WriteLine(JsonConvert.SerializeObject(list));
IPersonal[] personals = new IPersonal[2];
Console.WriteLine(JsonConvert.SerializeObject(personals));


List<int> numberList = new List<int>();
numberList.Add(1);
numberList.Add(2);
numberList.Add(3);
numberList.Add(5);
numberList.Add(1);
Console.WriteLine(JsonConvert.SerializeObject(numberList));
var i = numberList.FindAll(num => num == 1);
*/
/*
 List<int> findList(int x){
    List<int> findList = new List<int>();
    foreach (int number in numberList)
    {
        if (number == x)
        {
            findList.Add(number);
        }
    }
    return findList;
}
Console.WriteLine(JsonConvert.SerializeObject(findList(1)));
*/
/*
IList<IUser> userList = new List<IUser>();
userList.Add(new Volunteer("yakupeyisan","1234",false,"ssn",250));
var user=userList.Find(user => user.UserName == "yakupeyisan");
Console.ReadKey();

List<int> nums = new List<int> { 0, 1, 2, 3, 4, 5 };
Console.WriteLine(JsonConvert.SerializeObject(nums));
var strList=nums.Select(num => num.ToString()).ToList();
Console.WriteLine(JsonConvert.SerializeObject(strList));
Console.ReadKey();

"Ali".WriteLine("--->");
Console.ReadKey();
*/
var personalUsers = JsonConvert.DeserializeObject<IList<Personal>>(Datas.PersonalJson);
var studentUsers = JsonConvert.DeserializeObject<IList<Student>>(Datas.StudentJson) ;
var jobberUsers = JsonConvert.DeserializeObject<IList<Jobber>>(Datas.JobberJson);
IDictionary<string,IList<string>> indexes =new Dictionary<string,IList<string>>();
IDictionary<string, IUser> fastList = new Dictionary<string, IUser>();
//fastList.AddToDictionary2(personalUsers.Select(user => (user as IUser)).ToList());

fastList.AddToDictionary(personalUsers.Select(user=>(user as IUser)).ToList(),indexes);
//Console.WriteLine(JsonConvert.SerializeObject(fastList));
//Console.WriteLine();
//Console.WriteLine(JsonConvert.SerializeObject(indexes));
var findAll = FindByIndex("Dugall");
Console.WriteLine(JsonConvert.SerializeObject(findAll));
Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff"));
var findedListWithPredicate=personalUsers.FindAll(user => user.FirstName == "Dugall" || user.LastName == "Dugall");
Console.WriteLine(JsonConvert.SerializeObject(findedListWithPredicate));
Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff"));
Console.ReadKey();

IList<IUser>? FindByIndex(string search)
{
    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fffffff"));
    if (indexes.ContainsKey(search))
    {
        var findedKeys=indexes[search];
        return findedKeys.Select(key => fastList[key]).ToList();
    }
    return null;
}
public static class MicrosoftExtensions
{
    public static void WriteLine(this string text,string addText="")
    {
        Console.WriteLine(addText+text);
    }
    public static List<T> FindAll<T>(this IList<T> values, Predicate<T> predicate)
    {
        return values.ToList().FindAll(predicate);
    }
    public static T? Find<T>(this IList<T> values, Predicate<T> predicate)
    {
        return values.ToList().Find(predicate);
    }
    /** @deprecated */
    public static void AddToDictionary2<TKey,TValue>(this IDictionary<TKey, TValue> values,List<TValue> users)
        where TKey: notnull
        where TValue: IUser
    {
        users.ToList().ForEach(user =>
        {
            TKey key = (TKey)(object)user.UserName;
            values.Add(key, user);
        });
    }
    //IDictionary<string, IUser>
    public static void AddToDictionary<TKey,TValue>(
        this IDictionary<TKey, TValue> values, 
        IList<TValue> users,
        IDictionary<TKey,IList<TKey>> indexes
        )
        where TValue: IUser
        where TKey: notnull
    {
        TKey castToKey(object key)
        {
            return (TKey)key;
        };
        void addIndex(object findKeyObject, TKey dataKey)
        {
            TKey findKey= castToKey(findKeyObject);
            if (indexes.ContainsKey(findKey))
            {
                indexes[findKey].Add(dataKey);
            }
            else
            {
                indexes.Add(findKey, new List<TKey>() { dataKey });
            }
        };
        users?.ToList().ForEach(user =>
        {
            TKey key = castToKey(user.UserName);
            values.Add(key, user);
            addIndex(user.FirstName, key);
            addIndex(user.LastName, key);
            var personal = user.CastTo<IPersonal>();
            if (personal!=null){
                addIndex(personal.SSN, key);
            }
            /*
            if(user is IPersonal)
            {
            yakupeyisan
                var personal = (user as IPersonal);
                if(personal!= null) addIndex(personal.SSN, key);
            }
            */
        });
    }
    public static TObject? CastTo<TObject>(this object value)
        where TObject: class
    {
        if (value is TObject)
        {
            return value as TObject;
        }
        return null;
    }
}
