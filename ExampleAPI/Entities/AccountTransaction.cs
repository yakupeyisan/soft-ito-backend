using ExampleAPI.Core;

namespace ExampleAPI.Entities;

public class AccountTransaction : Entity<Guid>
{
	public Guid UserId { get; set; }
	public decimal Balance { get; set; }
	public DateTime CreatedDate { get; set; }
	public virtual User User { get; set; }
}
