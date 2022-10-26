using Core.Entities;

namespace Core.Interfaces;

public interface IProductRepository
{
    Task<Product> GetProductByIdAsync(int id);

    Task<IReadOnlyList<Product>> getProductsAsync();

    Task<IReadOnlyList<ProductBrand>> getProductBrandsAsync();

    Task<IReadOnlyList<ProductType>> getProductTypesAsync();
}