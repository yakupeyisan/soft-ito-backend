using ExampleAPI.Core;

namespace ExampleAPI.Entities;

public class Order : Entity<Guid>
{
	public Guid UserId { get; set; }
	public DateTime CreatedDate { get; set; }
	public virtual User User {get;set;}
	public virtual ICollection<OrderDetail> OrderDetails { get; set; }
	public Order()
	{
		OrderDetails = new HashSet<OrderDetail>();
	}
}
