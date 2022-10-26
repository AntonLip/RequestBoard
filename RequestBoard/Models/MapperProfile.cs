using AutoMapper;
using RequestBoard.Models.DbModels;
using RequestBoard.Models.DtoModels;

namespace RequestBoard.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RequestToRestore, RequestDto>()
            .ForMember(dest => dest.RequestTypeName,
                    opt =>
                    {
                        opt.MapFrom<RequestTypeResolver>();
                    });

        }
    }
}