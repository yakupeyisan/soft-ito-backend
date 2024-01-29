using System;
namespace ExampleAPI.Core.Abstracts;

public interface ICheckIdentityService
{
    bool CheckIndentity(string identificationNumber, string firstName, string lastName, short birthYear);
    Task<bool> CheckIndentityAsync(string identificationNumber, string firstName, string lastName, short birthYear);
}

