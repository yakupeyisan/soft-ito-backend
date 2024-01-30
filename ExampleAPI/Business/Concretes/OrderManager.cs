using System.Linq.Expressions;
using ExampleAPI.Business.Abstracts;
using ExampleAPI.Business.Validations;
using ExampleAPI.DTOs;
using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore.Query;

namespace ExampleAPI.Business.Concretes;

public class OrderManager : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductTransactionService _productTransactionService;
    private readonly IOrderDetailService _orderDetailService;
    private readonly OrderValidations _orderValidations;
    public OrderManager(IOrderRepository orderRepository,IProductTransactionService productTransactionService,IOrderDetailService orderDetailService, OrderValidations orderValidations)
    {
        _orderRepository = orderRepository;
        _productTransactionService = productTransactionService;
        _orderDetailService = orderDetailService;
        _orderValidations = orderValidations;
    }
    public Order Add(AddOrderDto addOrderDto)
    {
        _orderValidations.CheckTransactionCount(addOrderDto);
        _orderValidations.CheckProductListCount(addOrderDto);
        _orderValidations.CheckStock(addOrderDto);
        var addedOrder = _orderRepository.Add(new()
        {
            UserId=addOrderDto.UserId,
            CreatedDate=DateTime.UtcNow
        });
        addOrderDto.ProductTransactions.ToList().ForEach(productTransaction =>
        {
            productTransaction.Quantity = productTransaction.Quantity > 0 ? -1*productTransaction.Quantity : productTransaction.Quantity;
            var addedProductTransaction = _productTransactionService.Add(productTransaction);
            _orderDetailService.Add(new()
            {
                OrderId= addedOrder.Id,
                ProductId= productTransaction.ProductId,
                ProductTransactionId= addedProductTransaction.Id
            });
        });
        return addedOrder;
    }

    public void DeleteById(Guid id)
    {
        var order = _orderRepository.Get(u => u.Id == id);
        _orderValidations.IfExists(order);
        _orderRepository.Delete(order);
    }

    public Order? Get(Expression<Func<Order, bool>> predicate, Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null)
    {
        return _orderRepository.Get(predicate, include);
    }
    public IList<Order> GetAll(Expression<Func<Order, bool>>? predicate = null, Func<IQueryable<Order>, IIncludableQueryable<Order, object>>? include = null, Func<IQueryable<Order>, IOrderedQueryable<Order>>? orderBy = null)
    {
        return _orderRepository.GetAll(predicate, include, orderBy).ToList();
    }

    public Order Update(Order order)
    {
        return _orderRepository.Update(order);
    }
}
