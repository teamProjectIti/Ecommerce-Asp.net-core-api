using AutoMapper;
using WebApplication1.Dto;
using WebApplication1.Model.Dashbord.Order;

namespace WebApplication1.Helper
{
    public class MappingProfileCart:Profile
    {
        public MappingProfileCart()
        {
            CreateMap<OredrProduct, cartShopDto>()
            // .ForMember(d=>d.productbrand,o=>o.MapFrom(p=>p.productbrand.Name))
            // .ForMember(d=>d.productype,o=>o.MapFrom(p=>p.productype.Name))
            .ForMember(d => d.Image, o => o.MapFrom<MAppingordre_product>());

        }
    }
}