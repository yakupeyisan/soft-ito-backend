using System;
using ExampleAPI.Contexts;
using ExampleAPI.Core;
using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;

namespace ExampleAPI.Repositories.Concretes;

public class ProductTransactionRepository : BaseRepository<ProductTransaction>, IProductTransactionRepository
{
    public ProductTransactionRepository(ExampleDbContext context) : base(context)
    {
    }
}

