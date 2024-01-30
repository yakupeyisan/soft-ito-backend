using ExampleAPI.Core.Exceptions;
using ExampleAPI.Entities;

namespace ExampleAPI.Business.Validations;

public class OrderDetailValidations
{
    public void IfExists(OrderDetail? orderDetail){
        if(orderDetail==null) throw new ValidationException("Order Detail not found.");
    }   
}
