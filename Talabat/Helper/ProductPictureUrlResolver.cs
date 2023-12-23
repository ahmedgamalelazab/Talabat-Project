using AutoMapper;
using Entities.Models;
using Shared.DataTransfierObject;

namespace Talabat.Helper
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        public IConfiguration _configuration { get; }

        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            _configuration=configuration;
        }
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
                return $"{_configuration["BaseApiUrl"]}/{source.PictureUrl}";
            return null;
        }
    }
}
