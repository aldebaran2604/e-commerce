using Core.Entities;

namespace Core.Specifications;

public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
{
    public ProductWithFiltersForCountSpecification(ProductSpecificationParams productSpecificationParams)
         : base(x => (!productSpecificationParams.BrandId.HasValue || x.ProductBrandId == productSpecificationParams.BrandId) &&
              (!productSpecificationParams.TypeId.HasValue || x.ProductTypeId == productSpecificationParams.TypeId))
    {
    }
}