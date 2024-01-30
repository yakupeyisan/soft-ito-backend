using System.Linq.Expressions;
using ExampleAPI.Business.Abstracts;
using ExampleAPI.Business.Validations;
using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore.Query;

namespace ExampleAPI.Business.Concretes;

public class OrderDetailManager : IOrderDetailService
{
    private readonly IOrderDetailRepository _orderDetailRepository;
    private readonly OrderDetailValidations _orderDetailValidations;
    public OrderDetailManager(IOrderDetailRepository orderDetailRepository, OrderDetailValidations orderDetailValidations)
    {
        _orderDetailRepository = orderDetailRepository;
        _orderDetailValidations = orderDetailValidations;
    }
    public OrderDetail Add(OrderDetail orderDetail)
    {
        return _orderDetailRepository.Add(orderDetail);
    }

    public void DeleteById(Guid id)
    {
        var orderDetail = _orderDetailRepository.Get(u => u.Id == id);
        _orderDetailValidations.IfExists(orderDetail);
        _orderDetailRepository.Delete(orderDetail);
    }

    public OrderDetail? Get(Expression<Func<OrderDetail, bool>> predicate, Func<IQueryable<OrderDetail>, IIncludableQueryable<OrderDetail, object>>? include = null)
    {
        return _orderDetailRepository.Get(predicate, include);
    }
    public IList<OrderDetail> GetAll(Expression<Func<OrderDetail, bool>>? predicate = null, Func<IQueryable<OrderDetail>, IIncludableQueryable<OrderDetail, object>>? include = null, Func<IQueryable<OrderDetail>, IOrderedQueryable<OrderDetail>>? orderBy = null)
    {
        return _orderDetailRepository.GetAll(predicate, include, orderBy).ToList();
    }

    public OrderDetail Update(OrderDetail orderDetail)
    {
        return _orderDetailRepository.Update(orderDetail);
    }
}
