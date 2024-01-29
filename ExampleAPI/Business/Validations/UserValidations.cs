using ExampleAPI.Core.Abstracts;
using ExampleAPI.Core.Exceptions;
using ExampleAPI.Entities;

namespace ExampleAPI.Business.Validations;
public class UserValidations
{
    private readonly ICheckIdentityService _checkIdentityService;
    public UserValidations([FromKeyedServices("TURKEY")] ICheckIdentityService checkIdentityService)
    {
        _checkIdentityService = checkIdentityService;
    }
    public void CheckIdentity(User user)
    {
        bool check = _checkIdentityService.CheckIndentity(user.IdentificationNumber, user.FirstName, user.LastName, user.BirthYear);
        if (!check)
        {
            throw new ValidationException("Identification number is not valid.");
        }
    }
    public void CheckFirstName(User user)
    {
        if(user.FirstName.ToLower().Contains("allah")){
            throw new ValidationException($"User name must not be {user.FirstName}");
        }
    }
    public void IfExists(User? user){
        if(user==null) throw new ValidationException("User not found");
    }

}