using ExampleAPI.Contexts;
using ExampleAPI.Core;
using ExampleAPI.Entities;
using ExampleAPI.Repositories.Abstracts;

namespace ExampleAPI.Repositories.Concretes;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(ExampleDbContext context) : base(context)
    {
    }
}

