using ExampleAPI.Business.Abstracts;
using ExampleAPI.Core.Exceptions;
using ExampleAPI.DTOs;
using ExampleAPI.Entities;

namespace ExampleAPI.Business.Validations;

public class OrderValidations
{
    private readonly IProductTransactionService _productTransactionService;

    public OrderValidations(IProductTransactionService productTransactionService)
    {
        _productTransactionService = productTransactionService;
    }

    public void IfExists(Order? order){
        if(order==null) throw new ValidationException("Order not found.");
    }   
    public void CheckTransactionCount(AddOrderDto addOrderDto){
        if (addOrderDto.ProductTransactions.Count() == 0)
        {
            throw new ValidationException("Product list not be empty.");
        }
    }
    public void CheckProductListCount(AddOrderDto addOrderDto){
        if (addOrderDto.ProductTransactions.Where(t => t.Quantity == 0).Any())
        {
            throw new ValidationException("Product count must not be zero. Please check product list.");
        }
    }
    public void CheckStock(AddOrderDto addOrderDto){
        var checkCounts=addOrderDto.ProductTransactions.Select(t =>
            _productTransactionService.GetAll(pt => pt.ProductId == t.ProductId).Sum(transaction=>transaction.Quantity)-t.Quantity
        ).Where(q=>q<0).Any();
        if (checkCounts)
        {
            throw new ValidationException("We are has not any product stock. Please check stock count");
        }
    }
}

