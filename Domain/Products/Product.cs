namespace MarketApp.Domain.Products;

public class Product : BaseEntity
{
    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }
    public bool HasStock { get; set; }
    public bool IsActive { get; set; } = true;
}
