using API.DTO;
using API.Errors;
using API.Helpers;
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
    public async Task<ActionResult<Pagination<ProductDTO?>>> GetProducts([FromQuery] ProductSpecificationParams productSpecificationParams)
    {
        var specification = new ProductsWithTypesAndBrandsSpecification(productSpecificationParams);

        var countSpesification = new ProductWithFiltersForCountSpecification(productSpecificationParams);

        var totalItems = await _productRepo.CountAsync(countSpesification);

        var products = await _productRepo.ListAsync(specification);
        var productsDTO = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(products);

        Pagination<ProductDTO?> pagination = new Pagination<ProductDTO?>(
            productSpecificationParams.PageIndex,
            productSpecificationParams.PageSize,
            totalItems,
            productsDTO
        );

        return Ok(pagination);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductDTO?>> GetProduct(int id)
    {
        var specification = new ProductsWithTypesAndBrandsSpecification(id);
        var product = await _productRepo.GetEntityWithSpecification(specification);
        if (product is null) return NotFound(new ApiResponse(404));
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