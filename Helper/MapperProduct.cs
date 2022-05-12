using AutoMapper;
using WebApplication1.Dto;
using WebApplication1.Model.Dashbord;
using Microsoft.Extensions.Configuration;

namespace WebApplication1.Helper
{
    public class MapperProduct: IValueResolver<ProductClothe, ProductClothes_Return, string>
    {
        private readonly IConfiguration _config;
        public MapperProduct(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(ProductClothe source, ProductClothes_Return destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiURl"] + source.PictureUrl;
            }
            return null;
        }

    }
}
