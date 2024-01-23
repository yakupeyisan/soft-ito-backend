using DatabaseExample.Core;

namespace DatabaseExample.Entities;

public class Student : Entity<Guid>
{
    public Guid UserId { get; set; }
    public string Number { get; set; }
    public byte Marks { get; set; }
    public byte Absenteeism { get; set; }
    public virtual User User { get; set; }
}
