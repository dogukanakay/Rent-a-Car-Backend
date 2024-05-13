using AutoMapper;
using Entities.Requests.Create;
using Entities.Concrete;
using Entities.Responses.Create;
using Entities.Requests.Update;
using Entities.Responses.GetList;
using Entities.Responses.GetById;

namespace Business.MappingProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Brand, CreateBrand>().ReverseMap();
            CreateMap<Brand, CreateBrandResponse>().ReverseMap();
            CreateMap<Brand, UpdateBrand>().ReverseMap();
            CreateMap<Brand, GetListBrandResponse>().ReverseMap();
            CreateMap<Brand, GetByIdBrandReponse>().ReverseMap();
        }
    }
}
