using System;
using System.Diagnostics;
using TurkeyServices;
namespace ExampleAPI.Integrations;

public static class CheckIdentityForTurkey 
{
    private static KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap12);
    public static long CastIdentificationNumber(string identificationNumberStr) 
    {
        long identificationNumber = 0;
        try
        {
            identificationNumber = long.Parse(identificationNumberStr);
        }
        catch (Exception)
        {
        }
        return identificationNumber;
    }

    public static bool CheckIndentity(string identificationNumber,string firstName,string lastName, short birthYear)
    {
        var resultTask = client.TCKimlikNoDogrulaAsync(CastIdentificationNumber(identificationNumber), firstName, lastName, birthYear);
        resultTask.Wait();
        return resultTask.Result.Body.TCKimlikNoDogrulaResult;
    }
    public static async Task<bool> CheckIndentityAsync(string identificationNumber, string firstName, string lastName, short birthYear)
    {
        var result = await client.TCKimlikNoDogrulaAsync(CastIdentificationNumber(identificationNumber), firstName, lastName, birthYear);
        return result.Body.TCKimlikNoDogrulaResult;
    }

}

