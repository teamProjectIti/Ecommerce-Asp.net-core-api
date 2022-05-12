using AutoMapper;
using Microsoft.Extensions.Configuration;
using WebApplication1.Dto;
using WebApplication1.Model.Dashbord;

namespace WebApplication1.Helper
{
    public class productUrlMapperGallary:IValueResolver<ProductGallary, productGallaryReturnDtos,string>
    {

        private readonly IConfiguration _config;
        public productUrlMapperGallary(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(ProductGallary source, productGallaryReturnDtos destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Url))
            {
                return _config["ApiURl"] + source.Url;
            }
            return null;
        }

    }
}