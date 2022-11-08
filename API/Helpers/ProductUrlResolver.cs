using API.DTO;
using AutoMapper;
using Core.Entities;

namespace API.Helpers;

public class ProductUrlResolver : IValueResolver<Product, ProductDTO, string?>
{
    private readonly IConfiguration _configuration;

    public ProductUrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Resolve(Product source, ProductDTO destination, string? destMember, ResolutionContext context)
    {
        string urlPicture = string.Empty;
        if (!string.IsNullOrEmpty(source.PictureURL))
        {
            Uri fullUri = new Uri(new Uri(_configuration["ApiUrl"]), source.PictureURL);
            urlPicture = fullUri.AbsoluteUri;
        }

        return urlPicture;
    }
}
