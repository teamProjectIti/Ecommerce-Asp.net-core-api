using AutoMapper;
using WebApplication1.Dto;
using WebApplication1.Model.Dashbord;

namespace WebApplication1.Helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductClothe, ProductClothes_Return>()
                 .ForMember(d => d.categore_name, o => o.MapFrom(s => s.categores.Name))
                .ForMember(d => d.product_brand_name, o => o.MapFrom(s => s.ProductBrands.Name))
                .ForMember(d=>d.PictureUrl,o=>o.MapFrom<MapperProduct>());

          
        }
    }
}
