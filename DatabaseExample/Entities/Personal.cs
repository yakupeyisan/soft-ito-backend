using DatabaseExample.Core;

namespace DatabaseExample.Entities;

public class Personal : Entity<Guid>
{
    public Guid UserId { get; set; }
    public decimal Salary { get; set; }
    public string SSN { get; set; }
    public virtual User User { get; set; }
}
