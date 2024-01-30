using ExampleAPI.Core.Exceptions;
using ExampleAPI.Entities;

namespace ExampleAPI.Business.Validations;

public class ProductTransactionValidations
{
    public void IfExists(ProductTransaction? productTransaction){
        if(productTransaction==null) throw new ValidationException("Product transaction not found.");
    }   
}