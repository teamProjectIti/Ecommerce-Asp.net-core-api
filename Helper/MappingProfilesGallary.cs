using AutoMapper;
using WebApplication1.Dto;
using WebApplication1.Model.Dashbord;

namespace WebApplication1.Helper
{
    public class MappingProfilesGallary:Profile
    {
        public MappingProfilesGallary()
        {
            CreateMap<ProductGallary, productGallaryReturnDtos>()
            // .ForMember(d=>d.productbrand,o=>o.MapFrom(p=>p.productbrand.Name))
            // .ForMember(d=>d.productype,o=>o.MapFrom(p=>p.productype.Name))
            .ForMember(d => d.Url, o => o.MapFrom<productUrlMapperGallary>());

        }
    }
}