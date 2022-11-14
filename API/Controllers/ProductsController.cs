using API.DTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ProductsController : BaseApiController
{
    private IGenericRepository<Product> _productRepo;

    private IGenericRepository<ProductBrand> _productBrandRepo;

    private IGenericRepository<ProductType> _productTypeRepo;

    private IMapper _mapper { get; }

    public ProductsController(IGenericRepository<Product> productRepo,
                              IGenericRepository<ProductBrand> productBrandRepo,
                              IGenericRepository<ProductType> productTypeRepo,
                              IMapper mapper)
    {
        _productRepo = productRepo;
        _productBrandRepo = productBrandRepo;
        _productTypeRepo = productTypeRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProductDTO?>>> GetProducts()
    {
        var specification = new ProductsWithTypesAndBrandsSpecification();
        var products = await _productRepo.ListAsync(specification);
        var productsDTO = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products);
        return Ok(productsDTO);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDTO?>> GetProduct(int id)
    {
        var specification = new ProductsWithTypesAndBrandsSpecification(id);
        var product = await _productRepo.GetEntityWithSpecification(specification);
        var productDTO = _mapper.Map<Product, ProductDTO>(product);
        return Ok(productDTO);
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