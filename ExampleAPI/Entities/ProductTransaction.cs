using ExampleAPI.Core;

namespace ExampleAPI.Entities;

public class ProductTransaction : Entity<Guid>
{
	public Guid ProductId { get; set; }
	public int Quantity { get; set; }
	public virtual Product Product { get; set; }
}
