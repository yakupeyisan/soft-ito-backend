using DatabaseExample.Core;

namespace DatabaseExample.Entities;

public class Jobber : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string Plate { get; set; }
    public string WorkArea { get; set; }
    public virtual User User { get; set; }
}