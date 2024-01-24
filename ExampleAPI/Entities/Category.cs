using System.ComponentModel.DataAnnotations;
using ExampleAPI.Core;

namespace ExampleAPI.Entities;

public class Category : Entity<Guid>
{
	[MaxLength(50)]
	public required string Name { get; set; }

	public virtual ICollection<Product> Products { get; set; }
	public Category()
	{
		Products = new HashSet<Product>();
	}
}
