using System;
namespace DatabaseExample.Core;
public abstract class Entity
{
}

public abstract class Entity<PKey> : Entity
{
    public PKey Id { get; set; }
}
