using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;
    
    public ProductsController(IProductRepository repository)
    {
            _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var products = await _repository.getProductsAsync();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _repository.GetProductByIdAsync(id);
        return Ok(product);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrans()
    {
        var productBrands = await _repository.getProductBrandsAsync();
        return Ok(productBrands);
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
    {
        var productTypes = await _repository.getProductTypesAsync();
        return Ok(productTypes);
    }
}