using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private IGenericRepository<Product> _productRepo;

    private IGenericRepository<ProductBrand> _productBrandRepo;

    private IGenericRepository<ProductType> _productTypeRepo;

    public ProductsController(IGenericRepository<Product> productRepo,
                              IGenericRepository<ProductBrand> productBrandRepo,
                              IGenericRepository<ProductType> productTypeRepo)
    {
        _productRepo = productRepo;
        _productBrandRepo = productBrandRepo;
        _productTypeRepo = productTypeRepo;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product?>>> GetProducts()
    {
        var specification = new ProductsWithTypesAndBrandsSpecification();

        var products = await _productRepo.ListAsync(specification);

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product?>> GetProduct(int id)
    {
        var specification = new ProductsWithTypesAndBrandsSpecification(id);
        
        var product = await _productRepo.GetEntityWithSpecification(specification);
        return Ok(product);
    }

    [HttpGet("brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrans()
    {
        var productBrands = await _productBrandRepo.ListAllAsync();
        return Ok(productBrands);
    }

    [HttpGet("types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
    {
        var productTypes = await _productTypeRepo.ListAllAsync();
        return Ok(productTypes);
    }
}