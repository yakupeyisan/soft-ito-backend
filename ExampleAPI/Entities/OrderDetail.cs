using ExampleAPI.Core;

namespace ExampleAPI.Entities;

public class OrderDetail : Entity<Guid>
{
	public Guid OrderId { get; set; }
	public Guid ProductId { get; set; }
	public Guid ProductTransactionId { get; set; }
	public virtual Order Order { get; set; }
	public virtual Product Product { get; set; }
	public virtual ProductTransaction ProductTransaction { get; set; }
}