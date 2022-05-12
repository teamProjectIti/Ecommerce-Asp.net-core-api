using AutoMapper;
using Microsoft.Extensions.Configuration;
using WebApplication1.Dto;
using WebApplication1.Model.Dashbord.Order;

namespace WebApplication1.Helper
{
    public class MAppingordre_product : IValueResolver<OredrProduct, cartShopDto, string>
    {

        private readonly IConfiguration _config;
        public MAppingordre_product(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(OredrProduct source, cartShopDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.image_product))
            {
                return _config["ApiURl"] + source.image_product;
            }
            return null;
        }
    }
}