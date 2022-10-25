namespace Core.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public string? PictureURL { get; set; }

    public ProductType ProductType { get; set; } = null!;

    public int ProductTypeId { get; set; }

    public ProductBrand ProductBrand { get; set; } = null!;

    public int ProductBrandId { get; set; }
}