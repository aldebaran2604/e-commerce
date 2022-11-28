using Core.Entities;

namespace Core.Specifications;

public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
{
    public ProductsWithTypesAndBrandsSpecification()
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
    }

    public ProductsWithTypesAndBrandsSpecification(ProductSpecificationParams productSpecificationParams)
        : base(x =>
              (string.IsNullOrEmpty(productSpecificationParams.Search) || x.Name.ToLower().Contains(productSpecificationParams.Search)) &&
              (!productSpecificationParams.BrandId.HasValue || x.ProductBrandId == productSpecificationParams.BrandId) &&
              (!productSpecificationParams.TypeId.HasValue || x.ProductTypeId == productSpecificationParams.TypeId))
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
        AddOrderBy(x => x.Name);
        ApplyPaging(productSpecificationParams.PageSize * (productSpecificationParams.PageIndex - 1), productSpecificationParams.PageSize);

        if (!string.IsNullOrEmpty(productSpecificationParams.Sort))
        {
            switch (productSpecificationParams.Sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;

                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;

                default:
                    AddOrderBy(p => p.Name);
                    break;
            }
        }
    }

    public ProductsWithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
    }
}