using ExampleAPI.Core.Exceptions;
using ExampleAPI.Entities;

namespace ExampleAPI.Business.Validations;
public class CategoryValidations
{
    public void IfExists(Category? category){
        if(category==null) throw new ValidationException("Category not found.");
    }   
}
