
using System.Linq.Expressions;
using ExampleAPI.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace ExampleAPI.Business.Abstracts;

public interface IOrderDetailService{
    IList<OrderDetail> GetAll(
            Expression<Func<OrderDetail, bool>>? predicate = null,
            Func<IQueryable<OrderDetail>, IIncludableQueryable<OrderDetail, object>>? include = null,
            Func<IQueryable<OrderDetail>, IOrderedQueryable<OrderDetail>>? orderBy = null
        );
    OrderDetail? Get(
        Expression<Func<OrderDetail, bool>> predicate,
        Func<IQueryable<OrderDetail>, IIncludableQueryable<OrderDetail, object>>? include = null
    );
    OrderDetail Add(OrderDetail orderDetail);
    OrderDetail Update(OrderDetail orderDetail);
    void DeleteById(Guid id); 
}
