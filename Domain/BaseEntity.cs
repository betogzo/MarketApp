﻿namespace MarketApp.Domain;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string CreatedBy { get; set; }
    public string EditedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime EditedOn { get; set; }

    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }
}
