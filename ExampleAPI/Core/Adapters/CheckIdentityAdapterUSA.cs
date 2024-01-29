using ExampleAPI.Core.Abstracts;
using ExampleAPI.Integrations;

namespace ExampleAPI.Core.Adapters;

public class CheckIdentityAdapterUSA : ICheckIdentityService
{
    public bool CheckIndentity(string identificationNumber, string firstName, string lastName, short birthYear)
    {
        Console.WriteLine("Amerika servisleri kullanıldı");
        return CheckIdentityForTurkey.CheckIndentity(identificationNumber, firstName, lastName, birthYear);
    }

    public async Task<bool> CheckIndentityAsync(string identificationNumber, string firstName, string lastName, short birthYear)
    {
        return await CheckIdentityForTurkey.CheckIndentityAsync(identificationNumber, firstName, lastName, birthYear);
    }
}

