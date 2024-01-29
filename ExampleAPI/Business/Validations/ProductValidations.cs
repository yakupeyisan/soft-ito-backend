using ExampleAPI.Core.Exceptions;
using ExampleAPI.Entities;

namespace ExampleAPI.Business.Validations;

public class ProductValidations
{
    public void IfExists(Product? product){
        if(product==null) throw new ValidationException("Product not found.");
    }   
}