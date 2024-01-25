using System.ComponentModel.DataAnnotations;
using ExampleAPI.Core;

namespace ExampleAPI.Entities;

public class Product: Entity<Guid>
{
	public Guid CategoryId { get; set; }
    [MaxLength(50)]
    public required string Name { get; set; }
    public required decimal Price { get; set; }
    public string? Description { get; set; }
    public virtual Category Category { get; set; }
    public virtual ICollection<ProductTransaction> ProductTransactions { get; set; }
    public Product()
    {
        ProductTransactions = new HashSet<ProductTransaction>();
    }
}