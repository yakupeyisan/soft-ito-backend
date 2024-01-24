using System;
using System.ComponentModel.DataAnnotations;
using ExampleAPI.Core;

namespace ExampleAPI.Entities;

public class User : Entity<Guid>
{
	[MaxLength(150)]
	public required string FirstName { get; set; }
	[MaxLength(150)]
	public required string LastName { get; set; }
	public short BirthYear { get; set; }
	[MaxLength(20)]
	public required string IdentificationNumber { get; set; }
	[MaxLength(10)]
	public string? CarPlate { get; set; }
}
