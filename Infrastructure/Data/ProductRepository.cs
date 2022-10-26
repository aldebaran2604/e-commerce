using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;

    public ProductRepository(StoreContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<ProductBrand>> getProductBrandsAsync()
    {
        return await _context.ProductBrans.ToListAsync();
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IReadOnlyList<Product>> getProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<IReadOnlyList<ProductType>> getProductTypesAsync()
    {
        return await _context.ProductTypes.ToListAsync();
    }
}