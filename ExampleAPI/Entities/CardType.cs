using ExampleAPI.Core;

namespace ExampleAPI.Entities;

public class CardType:Entity<Guid>
{
	public string Name { get; set; } //Mifare , Mifare 4k,RFID
}
