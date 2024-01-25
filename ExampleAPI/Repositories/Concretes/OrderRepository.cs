using System;
using ExampleAPI.Contexts;
using ExampleAPI.Core;
using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;

namespace ExampleAPI.Repositories.Concretes;

public class OrderRepository : BaseRepository<Order>,IOrderRepository
{
    public OrderRepository(ExampleDbContext context) : base(context)
    {
    }
}

