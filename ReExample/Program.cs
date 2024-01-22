// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using ReExample;

Console.WriteLine("Hello, World!");
Dictionary<string, IUser> cachedUser = new Dictionary<string, IUser>();
Dictionary<string, List<string>> indexes = new Dictionary<string, List<string>>();
List<IUser> users = new List<IUser>();
users.Add(new Personal()
{
    FirstName = "Yakup",
    LastName = "Eyisan",
    IdentificationNumber = "11223344551",
    UserName = "yakupeyisan",
    Password = "1234",
    SSN = "SSN",
    Salary = 1500,
    IsActive = true
});
users.Add(new Personal()
{
    FirstName = "Sezer",
    LastName = "Ayran",
    IdentificationNumber = "11223344552",
    UserName = "sezerayran",
    Password = "1234",
    SSN = "SSNcik",
    Salary = 2500,
    IsActive = true
});
users.Add(new Personal()
{
    FirstName = "Merve",
    LastName = "Avcı",
    IdentificationNumber = "11223544553",
    UserName = "merveavci",
    Password = "1234",
    SSN = "XXXX",
    Salary = 2500,
    IsActive = true
});
cachedUser.AddDictionary(users,indexes);
Search("112233")?.ToJsonString().WriteLine();

Console.ReadKey();

List<IUser>? Search(string search)
{
    if (indexes.ContainsKey(search.ToLower()))
    {
        return indexes[search.ToLower()].Select(key => cachedUser[key]).ToList();
    }
    return null;
}

public static class MicrosoftExtensions
{
    public static string ToJsonString(this object value) => JsonConvert.SerializeObject(value);
    public static void WriteLine(this object value)
    {
        if(value is List<int>)
        {
            JsonConvert.SerializeObject(value).WriteLine();
            return;
        }
        Console.WriteLine(value);
    }
    public static void AddDictionary<TKey,TValue>(this Dictionary<TKey, TValue> values,List<TValue> users,Dictionary<string,List<string>> indexes)
        where TValue:IUser
        where  TKey:notnull
    {
        users.ForEach(user =>
        {
            TKey key = (TKey)(object)user.UserName.ToLower();
            values.Add(key,user);
            user.GetType()
            .GetProperties()
            .Where(property=> property.GetCustomAttributes(true).Where(attr => attr.GetType() == typeof(SearchAttribute)).Count() > 0)
            .ToList()
            .ForEach(property =>
            {
                var attr =
                 property.GetCustomAttributes(true)
                .Where(attr => attr.GetType() == typeof(SearchAttribute))
                .ToArray()[0] as SearchAttribute;
                string? value = property.GetValue(user, null)?.ToString();
                if (value != null)
                {
                    value.SearchKeys(attr.Match).ForEach(val =>
                    {
                        if (indexes.ContainsKey(val.ToLower()))
                        {
                            indexes[val.ToLower()].Add(user.UserName.ToLower());
                        }
                        else
                        {
                            indexes.Add(val.ToLower(), new List<string>() { user.UserName.ToLower() });
                        }
                    });
                }
            });
        }); 
    }
    public static List<string> SearchKeys(this string key,MatchTypes matchType)
    {
        if (MatchTypes.Full == matchType) return new List<string>() { key };
        
        var keys=new List<string>();
        for (int i=1; i <= key.Length; i++)
        {
            if (MatchTypes.StartsWith == matchType)
                keys.Add(key.Substring(0, i));
            if (MatchTypes.EndsWith == matchType)
                keys.Add(key.Substring(key.Length- i));
        }
        return keys;
    }
}